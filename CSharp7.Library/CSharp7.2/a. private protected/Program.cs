using CSharp7.Library.CSharp7._2.a._private_protected_SHAPES_ASSEMBLY;
using System;

namespace CSharp7.Library.CSharp7._2.a._private_protected_PROGRAM_ASSEMBLY
{
    /*
     *  public: The type or member can be accessed by any other code in the same assembly or another assembly that references it.
     *  private: The type or member can be accessed only by code in the same class or struct.
     *  protected: The type or member can be accessed only by code in the same class, or in a class that is derived from that class.
     *  internal: The type or member can be accessed by any code in the same assembly, but not from another assembly.
     *  protected internal: The type or member can be accessed by any code in the assembly in which it's declared, or from within a derived class in another assembly.
     *  private protected: The type or member can be accessed only within its declaring assembly, by code in the same class or in a type that is derived from that class.
     */

    public class Triangle : Shape
    {
        public Triangle() => AreaFormat = "Triangle Area is {0}";
        public override int Area => 1000;
    }

    public class Shapes
    {
        Triangle shapey => new Triangle { AreaFormat = "Triangle is {0}" };
    }

    public class Program
    {
        static void Main()
        {
            var rectangle = new Rectangle();
            var circle = new Circle();
            var triangle = new Triangle();

            Console.WriteLine(rectangle.FormattedArea);
            Console.WriteLine(circle.FormattedArea);
            Console.WriteLine(triangle.FormattedArea);
        }
    }
}
