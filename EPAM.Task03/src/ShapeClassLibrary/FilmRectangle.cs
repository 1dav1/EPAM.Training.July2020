using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ShapeClassLibrary
{
    [Serializable]
    [XmlType("FilmRectangle")]
    public class FilmRectangle : Shape, IFilm
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

        private double _height;
        public double Height
        {
            get => _height;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Height should be positive.");
                _height = value;
            }
        }

        private double _width;
        public double Width
        {
            get => _width;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Width should be positive.");
                _width = value;
            }
        }

        public FilmRectangle() { }

        public FilmRectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public FilmRectangle(Shape parentShape, double height, double width)
        {
            if (parentShape is IPaper)
                throw new Exception("Parent shape is of wrong material.");

            double area = height * width;

            if (parentShape.GetArea() < area)
                throw new Exception("The area of the derived shape should be less than the area of the parent shape.");

            Height = height;
            Width = width;
        }

        public override double GetPerimeter()
           => (Height + Width) * 2;

        public override double GetArea()
           => Height * Width;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            return obj is FilmRectangle filmRectangle &&
                 ((filmRectangle.Height == Height && filmRectangle.Width == Width) ||           // if any pairs of equal sides
                  (filmRectangle.Height == Width && filmRectangle.Width == Height));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Height, Width);
        }

        public override string ToString()
        {
            return $"FilmRectangle. Id: {Id}. Height: {Height}. Width: {Width}.";
        }
    }
}
