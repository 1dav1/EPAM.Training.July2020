using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace ShapeLibrary
{
    // The class converts text strings with parameters of plane figures to a list of geometrical shapes.

    /// <include file='docs.xml' path='docs/members[@name="shapeFactory"]/ShapeFactory/*'/>
    public class ShapeFactory
    {
        /// <include file='docs.xml' path='docs/members[@name="shapeFactory"]/Shapes/*'/>
        public IEnumerable<Shape> Shapes { get; }

        /// <include file='docs.xml' path='docs/members[@name="shapeFactory"]/GetShapes/*'/>
        public IEnumerable<Shape> GetShapes(string[] lines)
        {
            IEnumerable<Shape> shapes = new List<Shape>();

            /* sorting the passed array (lines) making two arrays of strings: 
             * strings containing coordinates and 
             * string containing lengths */
            var listOfCoordinates = from l in lines
                                    where l.Contains('(')
                                    select l;

            var listOfLengths = from l in lines
                                where !l.Contains('(')
                                select l;

            foreach (var l in listOfCoordinates)
            {
                shapes.Append(GetShapeByCoordinates(l));
            }

            foreach (var l in listOfLengths)
            {
                shapes.Append(GetShapeBySides(l));
            }

            return shapes;
        }

        private Shape GetShapeBySides(string line)
        {
            // getting a collection of parameters of a shape
            string[] parameters = line.Split(";");

            // identifying the type of the shape 
            return parameters.Length switch
            {
                1 => new Circle
                {
                    Radius = Convert.ToDouble(parameters[0])
                },
                3 => new Triangle
                {
                    Side1 = Convert.ToDouble(parameters[0]),
                    Side2 = Convert.ToDouble(parameters[1]),
                    Side3 = Convert.ToDouble(parameters[2])
                },
                4 => new Rectangle
                {
                    Height = Convert.ToDouble(parameters[0]),
                    Width = Convert.ToDouble(parameters[2])
                },
                5 => new Pentagon
                {
                    Side = Convert.ToDouble(parameters[0])
                },
                _ => throw new ArgumentOutOfRangeException("Undefined shape type."),
            };
        }

        private Shape GetShapeByCoordinates(string line)
        {
            // splitting the passed string to get pairs of coordinates
            string[] coordinates = line.Split(";");

            // setting pattern to parse the passed string and get the coordinates of the shape
            Regex pattern = new Regex("[0-9]+");
            MatchCollection matches;

            // using inline declaration, because in case of 'using' directive I make my class 'Rectangle' ambiguous
            IEnumerable<Point> points = new List<Point>();

            foreach (var c in coordinates)
            {
                // extract the coordinates from the string by pattern
                matches = pattern.Matches(c);
                points.Append(new Point
                {
                    X = Convert.ToInt32(matches[0].Value),
                    Y = Convert.ToInt32(matches[1].Value)
                });
            }

            // identifying the type of the shape 
            return points.Count() switch
            {
                2 => new Circle
                {
                    /* calculating the radius length from coordinates by formula: 
                     * distance = square root from ((x2 - x1) ^ 2 + (y2 - y1) ^ 2) */
                    Radius = GetLengthByCoordinates(points.ElementAt(0), points.ElementAt(1))
                },
                3 => new Triangle
                {
                    Side1 = GetLengthByCoordinates(points.ElementAt(0), points.ElementAt(1)),
                    Side2 = GetLengthByCoordinates(points.ElementAt(1), points.ElementAt(2)),
                    Side3 = GetLengthByCoordinates(points.ElementAt(2), points.ElementAt(0)),
                },
                4 => new Rectangle
                {
                    Height = GetLengthByCoordinates(points.ElementAt(0), points.ElementAt(1)),
                    Width = GetLengthByCoordinates(points.ElementAt(1), points.ElementAt(2)),
                },
                5 => new Pentagon
                {
                    Side = GetLengthByCoordinates(points.ElementAt(0), points.ElementAt(1)),
                },
                _ => throw new ArgumentOutOfRangeException("Undefined shape type."),
            };
        }

        private double GetLengthByCoordinates(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }

        /// <include file='docs.xml' path='docs/members[@name="shapeFactory"]/GetEqualShapes/*'/>
        public IEnumerable<Shape> GetEqualShapes(Shape shape, IEnumerable<Shape> shapes)
        {
            IEnumerable<Shape> equalShapes = new List<Shape>();
            foreach (var s in shapes)
            {
                if (s.Equals(shape))
                    equalShapes.Append(s);
            }

            return equalShapes;
        }
    }
}
