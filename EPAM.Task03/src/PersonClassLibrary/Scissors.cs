using ShapeClassLibrary;
using System;

namespace PersonClassLibrary
{
    public static class Scissors
    {
        public static Shape Cut(IPaper paper, params double[] parameters)
        {
            if (paper is null)
                throw new ArgumentNullException();

            return parameters.Length switch
            {
                1 => new PaperCircle(parameters[0]),
                2 => new PaperRectangle(parameters[0], parameters[1]),
                3 => new PaperTriangle(parameters[0], parameters[1], parameters[2]),
                _ => throw new ArgumentOutOfRangeException("Wrong number of parameters."),
            };
        }

        public static Shape Cut(IFilm film, params double[] parameters)
        {
            if (film is null)
                throw new ArgumentNullException();

            return parameters.Length switch
            {
                1 => new FilmCircle(parameters[0]),
                2 => new FilmRectangle(parameters[0], parameters[1]),
                3 => new FilmTriangle(parameters[0], parameters[1], parameters[2]),
                _ => throw new ArgumentOutOfRangeException("Wrong number of parameters."),
            };
        }

        public static Shape Cut(Shape shape, params double[] parameters)
        {
            if (shape is null)
                throw new ArgumentNullException();

            if (shape is IPaper)
            {
                return parameters.Length switch
                {
                    1 => new PaperCircle(shape, parameters[0]),
                    2 => new PaperRectangle(shape, parameters[0], parameters[1]),
                    3 => new PaperTriangle(shape, parameters[0], parameters[1], parameters[2]),
                    _ => throw new ArgumentOutOfRangeException("Wrong number of parameters."),
                };
            }

            else
            {
                return parameters.Length switch
                {
                    1 => new FilmCircle(shape, parameters[0]),
                    2 => new FilmRectangle(shape, parameters[0], parameters[1]),
                    3 => new FilmTriangle(shape, parameters[0], parameters[1], parameters[2]),
                    _ => throw new ArgumentOutOfRangeException("Wrong number of parameters."),
                };
            }
        }
    }
}
