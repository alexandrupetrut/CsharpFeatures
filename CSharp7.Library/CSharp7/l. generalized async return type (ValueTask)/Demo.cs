using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp7.Library.CSharp7.l._generalized_async_return_type__ValueTask_
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point (int x, int y) { X = x; Y = y; }
    }

    public class Service
    {
        private IEnumerable<Point> cachedPoints;
        private DateTime lastTime = DateTime.Now;
        private readonly TimeSpan cacheDuration = TimeSpan.FromSeconds(2);

        // public async Task<IEnumerable<Point>> GetPointsAsync()
        public ValueTask<IEnumerable<Point>> GetPointsAsync()
        {
            if (DateTime.Now - lastTime < cacheDuration)
                return new ValueTask<IEnumerable<Point>>(cachedPoints);

            return new ValueTask<IEnumerable<Point>>(GetPointsInternal());

            async Task<IEnumerable<Point>> GetPointsInternal()
            {
                cachedPoints = await Task.Run(() => new List<Point> { new Point(1,3), new Point(3,4) });
                lastTime = DateTime.Now;

                Console.WriteLine("GetPointsInternal: " + lastTime);

                return cachedPoints;
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            var service = new Service();
            for (var i=0; i<10_000_000; i++)
            {
                var result = service.GetPointsAsync().Result;
            }
            Console.WriteLine($"{GC.CollectionCount(0)} collections occured at Generation 0");
        }
    }
}
