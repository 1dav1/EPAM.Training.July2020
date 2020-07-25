using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ShapeClassLibrary
{
    public enum Colors
    {
        Red,
        Blue,
        Green,
        Yellow,
        Black,
        White,
        Grey,
    }
    public interface IPaper
    {
        public Colors Color { get; set; }
    }
}
