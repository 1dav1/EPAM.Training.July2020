using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ShapeClassLibrary
{
    [Serializable]
    [XmlType("PaperTriangle")]
    public class PaperTriangle : Shape, IPaper
    {
        public override int Id { get; set; }
        public double Side1 { get; set; }

        public double Side2 { get; set; }

        public double Side3 { get; set; }

        public Colors Color { get; set; }

        public PaperTriangle() { }

        public PaperTriangle(params double[] parameters)
        {
            Side1 = parameters[0];
            Side2 = parameters[1];
            Side3 = parameters[2];
        }

        public PaperTriangle(Shape parentShape, params double[] parameters)
        {
            double p = (parameters[0] + parameters[1] + parameters[2]) / 2;

            double area = Math.Sqrt(p * (p - parameters[0]) * (p - parameters[1]) * (p - parameters[2]));

            if (parentShape.GetArea() < area)
                throw new Exception("The area of the derived shape should be less than the area of the parent shape.");

            Side1 = parameters[0];
            Side2 = parameters[1];
            Side3 = parameters[2];
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
