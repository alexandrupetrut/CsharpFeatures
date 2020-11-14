using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7.Library.CSharp7._2.a._private_protected_SHAPES_ASSEMBLY
{
    public abstract class Shape
    {
        public string AreaFormat { get; set; } = "Area is {0}";
        // private string AreaFormat { get; set; } = "Area is {0}";
        // protected string AreaFormat { get; set; } = "Area is {0}";
        // internal string AreaFormat { get; set; } = "Area is {0}";
        // protected internal string AreaFormat { get; set; } = "Area is {0}";

        // private protected => gives access to particular member only to derived types inside the assembly where its defined, unlike protected internal
        // private protected string AreaFormat { get; set; } = "Area is {0}";
        public abstract int Area { get; }
        public string FormattedArea
        {
            get => string.Format(AreaFormat, Area);
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle() => AreaFormat = "Rectangle Area is {0}";
        public override int Area => 50;
    }

    public class Circle : Shape
    {
        public Circle() => AreaFormat = "Circle Area is {0}";
        public override int Area => 100;
    }

    public class Shapes
    {
        Rectangle shapey => new Rectangle { AreaFormat = "My area is {0}" };
    }
}
