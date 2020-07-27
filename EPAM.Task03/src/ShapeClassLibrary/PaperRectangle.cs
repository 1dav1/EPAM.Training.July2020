using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ShapeClassLibrary
{
    [Serializable]
    [XmlType("PaperRectangle")]
    public class PaperRectangle : Shape, IPaper
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

        public Colors Color { get; set; }

        public PaperRectangle() 
        {
            Color = Colors.None;
        }

        public PaperRectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public PaperRectangle(Shape parentShape, double height, double width)
        {
            if (parentShape is IFilm)
                throw new ArgumentException("Parent shape is of wrong material.");

            double area = height * width;
            if (parentShape.GetArea() < area)
                throw new Exception("The area of the derived shape should be less than the area of the parent shape.");

            // down-casting the parent shape to get property 'Color'
            if (parentShape is PaperCircle paperCircle)
            {
                Color = paperCircle.Color;
            }
            else if (parentShape is PaperRectangle paperRectangle)
            {
                Color = paperRectangle.Color;
            }
            else
            {
                PaperTriangle paperTriangle = (PaperTriangle)parentShape;
                Color = paperTriangle.Color;
            }

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

            return obj is PaperRectangle paperRectangle &&
                 ((paperRectangle.Height == Height && paperRectangle.Width == Width) ||           // if any pairs of equal sides
                  (paperRectangle.Height == Width && paperRectangle.Width == Height)) &&
                   paperRectangle.Color == Color;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Height, Width, Color);
        }
    }
}
