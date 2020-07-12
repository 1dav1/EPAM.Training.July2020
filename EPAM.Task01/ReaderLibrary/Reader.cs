using ShapeLibrary;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace ReaderLibrary
{
    public class Reader
    {
        public string Path { get; set; }
        public List<Shape> Shapes { private get; set; }

        public Reader(string path = "shapes.txt")
        {
            Path = path;
        }

        public List<Shape> GetShapes()
        {
            if (File.Exists(Path))
            {
                string[] lines = File.ReadAllLines(Path);
                foreach (var line in lines)
                {
                    if (line.Contains('('))
                    {
                        GetShapeByCoordinates(line);
                    }
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
            string[] parameters = line.Split(";");
            switch (parameters.Length)
            {
                case 1:
                    Shapes.Add(new Circle
                    {
                        Radius = Convert.ToDouble(parameters[0])
                    });
                    break;
                case 3:
                    Shapes.Add(new Traingle
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
                    //Regex regex = new Regex("(?<=/=)/d+$");
                    //Match match = regex.Match(parameters[4]);
                    //double apothem = Convert.ToDouble(match.Value);
                    Shapes.Add(new Pentagon
                    {
                        //Apothem = apothem,
                        Side = Convert.ToDouble(parameters[0])
                    });
                    break;
            }
        }

        private void GetShapeByCoordinates(string line)
        {
            string[] coordinates = line.Split(";");
            //string substring = "";
            
            //if(coordinates.Length == 5)
            //{
            //    substring = coordinates[5];
            //    coordinates[5] = null;
            //}
            Regex regex = new Regex("/d+");
            MatchCollection matches;

            // using inline declaration, because in case of 'using' directive I make my class 'Rectangle' ambiguous
            List<System.Drawing.Point> points = new List<System.Drawing.Point>();

            foreach (var c in coordinates)
            {
                matches = regex.Matches(c);
                points.Add(new System.Drawing.Point
                {
                    X = Convert.ToInt32(matches[0].Value),
                    Y = Convert.ToInt32(matches[1].Value)
                });
            }

            switch (points.Count)
            {
                case 2:
                    Shapes.Add(new Circle
                    {
                        Radius = Math.Sqrt(Math.Pow(points[0].X - points[1].X, 2) + Math.Pow(points[0].Y - points[1].Y, 2))
                    });
                    break;
                case 3:
                    Shapes.Add(new Traingle
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
                    //regex = new Regex("(?<=/=)/d+$");
                    //Match match = regex.Match(substring);
                    //double apothem = Convert.ToDouble(match.Value);
                    Shapes.Add(new Pentagon
                    {
                        //Apothem = apothem,
                        Side = Math.Sqrt(Math.Pow(points[0].X - points[1].X, 2) + Math.Pow(points[0].Y - points[1].Y, 2))
                    });
                    break;
            }
        }

    }
}
