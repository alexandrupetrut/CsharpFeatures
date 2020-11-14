using System;
using System.Net;

namespace CSharp6.Library.h._Expression_Bodied_Methods
{
    class Demo
    {
        //  C# 5  =>  we could not filter the exception in the catch block, we used if-else in same catch block
        void MainOld()
        {
            var httpStatusCode = (HttpStatusCode)402;
            Console.Write("HTTP Error: ");

            try
            {
                throw new Exception(httpStatusCode.ToString());
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("400"))
                    Console.WriteLine("Bad Request");
                else if (ex.Message.Equals("401"))
                    Console.WriteLine("Unauthorized");
                else if (ex.Message.Equals("402"))
                    Console.WriteLine("Payment required");
            }
        }

        //  C# 6  =>  rather than entering the catch to check which condition met the exception, we can decide
        //            decide if we even want to enter the specific catch block
        void MainNew()
        {
            var httpStatusCode = (HttpStatusCode)402;
            Console.Write("HTTP Error: ");

            try
            {
                throw new Exception(httpStatusCode.ToString());
            }
            catch (Exception ex) when (ex.Message.Equals("400"))
            {
                Console.WriteLine("Bad Request");
            }
            catch (Exception ex) when (ex.Message.Equals("401"))
            {
                Console.Read();
                Console.WriteLine("Unauthorized");
            }
            catch (Exception ex) when (ex.Message.Equals("402"))
            {
                Console.WriteLine("Payment required");
            }
        }
    }
}
