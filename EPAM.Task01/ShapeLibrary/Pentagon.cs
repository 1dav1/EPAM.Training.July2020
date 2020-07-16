using System;

namespace ShapeLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="pentagon"]/Pentagon/*'/>
    public class Pentagon : Shape
    {
        /// <include file='docs.xml' path='docs/members[@name="pentagon"]/Side/*'/>
        public double Side { get; set; }

        // number of sides
        private const int NUMBER = 5;

        // angle at center of pentagon
        private const int CENTER_ANGLE = 36;

        /// <include file='docs.xml' path='docs/members[@name="pentagon"]/GetPerimeter/*'/>
        public override double GetPerimeter()
        {
            if (Side < 0)
                throw new ArgumentOutOfRangeException("Side", "Side must be positive.");

            return Side * NUMBER;
        }

        /// <include file='docs.xml' path='docs/members[@name="pentagon"]/GetArea/*'/>
        public override double GetArea()
        {
            if (Side < 0)
                throw new ArgumentOutOfRangeException("Side", "Side must be positive.");

            return NUMBER * Math.Pow(Side, 2) / (4 * Math.Tan(CENTER_ANGLE));
        }

        /// <include file='docs.xml' path='docs/members[@name="pentagon"]/ToString/*'/>
        public override string ToString()
        {
            return $"Regular Pentagon. Side = {Side}";
        }

        /// <include file='docs.xml' path='docs/members[@name="pentagon"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            return obj is Pentagon pentagon && Side == pentagon.Side;
        }

        /// <include file='docs.xml' path='docs/members[@name="pentagon"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Side);
        }
    }
}
