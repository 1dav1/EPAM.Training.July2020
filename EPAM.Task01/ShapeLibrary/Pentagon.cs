using System;

namespace ShapeLibrary
{
    public class Pentagon : Shape
    {
        public double Side { get; set; }

        // number of sides
        private int NUMBER = 5;

        // angle at center of pentagon
        private int CENTER_ANGLE = 36;

        public override double GetArea()
        {
            return (NUMBER * Math.Pow(Side, 2) / (4 * Math.Tan(CENTER_ANGLE)));
        }

        public override double GetPerimeter()
        {
            return Side * NUMBER;
        }

        public override void ToString()
        {
            Console.WriteLine("Regular Pentagon. Side = {0}", Side);
        }
    }
}
