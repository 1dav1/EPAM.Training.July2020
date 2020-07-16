using System;

namespace ShapeLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="circle"]/Circle/*'/>
    public class Circle : Shape
    {
        /// <include file='docs.xml' path='docs/members[@name="circle"]/Radius/*'/>
        public double Radius { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="circle"]/GetPerimeter/*'/>
        public override double GetPerimeter()
        {
            if (Radius < 0)
                throw new ArgumentOutOfRangeException("Radius", "Radius must be positive.");

            return Math.PI * 2 * Radius;
        }

        /// <include file='docs.xml' path='docs/members[@name="circle"]/GetArea/*'/>
        public override double GetArea()
        {
            if (Radius < 0)
                throw new ArgumentOutOfRangeException("Radius", "Radius must be positive.");

            return Math.PI * Math.Pow(Radius, 2);
        }

        /// <include file='docs.xml' path='docs/members[@name="circle"]/ToString/*'/>
        public override string ToString()
        {
            return $"Circle. Radius = {Radius}";
        }

        /// <include file='docs.xml' path='docs/members[@name="circle"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            return obj is Circle circle && Radius == circle.Radius;
        }

        /// <include file='docs.xml' path='docs/members[@name="circle"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Radius);
        }
    }
}
