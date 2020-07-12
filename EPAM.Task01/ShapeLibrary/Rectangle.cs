using System;

namespace ShapeLibrary
{
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override double GetArea()
        {
            return Height * Width;
        }

        public override double GetPerimeter()
        {
            return (Height + Width) * 2;
        }

        public override string ToString()
        {
            return $"Height = {Height}; Width = {Width}";
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            Rectangle rectangle = (Rectangle)obj;

            return (GetArea() == rectangle.GetArea());
        }

        public override int GetHashCode()
        {
            string code = $"{GetType()} {GetArea()}";

            return code.GetHashCode();
        }
    }
}
