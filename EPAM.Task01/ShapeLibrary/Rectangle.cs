using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLibrary
{
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override double GetArea()
        {
            return Height * Width;
        }

        public override double GetPerimeter()
        {
            return (Height + Width) * 2;
        }

        public override void ToString()
        {
            Console.WriteLine("Height = {0}", Height);
            Console.WriteLine("Width = {1}", Width);
        }
    }
}
