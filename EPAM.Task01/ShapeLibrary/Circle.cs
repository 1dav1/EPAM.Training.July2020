using System;

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

        public override string ToString()
        {
            return $"Radius = {Radius}";
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            Circle circle = (Circle)obj;

            return (GetArea() == circle.GetArea());
        }

        public override int GetHashCode()
        {
            string code = $"{GetType()} {GetArea()}";

            return code.GetHashCode();
        }
    }
}
