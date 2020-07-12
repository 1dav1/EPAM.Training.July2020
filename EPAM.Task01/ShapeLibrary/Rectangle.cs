using System;

namespace ShapeLibrary
{
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override double GetArea()
        {
            if (Height < 0 || Width < 0)
                throw new ArgumentOutOfRangeException("Side", "Sides must be positive.");

            return Height * Width;
        }

        public override double GetPerimeter()
        {
            if (Height < 0 || Width < 0)
                throw new ArgumentOutOfRangeException("Side", "Sides must be positive.");
            return (Height + Width) * 2;
        }

        public override string ToString()
        {
            return $"Rectangle. Height = {Height}; Width = {Width}";
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            Rectangle rectangle = (Rectangle)obj;

            return (Height == rectangle.Height &&
                    GetArea() == rectangle.GetArea() &&
                    Width == rectangle.Width);
        }

        public override int GetHashCode()
        {
            string code = $"{GetType()} {GetArea()}";

            return code.GetHashCode();
        }
    }
}
