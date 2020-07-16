using System;

namespace ShapeLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="rectangle"]/Rectangle/*'/>
    public class Rectangle : Shape
    {
        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/Height/*'/>
        public double Height { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/Width/*'/>
        public double Width { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/GetPerimeter/*'/>
        public override double GetPerimeter()
        {
            if (Height < 0 || Width < 0)
                throw new ArgumentOutOfRangeException("Side", "Sides must be positive.");

            return (Height + Width) * 2;
        }

        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/GetArea/*'/>
        public override double GetArea()
        {
            if (Height < 0 || Width < 0)
                throw new ArgumentOutOfRangeException("Side", "Sides must be positive.");

            return Height * Width;
        }

        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/ToString/*'/>
        public override string ToString()
        {
            return $"Rectangle. Height = {Height}; Width = {Width}";
        }

        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            return obj is Rectangle rectangle &&
                   Height == rectangle.Height &&
                   Width == rectangle.Width;
        }

        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Height, Width);
        }
    }
}
