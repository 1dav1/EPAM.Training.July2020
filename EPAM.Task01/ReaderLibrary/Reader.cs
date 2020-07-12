using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ReaderLibrary
{
    public class Reader
    {
        public string Path { get; set; }
        public List<Shape> Shapes { private get; set; }

        public Reader(string path = "..\\..\\..\\..\\docs\\shapes.txt")
        {
            Path = path;
            Shapes = new List<Shape>();
        }

        public List<Shape> GetShapes()
        {
            if (File.Exists(Path))
            {
                string[] lines = File.ReadAllLines(Path);
                foreach (var line in lines)
                {
                    // parenthesis in the current line means the shape is described by coordinates 
                    if (line.Contains('('))
                    {
                        GetShapeByCoordinates(line);
                    }
                    // otherwise it is described by side length
                    else
                    {
                        GetShapeBySides(line);
                    }
                }
            }
            return Shapes;
        }

        private void GetShapeBySides(string line)
        {
            // get a collection of parameters of a shape
            string[] parameters = line.Split(";");

            // identifying the type of the shape 
            switch (parameters.Length)
            {
                case 1:
                    Shapes.Add(new Circle
                    {
                        Radius = Convert.ToDouble(parameters[0])
                    });
                    break;
                case 3:
                    Shapes.Add(new Triangle
                    {
                        Side1 = Convert.ToDouble(parameters[0]),
                        Side2 = Convert.ToDouble(parameters[1]),
                        Side3 = Convert.ToDouble(parameters[2])
                    });
                    break;
                case 4:
                    Shapes.Add(new Rectangle
                    {
                        Height = Convert.ToDouble(parameters[0]),
                        Width = Convert.ToDouble(parameters[2])
                    });
                    break;
                case 5:
                    Shapes.Add(new Pentagon
                    {
                        Side = Convert.ToDouble(parameters[0])
                    });
                    break;
            }
        }

        private void GetShapeByCoordinates(string line)
        {
            string[] coordinates = line.Split(";");
            Regex pattern = new Regex("[0-9]+");
            MatchCollection matches;

            // using inline declaration, because in case of 'using' directive I make my class 'Rectangle' ambiguous
            List<System.Drawing.Point> points = new List<System.Drawing.Point>();

            foreach (var c in coordinates)
            {
                // extract the coordinates from the string by pattern
                matches = pattern.Matches(c);
                points.Add(new System.Drawing.Point
                {
                    X = Convert.ToInt32(matches[0].Value),
                    Y = Convert.ToInt32(matches[1].Value)
                });
            }

            // identifying the type of the shape 
            switch (points.Count)
            {
                case 2:
                    Shapes.Add(new Circle
                    {
                        /* calculating the radius length from coordinates by formula: 
                         * distance = square root from ((x2 - x1) ^ 2 + (y2 - y1) ^ 2) */
                        Radius = Math.Sqrt(Math.Pow(points[1].X - points[0].X, 2) + Math.Pow(points[1].Y - points[0].Y, 2))
                    });
                    break;
                case 3:
                    Shapes.Add(new Triangle
                    {
                        Side1 = Math.Sqrt(Math.Pow(points[0].X - points[1].X, 2) + Math.Pow(points[0].Y - points[1].Y, 2)),
                        Side2 = Math.Sqrt(Math.Pow(points[1].X - points[2].X, 2) + Math.Pow(points[1].Y - points[2].Y, 2)),
                        Side3 = Math.Sqrt(Math.Pow(points[2].X - points[0].X, 2) + Math.Pow(points[2].Y - points[0].Y, 2))
                    });
                    break;
                case 4:
                    Shapes.Add(new Rectangle
                    {
                        Height = Math.Sqrt(Math.Pow(points[0].X - points[1].X, 2) + Math.Pow(points[0].Y - points[1].Y, 2)),
                        Width = Math.Sqrt(Math.Pow(points[1].X - points[2].X, 2) + Math.Pow(points[1].Y - points[2].Y, 2))
                    });
                    break;
                case 5:
                    Shapes.Add(new Pentagon
                    {
                        Side = Math.Sqrt(Math.Pow(points[0].X - points[1].X, 2) + Math.Pow(points[0].Y - points[1].Y, 2))
                    });
                    break;
            }
        }
    }
}
