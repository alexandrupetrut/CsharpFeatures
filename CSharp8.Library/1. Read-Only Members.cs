using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8.Library
{
    public struct Rectangle
    {
        public double Length { get; set; }
        public double Height { get; set; }

        // deal with structs tho is that they're rarely used, mostly for very short-term stuff, otherwise we'd use classes
        // with structs => if you create an instance of this (Rectangle) and we pass the instance into a method and we call Area() ...
        // ... the compiler would make a defensive copy as the method may change something (in our case it makes no change internally)
        public double Area()
        {
            return Length * Height;
        }

        // the defensive copy takes a little bit of extra memory so we can make this a read only member
        // as such it won't make a defensive copy of this rectangle and save the memory => performance optimization
        // the system knows performance wise that Area() method won't make changes internally and won't make a copy of rectangle
        // it makes performant and also makes sure we protect its intent ...  you can't do "Height += 1" despite the method being readonly
        // as such it marks the Length, Height getters as read-only as well ~
        public readonly double AreaV2()
        {
            return Length * Height;
        }

        // we can use readonly at the declaration level or getter level
        private double _perimeter;
        public readonly double Perimeter
        {
            get
            {
                return _perimeter;
            }
        }

        private double _perimeterV2;
        public double PerimeterV2
        {
            readonly get
            {
                return _perimeterV2;
            }
            set { _perimeterV2 = value; }
        }

    }
}
