using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Pentagon : Shape
    {
        public double Apothem { get; set; }
        public double Side { get; set; }

        // number of sides
        private int NUMBER = 5;

        public override double GetArea()
        {
            double perimeter = GetPerimeter();
            return (perimeter * Apothem) / 2;
        }

        public override double GetPerimeter()
        {
            return Side * NUMBER;
        }

        public override void ToString()
        {
            Console.WriteLine("Apothem = {0}", Apothem);
            Console.WriteLine("Side = {0}", Side);
        }
    }
}
