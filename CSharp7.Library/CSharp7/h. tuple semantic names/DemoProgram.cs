using System;
using System.Linq;

namespace CSharp7.Library.CSharp7.h._tuple_semantic_names
{
    public class MathHelper
    {
        public static (int Sum, int Product) Compute(params int[] numbers)
        {
            return (numbers.Sum(), numbers.Aggregate(1, (x, y) => x * y));
        }
    }

    public class DemoProgram
    {
        public static void Main(string[] args)
        {
            var result = MathHelper.Compute(1, 2, 3, 4);

            Console.WriteLine($"Sum is {result.Sum}");
            Console.WriteLine($"Product is {result.Product}");

            // Sum, Product are inferred at compile time
            // tuples still difficult to use in public projects, better to use in private projects
        }
    }
}
