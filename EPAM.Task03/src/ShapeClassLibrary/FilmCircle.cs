using System;
using System.Runtime.Serialization;

namespace ShapeClassLibrary
{
    [Serializable]
    public class FilmCircle : Shape, IFilm
    {
        public override int Id { get; set; }
        public double Radius { get; set; }

        public FilmCircle() { }

        public FilmCircle(params double[] parameters)
        {
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
    }
}
