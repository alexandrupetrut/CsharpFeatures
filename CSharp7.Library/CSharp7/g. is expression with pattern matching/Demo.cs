using System;

namespace CSharp7.Library.CSharp7.g._is_expression_with_pattern_matching
{
    public class Demo
    {
        public class Shape { }
        public class Square : Shape { public int Size; }
        public class Circle : Shape { public int Radius; }

        // old way to do it !
        public static double SillyArea(Shape shape)
        {
            var square = shape as Square;
            if (square != null)
                return square.Size * square.Size;

            var circle = shape as Circle;
            if (circle != null)
                return circle.Radius * circle.Radius * Math.PI;

            throw new InvalidOperationException("Invalid shape");
        }

        // new way to do it !
        public static double SmartArea(Shape shape)
        {
            if (shape is Square square)
                return square.Size * square.Size;
            else if (shape is Circle circle)
                return circle.Radius * circle.Radius * Math.PI;
            else
                throw new InvalidOperationException("Invalid shape");
        }

        public static void Main(string[] args)
        {
            var square = new Square { Size = 10 };
            var circle = new Circle { Radius = 10 };

            Console.WriteLine("Square area = " + SillyArea(square));
            Console.WriteLine("Circle area = " + SmartArea(circle));
        }
    }
}