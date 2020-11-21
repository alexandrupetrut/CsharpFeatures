using System;

namespace ActionAndFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Action => delegate representing void methods
            Action voidAction = ParameterlessActionMethod;
            voidAction += () => Console.WriteLine("Lambda fct");
            voidAction();

            Console.WriteLine();
            Console.WriteLine("************************");
            Console.WriteLine();

            Action<bool> boolAction = ParameterfulActionMethod;
            boolAction += (x) => Console.WriteLine(x);
            boolAction(true);
            boolAction(false);

            Console.WriteLine();
            Console.WriteLine("************************");
            Console.WriteLine();

            Action<int, string, bool> complicatedAction = ComplicatedActionMethod;
            complicatedAction += (nr, text, expr) => Console.WriteLine($"The expression is {expr}, the number is {nr}, the text is {text ?? "nada"}.");
            complicatedAction(5, null, true);
            complicatedAction(10, "Meh", false);

            Console.WriteLine();
            Console.WriteLine("************************");
            Console.WriteLine();


            // Func => non-void methods only with last generic parameter being the return type, everything else is input
            Func<int> intFunc = ParameterlessFuncMethod;
            intFunc += () => 15;
            Console.WriteLine(intFunc());  // prints out cw from method and nr 15 only, you can't return multiple values from a Func, only last result
            
            Console.WriteLine();
            Console.WriteLine("************************");
            Console.WriteLine();
            
            Func<string, bool, int> paramFunc = ParameterfulFuncMethod;
            Console.WriteLine(paramFunc("Testing", true));
            
            Console.WriteLine();
            Console.WriteLine("************************");
            Console.WriteLine();
            
            Func<int, int, double> doubleFunc = (x, y) => x + y;
            Console.WriteLine(doubleFunc(15,10));

            Console.WriteLine();
            Console.WriteLine("************************");
            Console.WriteLine();


            var cat = new Cat() { Name = "Katsya" };
            
            Action<Cat> catAction = cat => cat.SayMeow();
            catAction(cat);

            Console.WriteLine("************************");

            Func<Cat, string> catFunc = cat => cat.Name;
            Console.WriteLine(catFunc(cat));
        }

        // ACTION Methods
        public static void ParameterlessActionMethod()
        {
            Console.WriteLine("Test");
        }
        public static void ParameterfulActionMethod(bool expr)
        {
            if (expr)
                Console.WriteLine("True story");
            else
                Console.WriteLine("Fake story");
        }
        public static void ComplicatedActionMethod(int number, string text, bool expr)
        {
            if (expr)
                Console.WriteLine($"True - {number}");
            else
                Console.WriteLine($"Fake - {number}");
        }

        // FUNC Methods
        public static int ParameterlessFuncMethod()
        {
            Console.WriteLine("calling parameterless func method");
            return 123;
        }
        public static int ParameterfulFuncMethod(string text, bool someBool)
        {
            Console.WriteLine($"calling parameterful func method with the following text: {text}");
            return 20;
        }

        public class Cat
        {
            public string Name { get; set; }
            public void SayMeow()
            {
                Console.WriteLine("Meowing");
            }
        }
    }
}