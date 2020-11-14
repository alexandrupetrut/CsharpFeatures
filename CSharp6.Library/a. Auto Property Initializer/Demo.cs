using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp6.Library.b. using Static
{
    public class Demo
    {

        /// summary ///
        /// auto property initializer is a new concept to set the value
        /// of a property during property declaration
         
        
        ///  C#5 => set values of property in default ctor
        public Demo()
        {
            FirstName = "Mike";
            FirstAge = 40;
            FirstSalary = 10000;
        }
        public string FirstName { get; set; }
        public int FirstAge { get; set; }
        public int FirstSalary { get; set; }



        ///  C#6 => set default value of a read-only properly
        public string SecondName { get; set; } = "John";
        public int SecondAge { get; set; } = 50;
        public int SecondSalary { get; set; } = 15000;

    }
}
