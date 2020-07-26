﻿using ShapeClassLibrary;
using System;

namespace PersonClassLibrary
{
    public class Scissors
    {

        public Shape Cut(IPaper paper, params double[] parameters)
        {
            return parameters.Length switch
            {
                1 => new PaperCircle(parameters),
                2 => new PaperRectangle(parameters),
                3 => new PaperTriangle(parameters),
                _ => throw new ArgumentOutOfRangeException("Wrong number of parameters."),
            };
        }

        public Shape Cut(IFilm film, params double[] parameters)
        {
            return parameters.Length switch
            {
                1 => new FilmCircle(parameters),
                2 => new FilmRectangle(parameters),
                3 => new FilmTriangle(parameters),
                _ => throw new ArgumentOutOfRangeException("Wrong number of parameters."),
            };
        }

        public Shape Cut(Shape shape, params double[] parameters)
        {
            if (shape is IPaper)
            {
                return parameters.Length switch
                {
                    1 => new PaperCircle(parameters),
                    2 => new PaperRectangle(parameters),
                    3 => new PaperTriangle(parameters),
                    _ => throw new ArgumentOutOfRangeException("Wrong number of parameters."),
                };
            }

            else
            {
                return parameters.Length switch
                {
                    1 => new FilmCircle(parameters),
                    2 => new FilmRectangle(parameters),
                    3 => new FilmTriangle(parameters),
                    _ => throw new ArgumentOutOfRangeException("Wrong number of parameters."),
                };
            }
        }
    }
}
