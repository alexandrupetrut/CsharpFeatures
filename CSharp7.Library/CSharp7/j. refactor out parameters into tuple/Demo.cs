using System;

namespace CSharp7.Library.CSharp7.j._refactor_out_parameters_into_tuple
{
    public class StandardDemo
    {
        public static void Calculate(int x, int y, out int sum, out int product)
        {
            sum = x + y;
            product = x * y;
        }

        public static void Main(string[] args)
        {
            const int x = 2;
            const int y = 3;

            Calculate(x, y, out int sum, out int product);
            Console.WriteLine($"{x} + {y} = {sum}");
            Console.WriteLine($"{x} * {y} = {product}");
        }
    }

    public class ProperDemo
    {
        public static (int Sum, int Product) Calculate(int x, int y)
        {
            return (x + y, x * y);
        }

        public static void Main(string[] args)
        {
            const int x = 2;
            const int y = 3;

            var result = Calculate(x, y);
            Console.WriteLine($"{x} + {y} = {result.Sum}");
            Console.WriteLine($"{x} * {y} = {result.Product}");
        }
    }
}
