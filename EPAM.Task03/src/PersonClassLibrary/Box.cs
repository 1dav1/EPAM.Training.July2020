using ShapeClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonClassLibrary
{
    public class Box
    {
        public IEnumerable<Shape> Shapes { get; set; }

        public Box()
        {
            Shapes = new List<Shape>();
        }
    }
}
