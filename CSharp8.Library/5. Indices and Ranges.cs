using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8.Library
{
    public static class IndicesAndRanges
    {
        public static void Demo()
        {
            // how indexing works
            // places[0] = "first"
            // places[4] = "fifth"
            var places = new string[] { "first", "second", "third", "fourth", "fifth" };

            // newer way to work with indexing that makes life a little bit easier
            // lets say we want "fifth" but we don't know how many items there are ~
            var place = places[places.Length - 1];

            // carrot symbol, ^ => means from the end ... ^0 is after/at the end, ^1 is the first position from the end aka last item in the list
            Console.WriteLine($"The last item in the list is { places[^1] }");
            Console.WriteLine($"The second to last item in the list is { places[^2] }");

            Console.WriteLine();

            Console.WriteLine("Places 2 and 3 - indicates index position 2 (item 3) up until 4 (not including it)");
            foreach (var item in places[2..4])   // start at position 2, go up til fourth => "third, fourth" as it won't include places[4]
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("Places 1,2,3 (from 0-4) - indicates index position 1 (item 2) up until last item (not including it)");
            foreach (var item in places[1..^1])   
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("Places 0,1,2,3 - indicates everything up until last item (not including it)");
            foreach (var item in places[..^1])   // start at beginning and go just until the last one
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("Places 1,2,3,4 - indicates everything except the first item");
            foreach (var item in places[1..])   // start at position 1 from 0-based counting and go all the way through the end
            {
                Console.WriteLine(item);
            }
        }
    }
}
