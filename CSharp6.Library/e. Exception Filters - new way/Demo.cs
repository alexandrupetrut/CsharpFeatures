using System;

namespace CSharp6.Library.e._Exception_Filters___new_way
{
    class Demo
    {
        //  C# 5  =>  we define a function with proper name followed by statement block
        public string GetTime()
        {
            return "Current Time - " + DateTime.Now.ToString("hh:mm:ss");
        }
        public void Output()
        {
            Console.WriteLine(GetTime());
        }

        //  C# 6  =>  functions & properties in lambda expressions
        public string GetTheTime() => "Current Time - " + DateTime.Now.ToString("hh:mm:ss");
    }
}
