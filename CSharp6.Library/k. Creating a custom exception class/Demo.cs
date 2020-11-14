using System;
using System.Runtime.Serialization;

namespace CSharp6.Library.k._Creating_a_custom_exception_class
{
    class Demo
    {
        //  C# 5  =>  we first created a class that inherited from System.Exception and overwrote the Message property
        public class OldCustomException : Exception
        {
            public override string Message
            {
                get
                {
                    return "We cannot divide a number by zero";
                }
            }
        }
        public void Old()
        {
            int i = 10;
            int j = 0;
            try
            {
                if (j > 0) Console.WriteLine("Res : {0}", i / j);
                else throw new OldCustomException();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }


        //  C# 6  =>  intellisense helps generate the exception class automatically and we just have to provide a string as parameter
        public void New()
        {
            int i = 10;
            int j = 0;
            try
            {
                if (j > 0) Console.WriteLine("Res : {0}", i / j);
                else throw new NewCustomException("We cannot divide a number by zero");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    [Serializable]
    internal class NewCustomException : Exception
    {
        public NewCustomException()
        {
        }

        public NewCustomException(string message) : base(message)
        {
        }

        public NewCustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NewCustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
