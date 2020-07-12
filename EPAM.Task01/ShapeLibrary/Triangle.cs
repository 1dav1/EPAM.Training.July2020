using System;

namespace ShapeLibrary
{
    public class Triangle : Shape
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }

        public override double GetPerimeter()
        {
            if (Side1 < 0 || Side2 < 0 || Side3 < 0)
                throw new ArgumentOutOfRangeException("Side", "Sides must be positive.");
            return Side1 + Side2 + Side3;
        }

        public override double GetArea()
        {
            if(Side1 < 0 || Side2 < 0 || Side3 < 0)
                throw new ArgumentOutOfRangeException("Side", "Sides must be positive.");

            double perimeter = GetPerimeter();
            return Math.Sqrt(perimeter * (perimeter - Side1) * (perimeter - Side2) * (perimeter - Side3));
        }

        public override string ToString()
        {
            return $"Triangle. Side 1 = {Side1}; Side 2 = {Side2}; Side 3 = {Side3}";
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            Triangle triangle = (Triangle)obj; 

            return (Side1 == triangle.Side1 && 
                    Side2 == triangle.Side2 && 
                    Side3 == triangle.Side3);
        }

        public override int GetHashCode()
        {
            string code = $"{GetType()} Side 1 = {Side1}; Side 2 = {Side2}; Side 3 = {Side3}";

            return code.GetHashCode();
        }
    }
}
