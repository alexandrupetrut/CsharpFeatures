using System;
using System.Collections.Generic;

namespace CSharp8.Library
{
    public static class NullCoalescingAssignment
    {
        public static void Demo()
        {
            var example = new ListDemo();

            // example.LuckyNumbers.Add(15);  
            // ERROR System.NullReferenceException => object reference not set to an instance of an object

            // let's fix this
            //example.LuckyNumbers = new List<int>();
            //example.LuckyNumbers.Add(15);

            // to check and make sure we use:
            //if (example.LuckyNumbers == null)
            //{
            //    example.LuckyNumbers = new List<int>();
            //}
            //example.LuckyNumbers.Add(15);

            // WITH C# 8 we can use: ??= which is the null coalescing assignment => evaluates whats on the left and if null will assign what's on the right
            example.LuckyNumbers ??= new List<int>();
            example.LuckyNumbers.Add(15);

            // we already had the null checks => not null sign ?.
            example?.LuckyNumbers?.Add(15);


            foreach (var item in example.LuckyNumbers)
            {
                Console.WriteLine($"Lucky Number: {item}");
            }
        }
    }

    public class ListDemo
    {
        // not instantiated => null
        public List<int> LuckyNumbers { get; set; }
    }
}
