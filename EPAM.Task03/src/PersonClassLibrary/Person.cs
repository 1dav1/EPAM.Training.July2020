using System;
using ShapeClassLibrary;

namespace PersonClassLibrary
{
    public class Person
    {
        private Scissors Scissors { get; set; }

        private Brush Brush { get; set; }

        private Box Box { get; set; }

        public Person()
        {
            Scissors = new Scissors();
            Brush = new Brush();
            Box = new Box();
        }

        public void SetColor(Colors color)
        {
            Brush.Color = color;
        }

        public Shape ColorShape(Shape shape)
        {

            if (shape is IPaper paper)
            {
                paper.Color = Brush.Color;
                return shape;
            }

            throw new Exception("Film shapes cannot be colored.");
        }

        public Shape CutShape(IPaper material, params double[] parameters)
            => Scissors.Cut(material, parameters);

        public Shape CutShape(IFilm material, params double[] parameters)
            => Scissors.Cut(material, parameters);

        public Shape CutShapeFromShape(Shape shape, params double[] parameters)
            => Scissors.Cut(shape, parameters);


        
    }
}
