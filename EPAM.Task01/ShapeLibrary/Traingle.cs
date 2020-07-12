using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Traingle : Shape
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }
        public override double GetPerimeter()
        {
            return Side1 + Side2 + Side3;
        }

        public override double GetArea()
        {
            double perimeter = GetPerimeter();
            return Math.Sqrt(perimeter * (perimeter - Side1) * (perimeter - Side2) * (perimeter - Side3));
        }

        public override void ToString()
        {
            Console.WriteLine("Side 1 = {0}", Side1);
            Console.WriteLine("Side 2 = {0}", Side2);
            Console.WriteLine("Side 3 = {0}", Side3);
        }
    }
}
