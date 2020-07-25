using System;

namespace ShapeClassLibrary
{
    public class FilmRectangle : Shape, IFilm
    {
        public override int Id { get; set; }
        public double Height { get; set; }

        public double Width { get; set; }

        public FilmRectangle() { }

        public FilmRectangle(params double[] parameters) 
        {
            Height = parameters[0];
            Width = parameters[1];
        }

        public FilmRectangle(Shape parentShape, params double[] paramaters)
        {
            double area = paramaters[0] * paramaters[1];

            if (parentShape.GetArea() < area)
                throw new Exception("The area of the derived shape should be less than the area of the parent shape.");

            Height = paramaters[0];
            Width = paramaters[1];
        }

        public override double GetPerimeter()
           => (Height + Width) * 2;

        public override double GetArea()
           => Height * Width;
    }
}
