using System;
using System.Xml.Serialization;

namespace ShapeClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="filmtriangle"]/FilmTriangle/*'/>
    [Serializable]
    [XmlType("FilmTriangle")]
    public class FilmTriangle : Shape, IFilm
    {
        private int _id;
        public override int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("ID should be non-negative.");
                _id = value;
            }
        }

        private double _side1;
        /// <include file='docs.xml' path='docs/members[@name="filmtriangle"]/Side1/*'/>
        public double Side1
        {
            get => _side1;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Side1 should be positive.");
                _side1 = value;
            }
        }

        private double _side2;
        /// <include file='docs.xml' path='docs/members[@name="filmtriangle"]/Side2/*'/>
        public double Side2
        {
            get => _side2;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Side2 should be positive.");
                _side2 = value;
            }
        }

        private double _side3;
        /// <include file='docs.xml' path='docs/members[@name="filmtriangle"]/Side3/*'/>
        public double Side3 
        {
            get => _side3;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Side3 should be positive.");
                _side3 = value;
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="filmtriangle"]/Constructor1/*'/>
        public FilmTriangle() { }

        /// <include file='docs.xml' path='docs/members[@name="filmtriangle"]/Constructor2/*'/>
        public FilmTriangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        /// <include file='docs.xml' path='docs/members[@name="filmtriangle"]/Constructor3/*'/>
        public FilmTriangle(Shape parentShape, double side1, double side2, double side3)
        {
            if (parentShape is IPaper)
                throw new Exception("Parent shape is of wrong material.");

            double p = (side1 + side2 + side3) / 2;

            double area = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));

            if (parentShape.GetArea() < area)
                throw new Exception("The area of the derived shape should be less than the area of the parent shape.");

            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        /// <include file='docs.xml' path='docs/members[@name="filmtriangle"]/GetPerimeter/*'/>
        public override double GetPerimeter()
            => Side1 + Side2 + Side3;

        /// <include file='docs.xml' path='docs/members[@name="filmtriangle"]/GetArea/*'/>
        public override double GetArea()
        {
            double p = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }

        /// <include file='docs.xml' path='docs/members[@name="filmtriangle"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            return obj is FilmTriangle filmTriangle &&
                   filmTriangle.Side1 == Side1 &&
                   filmTriangle.Side2 == Side2 &&
                   filmTriangle.Side3 == Side3;
        }

        /// <include file='docs.xml' path='docs/members[@name="filmtriangle"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Side1, Side2, Side3);
        }

        /// <include file='docs.xml' path='docs/members[@name="filmtriangle"]/ToString/*'/>
        public override string ToString()
        {
            return $"FilmTriangle. ID: {Id}. Side1: {Side1}. Side2: {Side2}. Side3: {Side3}.";
        }
    }
}
