using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7.Library.CSharp7._1.b._default_expressions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var f = new HybridFunction<int, int>();
            f.AddFunction(x => x + 1,   x => x > 5);
            f.AddFunction(x => x * x,   x => x < 0);
            f.AddFunction(x => 0);

            Console.WriteLine("       {");
            Console.WriteLine("       { x + 1         x > 5");
            Console.WriteLine("f(x) = { x * x         x < 0");
            Console.WriteLine("       { 0             otherwise");
            Console.WriteLine("       {  ");
            Console.WriteLine();

            Console.WriteLine($"f(10) = {f.Invoke(10)}");       // f (10) = 11
            Console.WriteLine($"f(-5) = {f.Invoke(-5)}");       // f (-5) = 25
            Console.WriteLine($"f( 4) = {f.Invoke(4)}");        // f ( 4) = 0
        }
    }

    public class HybridFunction<T, TResult>
    {
        private readonly List<(Func<T, TResult> Func, Predicate<T> Pred)> Functions;
        public HybridFunction()
        {
            Functions = new List < (Func<T, TResult>, Predicate<T>) > ();
        }
        public void AddFunction(Func<T, TResult> func, Predicate<T> pred = null)
        {
            Functions.Add((func, pred));
        }
        public TResult Invoke (T x)
        {
            foreach (var function in Functions)
            {
                if (function.Pred == null || function.Pred(x))
                {
                    if (function.Func == null)
                    {
                        // old
                        // return default(TResult);

                        //new
                        return default;
                    }
                    return function.Func(x);
                }
            }

            // old
            //return default(TResult);

            // new
            return default;
        }
    }
}
