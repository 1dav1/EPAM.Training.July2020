using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ShapeClassLibrary
{
    [Serializable]
    [XmlType("PaperCircle")]
    public class PaperCircle : Shape, IPaper
    {
        public override int Id { get; set; }
        public double Radius { get; set; }

        public Colors Color { get; set; }

        public PaperCircle() { }

        public PaperCircle(params double[] parameters)
        {
            Radius = parameters[0];
        }

        public PaperCircle(Shape shape, params double[] parameters)
        {
            double area = Math.PI * Math.Pow(parameters[0], 2);
            if (shape.GetArea() < area)
                throw new Exception("The area of the derived shape should be less than the area of the parent shape.");

            Radius = parameters[0];
        }

        public override double GetPerimeter()
            => 2 * Math.PI * Radius;

        public override double GetArea()
            => Math.PI * Math.Pow(Radius, 2);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            return obj is PaperCircle paperCircle &&
                paperCircle.Id == Id &&
                paperCircle.Radius == Radius &&
                paperCircle.Color == Color;
        }

    }
}
