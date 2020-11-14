using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp6.Library.i._Easily_format_strings__String_Interpolation_
{
    class Demo
    {
        //  C# 5  =>  we used string.format() to perform string interpolation
        public void OldOutputInfo()
        {
            string name = "C#";
            int version = 5;
            string correctOrderMessage = string.Format("{0} is version {1}", name, version);
            string mistakenOrderMessage = string.Format("{0} is version {1}", version, name);
            Console.WriteLine(correctOrderMessage);
            Console.WriteLine(mistakenOrderMessage);
        }

        //  C# 6  =>  clean way to format strings by writing the arguments, not using placeholders via $
        public void NewOutputInfo()
        {
            string name = "C#";
            int version = 5;
            string message = $"{name} is version {version}";
            Console.WriteLine(message);
        }
    }
}
