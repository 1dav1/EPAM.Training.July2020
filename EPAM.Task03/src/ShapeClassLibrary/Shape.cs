using System;

namespace ShapeClassLibrary
{
    public class Shape : IFilm, IPaper
    {
        public Colors Color { get; set; }

        public double? GetArea()
        {
            return null;
        }
    }
}
