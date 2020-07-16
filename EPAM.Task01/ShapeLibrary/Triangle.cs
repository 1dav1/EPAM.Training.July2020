using System;

namespace ShapeLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="triangle"]/Triangle/*'/>
    public class Triangle : Shape
    {
        /// <include file='docs.xml' path='docs/members[@name="triangle"]/Side1/*'/>
        public double Side1 { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="triangle"]/Side2/*'/>
        public double Side2 { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="triangle"]/Side3/*'/>
        public double Side3 { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="triangle"]/GetPerimeter/*'/>
        public override double GetPerimeter()
        {
            if (Side1 < 0 || Side2 < 0 || Side3 < 0)
                throw new ArgumentOutOfRangeException("Side", "Sides must be positive.");
            return Side1 + Side2 + Side3;
        }

        /// <include file='docs.xml' path='docs/members[@name="triangle"]/GetArea/*'/>
        public override double GetArea()
        {
            if (Side1 < 0 || Side2 < 0 || Side3 < 0)
                throw new ArgumentOutOfRangeException("Side", "Sides must be positive.");

            double perimeter = GetPerimeter();
            return Math.Sqrt(perimeter * (perimeter - Side1) * (perimeter - Side2) * (perimeter - Side3));
        }

        /// <include file='docs.xml' path='docs/members[@name="triangle"]/ToString/*'/>
        public override string ToString()
        {
            return $"Triangle. Side 1 = {Side1}; Side 2 = {Side2}; Side 3 = {Side3}";
        }

        /// <include file='docs.xml' path='docs/members[@name="triangle"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            // using SSS comparison to determine the congruence 
            return obj is Triangle triangle &&
                    ((Side1 == triangle.Side1 &&
                      Side2 == triangle.Side2 &&
                      Side3 == triangle.Side3) ||

                     (Side1 == triangle.Side2 &&
                      Side2 == triangle.Side3 &&
                      Side3 == triangle.Side1) ||

                     (Side1 == triangle.Side3 &&
                      Side2 == triangle.Side1 &&
                      Side3 == triangle.Side2));
        }

        /// <include file='docs.xml' path='docs/members[@name="triangle"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Side1, Side2, Side3);
        }
    }
}
