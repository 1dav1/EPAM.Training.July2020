using FilmClassLibrary;
using PaperClassLibrary;
using ShapeClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonClassLibrary
{
    public class Brush
    {
        public void SetColor(IColorable shape, Colors color)
        {
            shape.Color = color;
        }
    }
}
