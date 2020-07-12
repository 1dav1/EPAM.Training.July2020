using System;

namespace ShapeLibrary
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double GetArea()
        {
            if (Radius < 0)
                throw new ArgumentOutOfRangeException("Radius", "Radius must be positive.");

            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetPerimeter()
        {
            if (Radius < 0)
                throw new ArgumentOutOfRangeException("Radius", "Radius must be positive.");

            return Math.PI * 2 * Radius;
        }

        public override string ToString()
        {
            return $"Circle. Radius = {Radius}";
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
