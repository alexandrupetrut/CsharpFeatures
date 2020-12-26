using System;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int> five = () => 5;
            Console.WriteLine(five());         
            
// we are expecting a function that returns an integer => store the info about it
// also can't have method body with expressions, because method bodies have statements that expressions cant evaluate
            Expression<Func<int>> five_exp = () => 5;
            Console.WriteLine(five_exp);
            Console.WriteLine(five_exp.Compile().Invoke());


            Console.WriteLine("------------------------");


            var user = new User();
            Expression<Func<User, object>> expr = user => user.Age;
            Console.WriteLine($"\nExpression: {expr} \nExpression body: {expr.Body} \nExpression name: {expr.Name} \nExpression type: {expr.Type}");

            var body = expr.Body;
            if (body is MemberExpression me)
                Console.WriteLine(me.Member.Name.ToLower()); // if expr = user => user.Name
            else if (body is UnaryExpression ue)
                Console.WriteLine( ((MemberExpression) ue.Operand).Member.Name.ToLower() ); // if expr = user => user.Age this is unary
        }

        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
