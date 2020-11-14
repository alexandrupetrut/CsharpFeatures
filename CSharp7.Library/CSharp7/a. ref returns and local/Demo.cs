using System;
using System.Diagnostics;

namespace CSharp7.Library.CSharp7.a._ref_returns_and_local
{
    public struct GameObject  //  200+ bytes
    {
        public int Id;
        public double X00, X01, X02, X03, X04, X05, X06, X07, X08, X09, X10, X11, X12;
        public double X13, X14, X15, X16, X17, X18, X19, X20, X21, X22, X23, X24, X25;
    }

    public class World
    {
        private readonly GameObject[] gameObjects;
        public World(params GameObject[] gameObjects)
        {
            this.gameObjects = gameObjects;
        }

        // 1st GET method
        public GameObject Get(Func<GameObject, bool> filter)
        {
            for (var i = 0; i < gameObjects.Length; i++)
            {
                if (filter(gameObjects[i]))
                    return gameObjects[i];
            }
            throw new ArgumentOutOfRangeException();
        }

        public delegate bool Predicate(ref GameObject gameObject);
        // 2nd GET method
        public GameObject Get(Predicate filter)
        {
            for (var i = 0; i < gameObjects.Length; i++)
            {
                if (filter(ref gameObjects[i]))
                    return gameObjects[i];
            }
            throw new ArgumentOutOfRangeException();
        }

        // 3rd GET method => recommended if we use a lot of structs and we need a pointer to particular struct in memory 
        public ref GameObject RefGet(Predicate filter)
        {
            for (var i = 0; i < gameObjects.Length; i++)
            {
                if (filter(ref gameObjects[i]))
                    return ref gameObjects[i];
            }
            throw new ArgumentOutOfRangeException();
        }

    }

    public class Program
    {
        public static void Main()
        {
            var world = new World(
                new GameObject { Id = 0 },
                new GameObject { Id = 1 }
            );

            // THIS ELAPSED TAKES 15 SECONDS 
            // why so slow ? we do a lot of copy operations of structs, value types ... 
            var stopWatch = Stopwatch.StartNew();
            for (var i = 0; i < 100_000_000; i++)
            {
                GameObject gameObject = world.Get(x => x.Id == 1);
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            // THIS ELAPSED TAKES 12.5 SECONDS
            // Bit faster, but still we do millions of copies of the game objects 
            stopWatch = Stopwatch.StartNew();
            for (var i = 0; i < 100_000_000; i++)
            {
                GameObject gameObject = world.Get( (ref GameObject x) => x.Id == 1);
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            // THIS ELAPSED TAKES 5.5 SECONDS
            // return a reference to an object, similar to a pointer but a lot more safe ~ 
            stopWatch = Stopwatch.StartNew();
            for (var i = 0; i < 100_000_000; i++)
            {
                ref GameObject gameObject = ref world.RefGet((ref GameObject x) => x.Id == 1);
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
        }
    }
}
