using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp7.Library.CSharp7._3.a._indexing_fixed_fields_without_pinning
{
    // => the keyword 'fixed' allows to create fixed size buffers, in here a buffer of 10 integers
    unsafe struct TenArray
    {
        public fixed int Values[10];
    }

    public class Calculator_old
    {
        private TenArray numbers = new TenArray();
        private TenArray squares = new TenArray();

        public Calculator_old()
        {
            for (var i = 0; i < 10; i++) Set(i);
        }

        // here we use fixed statement in order to pin the 2 values arrays in memory while we do the initialization
        // we do so because fixed buffers require that GC doesn't relocate a value while we're assessing it
        public unsafe void Set(int index)
        {
            // using fixed to pin these particular variables that we want to modify so GC cannot rellocate the variables for the duration of the block
            fixed (int* p1 = numbers.Values)
            fixed (int* p2 = squares.Values)
            {
                p1[index] = index;
                p2[index] = index * index;
            }
        }

        // using fixed to access a particular values array and return a pair of integers
        public unsafe (int n, int squared) Get(int index)
        {
            fixed (int* p1 = numbers.Values)
            fixed (int* p2 = squares.Values)
            {
                return (p1[index], p2[index]);
            }
        }
    }


    // with C# 7.3 => no need to use fixed statements or pointers anymore, we can index fixed fields without pinning
    public class Calculator_new
    {
        private TenArray numbers = new TenArray();
        private TenArray squares = new TenArray();

        public Calculator_new()
        {
            for (var i = 0; i < 10; i++) Set(i);
        }

        public unsafe void Set(int index)
        {
            numbers.Values[index] = index;
            squares.Values[index] = index * index;
        }

        public unsafe (int n, int squared) Get(int index)
        {
                return (numbers.Values[index], squares.Values[index]);
        }
    }

    public class Program
    {
        public static void Main()
        {
            var calculator = new Calculator_new();
            var results = Enumerable.Range(0, 10).Select(i => calculator.Get(i));
            foreach (var (n, square) in results)
            {
                Console.WriteLine($"{n} squared is {square}");
            }
        }
    }
}
