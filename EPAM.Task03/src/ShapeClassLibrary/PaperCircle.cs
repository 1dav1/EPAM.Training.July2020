using System;

namespace ShapeClassLibrary
{
    public class PaperCircle : Shape, IPaper
    {
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

        public double GetCircumference()
            => 2 * Math.PI * Radius;

        public override double GetArea()
            => Math.PI * Math.Pow(Radius, 2);
    }
}
