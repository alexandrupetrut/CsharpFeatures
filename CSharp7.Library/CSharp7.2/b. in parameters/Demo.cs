using System;
using System.Diagnostics;

namespace CSharp7.Library.CSharp7._2.b._in_parameters
{
    public struct SpaceShip
    {
        public SpaceShip(string name, int x, int y, int width, int height)
        {
            Name = name;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public string Name;
        public double X;
        public double Y;
        public double Width;
        public double Height;

        // slow
        // public static bool Collide (SpaceShip spaceShip1, SpaceShip spaceShip2)
        
        // faster with ref
        // public static bool Collide (ref SpaceShip spaceShip1, ref SpaceShip spaceShip2)
        
        // best with in keyword !  'in' keyword is like using a 'ref readonly'
        public static bool Collide (in SpaceShip spaceShip1, in SpaceShip spaceShip2)
        {
            var result = (spaceShip1.X < spaceShip2.X + spaceShip2.Width) &&
                         (spaceShip2.X < spaceShip1.X + spaceShip1.Width) &&
                         (spaceShip1.Y < spaceShip2.Y + spaceShip2.Height) &&
                         (spaceShip2.Y < spaceShip1.Y + spaceShip1.Height);
            return result;
        }
    }

    public class Demo
    {
        public static void Main()
        {
            var milleniumFalcon = new SpaceShip("Millenium Falcon", 0, 0, 100, 200);
            var enterprise = new SpaceShip("Enterprise", 50, 50, 200, 300);

            var stopWatch = Stopwatch.StartNew();
            for (int i=0; i<100_000_000; i++)
            {
                // slow
                // var result = SpaceShip.Collide(milleniumFalcon, enterprise);

                // faster
                //var result = SpaceShip.Collide(ref milleniumFalcon, ref enterprise);

                // best - don't need to use in when we call the method, its optional
                var result = SpaceShip.Collide(in milleniumFalcon, in enterprise);
                    result = SpaceShip.Collide(milleniumFalcon, enterprise);
            }
            stopWatch.Stop();

            Console.WriteLine(stopWatch.Elapsed.TotalSeconds + " seconds");
        }
    }
}
