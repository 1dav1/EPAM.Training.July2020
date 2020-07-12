using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return Math.PI * 2 * Radius;
        }

        public override void ToString()
        {
            Console.WriteLine("Radius = {0}", Radius);
        }
    }
}
