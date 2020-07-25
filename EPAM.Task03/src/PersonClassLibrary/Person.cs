using System;
using ShapeClassLibrary;

namespace PersonClassLibrary
{
    public class Person
    {
        public Scissors Scissors { get; set; }

        public Brush Brush { get; private set; }

        public IPaper Paper { get; set; }

        public IFilm Film { get; set; }


        public Person()
        {
            Paper = new Shape();
            Film = new Shape();
        }

        public void TakeBrush(Brush brush)
        {
            Brush = brush;
        }

        public void TakeScissors(Scissors scissors)
        {
            Scissors = scissors;
        }

        public Shape GetShape(Shape shape, params double[] parameters)
        {

        }
    }
}
