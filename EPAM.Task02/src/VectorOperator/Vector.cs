using System;

namespace VectorOperator
{
    /// <include file='docs.xml' path='docs/members[@name="vector"]/Vector/*'/>
    public class Vector
    {
        /// <include file='docs.xml' path='docs/members[@name="vector"]/X/*'/>
        public double X { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="vector"]/Y/*'/>
        public double Y { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="vector"]/Z/*'/>
        public double Z { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="vector"]/Negate/*'/>
        public static Vector operator -(Vector vector)
            => vector == null ?
            throw new ArgumentNullException() :
            new Vector { X = -vector.X, Y = -vector.Y, Z = -vector.Z, };

        /// <include file='docs.xml' path='docs/members[@name="vector"]/AddVectorVector/*'/>
        public static Vector operator +(Vector vector1, Vector vector2)
            => vector1 == null || vector2 == null ?
            throw new ArgumentNullException() :
            new Vector
            {
                X = vector1.X + vector2.X,
                Y = vector1.Y + vector2.Y,
                Z = vector1.Z + vector2.Z,
            };

        /// <include file='docs.xml' path='docs/members[@name="vector"]/AddVectorPoint/*'/>
        public static Point operator +(Vector vector, Point point)
            => vector == null || point == null ?
            throw new ArgumentNullException() :
            new Point
            {
                X = point.X + vector.X,
                Y = point.Y + vector.Y,
                Z = point.Z + vector.Z,
            };

        /// <include file='docs.xml' path='docs/members[@name="vector"]/AddVectorPoint/*'/>
        public static Point operator +(Point point, Vector vector)
            => vector == null || point == null ?
            throw new ArgumentNullException() :
            new Point
            {
                X = point.X + vector.X,
                Y = point.Y + vector.Y,
                Z = point.Z + vector.Z,
            };

        /// <include file='docs.xml' path='docs/members[@name="vector"]/Subtract/*'/>
        public static Vector operator -(Vector vector1, Vector vector2)
            => vector1 == null || vector2 == null ?
            throw new ArgumentNullException() :
            vector1 + (-vector2);

        /// <include file='docs.xml' path='docs/members[@name="vector"]/MultiplyDoubleVector/*'/>
        public static Vector operator *(double scalar, Vector vector)
            => vector == null ?
            throw new ArgumentNullException() :
            new Vector
            {
                X = scalar * vector.X,
                Y = scalar * vector.Y,
                Z = scalar * vector.Z
            };

        /// <include file='docs.xml' path='docs/members[@name="vector"]/MultiplyDoubleVector/*'/>
        public static Vector operator *(Vector vector, double scalar)
            => vector == null ?
            throw new ArgumentNullException() :
            new Vector
            {
                X = scalar * vector.X,
                Y = scalar * vector.Y,
                Z = scalar * vector.Z
            };

        /// <include file='docs.xml' path='docs/members[@name="vector"]/MultiplyVectorVector/*'/>
        public static double operator *(Vector vector1, Vector vector2)
            => vector1 == null || vector2 == null ?
            throw new ArgumentNullException() :
            vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;

        // overriding the base Equals() method for the purpose of testing
        /// <include file='docs.xml' path='docs/members[@name="vector"]/Equals/*'/>
        public override bool Equals(object obj)
            => obj == null ?
            throw new ArgumentNullException() :
            obj is Vector vector &&
            vector.X == X &&
            vector.Y == Y &&
            vector.Z == Z;

        // overriding the base GetHashCode() method for the purpose of testing
        /// <include file='docs.xml' path='docs/members[@name="vector"]/GetHashCode/*'/>
        public override int GetHashCode()
            => HashCode.Combine(X, Y, Z);
    }
}

