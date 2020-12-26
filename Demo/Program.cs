using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    class Program
    {
        /*
        static void Main(string[] args)
        {
            var enumerable = Get().ToList();
            var count = enumerable.Count;
            Console.WriteLine("count");
            foreach (var e in enumerable)
            {
                Console.WriteLine($"value {e}");
            }
        }

        public static IEnumerable<int> Get()
        {
            // why not use return, why use yield return ?
            // with return you exit the function then and there
            // yield return => throw a value but then you're still carrying on, executing the function
            Console.WriteLine("Step 1");
            yield return 1;
            Console.WriteLine("Step 2");
            yield return 2;
            Console.WriteLine("Step 3");
        }
        */


        public class MySimpleGen
        {
            int value = 1;
            public int Value => value++;
            public bool HasValue()
            {
                Console.WriteLine(value);

                if (value > 2)
                    return false;
                return true;
            }
        }

        public class MyActualGen : IEnumerable<int>, IEnumerator<int>
        {
            int value = 1;
            public int Current => value++;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public IEnumerator<int> GetEnumerator()
            {
                return this;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public bool MoveNext()
            {
                Console.WriteLine(value);

                if (value > 2)
                    return false;
                return true;
            }

            public void Reset()
            {
                value = 1;
            }
        }

        static void Main ()
        {
            var simpleGen = new MySimpleGen();
            while (simpleGen.HasValue())
            {
                var value = simpleGen.Value;
                Console.WriteLine(value);
            }
            Console.WriteLine("------------");
            var actualGen = new MyActualGen();
            foreach (var v in actualGen)
            {
                Console.WriteLine($"{v} - value");
            }
        }
    }
}
