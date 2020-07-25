using ShapeClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonClassLibrary
{
    public class Scissors
    {

        public Shape Cut(IPaper paper, params double[] parameters)
        {
            switch(parameters.Length)
            {
                case 1: return new PaperCircle(parameters);
                case 2: return new PaperRectangle(parameters);
                case 3: return new PaperTriangle(parameters);
                default: throw new ArgumentOutOfRangeException("Wrong number of parameters.");
            }
        }

        public Shape Cut(IFilm paper, params double[] parameters)
        {
            switch (parameters.Length)
            {
                case 1: return new PaperCircle(parameters);
                case 2: return new PaperRectangle(parameters);
                case 3: return new PaperTriangle(parameters);
                default: throw new ArgumentOutOfRangeException("Wrong number of parameters.");
            }
        }

        public Shape Cut(Shape shape, params double[] parameters)
        {
            if (shape is IPaper)
            {
                switch (parameters.Length)
                {
                    case 1: return new PaperCircle(parameters);
                    case 2: return new PaperRectangle(parameters);
                    case 3: return new PaperTriangle(parameters);
                    default: throw new ArgumentOutOfRangeException("Wrong number of parameters.");
                }
            }

            else
            {
                switch (parameters.Length)
                {
                    case 1: return new FilmCircle(parameters);
                    case 2: return new FilmRectangle(parameters);
                    case 3: return new FilmTriangle(parameters);
                    default: throw new ArgumentOutOfRangeException("Wrong number of parameters.");
                }
            }
        }
    }
}
