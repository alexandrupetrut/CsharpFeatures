using System;

namespace CSharp6.Library.g._Null_Conditional_Operator
{
    public class Person
    {
        public string Name { get; set; } = null;
    }
    class Demo
    {
        //  C# 5  =>  we used enormous IF conditions for null checking to avoid NullReferenceException
        public void Old()
        {
            Person person = new Person();
            if (person.Name != null) 
                 Console.WriteLine(person.Name);
            else Console.WriteLine("Name is null");
        }

        //  C# 6  =>  we can use  ?.  to check if an instance is null or not
        public void New()
        {
            Person person = new Person();
            var name = person?.Name ?? "Name is null";
            Console.WriteLine(name);
        }
    }
}