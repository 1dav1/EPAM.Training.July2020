using System;

namespace ShapeClassLibrary
{
    public abstract class Shape
    {
        //public abstract Shape() { }
        //public abstract Shape(Shape parentShape, params double[] parameters);

        public abstract int Id { get; set; }

        public abstract double GetArea();

        public abstract double GetPerimeter();
    }
}
