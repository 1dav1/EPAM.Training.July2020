using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeClassLibrary
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public new double GetArea()
            => Math.PI * Math.Pow(Radius, 2);
    }
}
