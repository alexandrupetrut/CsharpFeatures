using System;

namespace BasicDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringDel = new myCoolStringDelegate(SomeMethodWithString);
            Console.WriteLine(stringDel(15, 16));

            Console.WriteLine("**********************************");
            var voidDel = new MyVoidDelegateWithInt(PrintInteger);
            // or   MyVoidDelegateWithInt voidDel = PrintInteger;

            voidDel += PrintIntegerSquared;
            voidDel += PrintInteger;
            voidDel += PrintInteger; // cancelled out
            voidDel -= PrintInteger; // cancelled out
            voidDel += (x) => Console.WriteLine("Printing some cool inline function");
            voidDel += (x) => Console.WriteLine("Printing something else cool");
            voidDel += (x) => Console.WriteLine("**********************************");
            
            PassSomeDelegate(voidDel);
            voidDel?.Invoke(7);
            PassDelegate(voidDel);

        }
        public static string SomeMethodWithString(int x, int y)
        {
            return x + y.ToString();
        }

        public static void PrintInteger (int number)
        {
            Console.WriteLine(number);
        }
        public static void PrintIntegerSquared(int number)
        {
            Console.WriteLine(number*number);
        }
        public static void PassSomeDelegate(MyVoidDelegateWithInt del)
        {
            del(10);
        }
        public static void PassDelegate(Delegate del)
        {
            // must know the correct signature, not known during compile time
            // it's also like 10x slower than normal invoke ...
            del.DynamicInvoke(11);
        }
    }
}
