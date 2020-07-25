using ShapeClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonClassLibrary
{
    public class Scissors
    {
        public Shape Cut(Shape shape, params double[] parameters)
        {
            Shape shape1;
            if (shape is IFilm)
            { 
                IFilm resultShape = new Shape();
                shape1 = (Shape)resultShape;
            }
            else
            {
                IPaper resultShape = new Shape();
                shape1 = (Shape)resultShape;
            }

            if (shape.GetArea() < shape1.GetArea())
            {
                throw new Exception("Cutting a shape of a bigger area is not possible.");
            }

            return shape1;
        }
    }
}
