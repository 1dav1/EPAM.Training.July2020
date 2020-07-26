using System;
using System.Xml.Serialization;

namespace ShapeClassLibrary
{
    [Serializable]
    [XmlType("FilmCircle")]
    public class FilmCircle : Shape, IFilm
    {
        private int _id;
        public override int Id
        {
            get => _id;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException();
                _id = value;
            }
        }

        private double _radius;
        public double Radius 
        { 
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException();
                _radius = value;
            }
        }

        public FilmCircle() { }

        public FilmCircle(params double[] parameters)
        {
            if (parameters.Length > 1)
                throw new ArgumentException("Too many parameters.");

            Radius = parameters[0];
        }

        public FilmCircle(Shape parentShape, params double[] parameters)
        {
            double area = Math.PI * Math.Pow(parameters[0], 2);

            if (parentShape.GetArea() < area)
                throw new Exception("The area of the derived shape should be less than the area of the parent shape.");

            Radius = parameters[0];
        }

        // circumference of the circle
        public override double GetPerimeter()
            => 2 * Math.PI * Radius;

        public override double GetArea()
            => Math.PI * Math.Pow(Radius, 2);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            return obj is FilmCircle filmCircle &&
                filmCircle.Radius == Radius;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Id, Radius);
        }

        public override string ToString()
        {
            return $"FilmCircle. Id: {Id}. Radius: {Radius}.";
        }
    }
}
