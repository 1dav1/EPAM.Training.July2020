using System;

namespace VectorOperator
{
    /// <include file='docs.xml' path='docs/members[@name="point"]/Point/*'/>
    public class Point
    {
        /// <include file='docs.xml' path='docs/members[@name="point"]/X/*'/>
        public double X { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="point"]/Y/*'/>
        public double Y { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="point"]/Z/*'/>
        public double Z { get; set; }

        // overriding the base Equals() method for the purpose of testing
        /// <include file='docs.xml' path='docs/members[@name="point"]/Equals/*'/>
        public override bool Equals(object obj)
            => obj is Point point &&
            point.X == X &&
            point.Y == Y &&
            point.Z == Z;

        // overriding the base GetHashCode() method for the purpose of testing
        /// <include file='docs.xml' path='docs/members[@name="point"]/GetHashCode/*'/>
        public override int GetHashCode()
            => HashCode.Combine(X, Y, Z);
    }
}
