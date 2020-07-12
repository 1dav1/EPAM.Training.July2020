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
            return Side1 + Side2 + Side3;
        }

        public override double GetArea()
        {
            double perimeter = GetPerimeter();
            return Math.Sqrt(perimeter * (perimeter - Side1) * (perimeter - Side2) * (perimeter - Side3));
        }

        public override string ToString()
        {
            return $"Side 1 = {Side1}; Side 2 = {Side2}; Side 3 = {Side3}";
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            Triangle triangle = (Triangle)obj; 

            return (GetArea() == triangle.GetArea());
        }

        public override int GetHashCode()
        {
            string code = $"{GetType()} {GetArea()}";

            return code.GetHashCode();
        }
    }
}
