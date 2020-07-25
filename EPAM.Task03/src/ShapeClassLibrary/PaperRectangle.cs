﻿using System;

namespace ShapeClassLibrary
{
    public class PaperRectangle : Shape, IPaper
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public Colors Color { get; set; }

        public PaperRectangle() { }

        public PaperRectangle(params double[] parameters)
        {
            Height = parameters[0];
            Width = parameters[1];
        }

        public PaperRectangle(Shape parentShape, params double[] paramaters)
        {
            double area = paramaters[0] * paramaters[1];

            if (parentShape.GetArea() < area)
                throw new Exception("The area of the derived shape should be less than the area of the parent shape.");

            Height = paramaters[0];
            Width = paramaters[1];
        }

        public double GetPerimeter()
            => (Height + Width) * 2;

        public override double GetArea()
            => Height * Width;
    }
}
