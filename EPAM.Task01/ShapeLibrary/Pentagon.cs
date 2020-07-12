using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Pentagon : Shape
    {
        //public double Apothem { get; set; }
        public double Side { get; set; }

        // number of sides
        private int NUMBER = 5;

        // angle at center of pentagon
        private int CENTER_ANGLE = 36;

        public override double GetArea()
        {
            return (5 * Math.Pow(Side, 2) / (4 * Math.Tan(CENTER_ANGLE)));
        }

        public override double GetPerimeter()
        {
            return Side * NUMBER;
        }

        public override void ToString()
        {
            //Console.WriteLine("Apothem = {0}", Apothem);
            Console.WriteLine("Regular Pentagon. Side = {0}", Side);
        }
    }
}
