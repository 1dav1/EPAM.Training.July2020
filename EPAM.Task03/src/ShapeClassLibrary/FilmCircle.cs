using System;
using System.Xml.Serialization;

namespace ShapeClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="filmcircle"]/FilmCircle/*'/>
    [Serializable]
    [XmlType("FilmCircle")]
    public class FilmCircle : Shape, IFilm
    {
        private int _id;
        /// <include file='docs.xml' path='docs/members[@name="filmcircle"]/Id/*'/>
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

        private double _radius;
        /// <include file='docs.xml' path='docs/members[@name="filmcircle"]/Radius/*'/>
        public double Radius 
        { 
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Radius should be posisitve.");
                _radius = value;
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="filmcircle"]/Constructor1/*'/>
        public FilmCircle() { }

        /// <include file='docs.xml' path='docs/members[@name="filmcircle"]/Constructor2/*'/>
        public FilmCircle(double radius)
        {
            Radius = radius;
        }

        /// <include file='docs.xml' path='docs/members[@name="filmcircle"]/Constructor3/*'/>
        public FilmCircle(Shape parentShape, double radius)
        {
            if (parentShape is IPaper)
                throw new Exception("Parent shape is of wrong material.");

            double area = Math.PI * Math.Pow(radius, 2);

            if (parentShape.GetArea() < area)
                throw new Exception("The area of the derived shape should be less than the area of the parent shape.");

            Radius = radius;
        }

        /// <include file='docs.xml' path='docs/members[@name="filmcircle"]/GetPerimeter/*'/>
        // circumference of the circle
        public override double GetPerimeter()
            => 2 * Math.PI * Radius;

        /// <include file='docs.xml' path='docs/members[@name="filmcircle"]/GetArea/*'/>
        public override double GetArea()
            => Math.PI * Math.Pow(Radius, 2);

        /// <include file='docs.xml' path='docs/members[@name="filmcircle"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            return obj is FilmCircle filmCircle &&
                filmCircle.Radius == Radius;
        }

        /// <include file='docs.xml' path='docs/members[@name="filmcircle"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Radius);
        }

        /// <include file='docs.xml' path='docs/members[@name="filmcircle"]/ToString/*'/>
        public override string ToString()
        {
            return $"FilmCircle. Id: {Id}. Radius: {Radius}.";
        }
    }
}
