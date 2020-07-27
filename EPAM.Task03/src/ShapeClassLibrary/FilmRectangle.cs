using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ShapeClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="filmrectangle"]/FilmRectangle/*'/>
    [Serializable]
    [XmlType("FilmRectangle")]
    public class FilmRectangle : Shape, IFilm
    {
        private int _id;
        /// <include file='docs.xml' path='docs/members[@name="filmrectangle"]/Id/*'/>
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
        /// <include file='docs.xml' path='docs/members[@name="filmrectangle"]/Height/*'/>
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
        /// <include file='docs.xml' path='docs/members[@name="filmrectangle"]/Width/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="filmrectangle"]/Constructor1/*'/>
        public FilmRectangle() { }

        /// <include file='docs.xml' path='docs/members[@name="filmrectangle"]/Constructor2/*'/>
        public FilmRectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        /// <include file='docs.xml' path='docs/members[@name="filmrectangle"]/Constructor3/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="filmrectangle"]/GetPerimeter/*'/>
        public override double GetPerimeter()
           => (Height + Width) * 2;

        /// <include file='docs.xml' path='docs/members[@name="filmrectangle"]/GetArea/*'/>
        public override double GetArea()
           => Height * Width;

        /// <include file='docs.xml' path='docs/members[@name="filmrectangle"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            return obj is FilmRectangle filmRectangle &&
                 ((filmRectangle.Height == Height && filmRectangle.Width == Width) ||           // if any pairs of equal sides
                  (filmRectangle.Height == Width && filmRectangle.Width == Height));
        }

        /// <include file='docs.xml' path='docs/members[@name="filmrectangle"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Height, Width);
        }

        /// <include file='docs.xml' path='docs/members[@name="filmrectangle"]/ToString/*'/>
        public override string ToString()
        {
            return $"FilmRectangle. Id: {Id}. Height: {Height}. Width: {Width}.";
        }
    }
}
