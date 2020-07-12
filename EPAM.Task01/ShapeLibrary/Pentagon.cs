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
            if (Side < 0)
                throw new ArgumentOutOfRangeException("Side", "Side must be positive.");

            return (NUMBER * Math.Pow(Side, 2) / (4 * Math.Tan(CENTER_ANGLE)));
        }

        public override double GetPerimeter()
        {
            if (Side < 0)
                throw new ArgumentOutOfRangeException("Side", "Side must be positive.");

            return Side * NUMBER;
        }

        public override string ToString()
        {
            return $"Regular Pentagon. Side = {Side}";
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            Pentagon pentagon = (Pentagon)obj;

            return (Side == pentagon.Side && GetArea() == pentagon.GetArea());
        }

        public override int GetHashCode()
        {
            string code = $"{GetType()} {GetArea()}";

            return code.GetHashCode();
        }
    }
}
