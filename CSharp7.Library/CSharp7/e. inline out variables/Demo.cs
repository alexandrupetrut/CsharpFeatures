using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7.Library.CSharp7.e._inline_out_variables
{
    public class MathHelper
    {
        // old school
        public static int Sum (string first, string second)
        {
            int n, m;
            if (int.TryParse(first, out n) && int.TryParse(second, out m))
                return n + m;
            throw new InvalidOperationException();
        }

        // inline variables in C# 7
        public static int Subtract(string first, string second)
        {
            if (int.TryParse(first, out int n) && int.TryParse(second, out int m))
                return n - m;
            throw new InvalidOperationException();
        }

        // old school
        public static int Product(string first, string second)
        {
            int n, m;
            if (int.TryParse(first, out n) && int.TryParse(second, out m))
                return n * m;
            throw new InvalidOperationException();
        }
    }

    class Program
    {
        public static void Main()
        {
            Console.Write("Insert the first number: ");
            var first = Console.ReadLine();            
            
            Console.Write("Insert the second number: ");
            var second = Console.ReadLine();

            Console.WriteLine($"{first} + {second} = {MathHelper.Sum(first, second)}");
            Console.WriteLine($"{first} - {second} = {MathHelper.Subtract(first, second)}");
            Console.WriteLine($"{first} * {second} = {MathHelper.Product(first, second)}");
        }
    }
}
