using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7.Library.CSharp7.c._binary_literals___digit_separators
{
    class Demo
    {
        public static void OLD_Main()
        {
            const int a = 18778534;   //    00000001000111101000100110100110
            const int b = 86243324;   //    00000101001000111111011111111100

            Print("a \t", a);
            Print("b \t", b);
            Print("a & b \t", a & b);
            Print("a | b \t", a | b);
        }

        private static void Print (string description, int number)
        {
            Console.Write(description);
            Console.Write(Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine($"  ({number})");
        }

        public static void NEW_Main()
        {
            // instead of numeric we can use binary representations, just that we use 0b as prefix
            const int a = 0b00000001000111101000100110100110;
            const int b = 0b00000101001000111111011111111100;

            // hard to read so we can use underscores to separate digits, for example for each byte:
            const int c = 0b00000001_00011110_10001001_10100110;
            const int d = 0b00000101_00100011_11110111_11111100;
        }
    }
}
