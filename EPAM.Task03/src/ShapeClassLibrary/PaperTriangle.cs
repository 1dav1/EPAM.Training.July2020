using System;
using System.Xml.Serialization;

namespace ShapeClassLibrary
{
    [Serializable]
    [XmlType("PaperTriangle")]
    public class PaperTriangle : Shape, IPaper
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

        public Colors Color { get; set; }

        public PaperTriangle() 
        {
            Color = Colors.None;
        }

        public PaperTriangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        public PaperTriangle(Shape parentShape, double side1, double side2, double side3)
        {
            if (parentShape is IFilm)
                throw new ArgumentException("Parent shape is of wrong material.");

            double p = (side1 + side2 + side3) / 2;
            double area = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));

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

            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        public override double GetPerimeter()
            => Side1 + Side2 + Side3;

        public override double GetArea()
        {
            double p = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            return obj is PaperTriangle paperTriangle &&
                   paperTriangle.Side1 == Side1 &&
                   paperTriangle.Side2 == Side2 &&
                   paperTriangle.Side3 == Side3 &&
                   paperTriangle.Color == Color;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Id, Side1, Side2, Side3, Color);
        }

        public override string ToString()
        {
            return $"PaperTriangle. Id: {Id}. Side1: {Side1}. Side2: {Side2}. Side3: {Side3}. Color: {Color}.";
        }
    }
}
