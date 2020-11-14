using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp6.Library.d._nameof_Expression
{
    class Demo
    {
        // avoid having hardcoded strings to be specified in code
        // avoid explicit use of reflection to get the names

        // nameof expression returns the string literal of the property name

        public string Name { get; set; } = "John";
        public int Age { get; set; } = 50;
        public int Salary { get; set; } = 15000;


        //  C#5
        public void OldOutputInfo()
        {
            Console.WriteLine("{0} : {1}", "Name", Name);
            Console.WriteLine("{0} : {1}", "Age", Age);
            Console.WriteLine("{0} : {1}", "Salary", Salary);
        }

        //  C#6 
        public void NewOutputInfo()
        {
            Console.WriteLine("{0} : {1}", nameof(Demo.Name), Name);
            Console.WriteLine("{0} : {1}", nameof(Demo.Age), Age);
            Console.WriteLine("{0} : {1}", nameof(Demo.Salary), Salary);
        }

    }
}
