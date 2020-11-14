using System;
using System.Linq;

namespace CSharp7.Library.CSharp7.i._tuple_deconstructions
{
    public class Demo
    {
        public static (int Sum, int Product) Calculate(int x, int y)
        {
            return (x + y, x * y);
        }

        public static void Main(string[] args)
        {
            const int x = 2;
            const int y = 3;

            // Standard way
            var result = Calculate(x, y);
            Console.WriteLine($"{x} + {y} = {result.Sum}");
            Console.WriteLine($"{x} * {y} = {result.Product}");

            // TUPLE DECONSTRUCTION
            (int sum, int product) = Calculate(x, y);
            Console.WriteLine($"{x} + {y} = {sum}");
            Console.WriteLine($"{x} * {y} = {product}");
        }
    }
}