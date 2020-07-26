using System;
using System.Collections.Generic;
using ShapeClassLibrary;

namespace PersonClassLibrary
{
    public class Person
    {
        private static Scissors Scissors { get; set; }

        private static Brush Brush { get; set; }

        private static Box Box { get; set; }

        public Person() { }

        public Person(Scissors scissors, Brush brush, Box box)
        {
            Scissors = scissors;
            Brush = brush;
            Box = box;
        }

        public void SetColor(Colors color)
        {
            if (Brush == null)
                throw new Exception("The girl has no brush.");

            Brush.Color = color;
        }

        public Shape ColorShape(Shape shape)
        {
            if (Brush == null)
                throw new Exception("The girl has no brush.");

            // if color is not set, throw exception
            if (Brush.Color == Colors.None)
                throw new Exception("Choose a color.");

            // if the specified shape is of paper, it can be colored
            if (shape is IPaper paper)
            {
                paper.Color = Brush.Color;
                return shape;
            }

            // otherwise throw exception
            throw new Exception("Film shapes cannot be colored.");
        }

        // cut from paper
        public Shape CutShape(IPaper material, params double[] parameters)
        {
            if (Scissors == null)
                throw new Exception("The girl has no scissors.");

            return Scissors.Cut(material, parameters);
        }

        // cut from film
        public Shape CutShape(IFilm material, params double[] parameters)
        {
            if (Scissors == null)
                throw new Exception("The girl has no scissors.");

            return Scissors.Cut(material, parameters);
        }

        public Shape CutShapeFromShape(Shape shape, params double[] parameters)
        {
            if (Scissors == null)
                throw new Exception("The girl has no scissors.");

            return Scissors.Cut(shape, parameters);
        }

        public void PutShapeToBox(Shape shape)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.PushShape(shape);
        }

        public Shape FindShapeById(int id)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.FindById(id);
        }

        public Shape GetShapeById(int id)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.PullShapeById(id);
        }

        public void ReplaceShapeById(Shape shape, int id)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.ReplaceById(shape, id);
        }

        public IEnumerable<Shape> FindShapeByTemplate(Shape template)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.FindByTemplate(template);
        }

        public int CountShapes()
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.Count();
        }

        public double GetTotalArea()
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.GetTotalArea();
        }

        public double GetTotalPerimeter()
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.GetTotalPerimeter();
        }

        public IEnumerable<Shape> PullAllCircles()
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.PullCircles();
        }

        public IEnumerable<Shape> PullAllFilmShapes()
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.PullFilmShapes();
        }

        public void SaveAllToXmlViaStreamWriter(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.WriteAllToXmlStreamWriter(file);
        }

        public void SavePaperToXmlViaStreamWriter(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.WritePaperToXmlStreamWriter(file);
        }

        public void SaveFilmToXmlViaStreamWriter(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.WriteFilmToXmlStreamWriter(file);
        }

        public void SaveAllToXmlViaXmlWriter(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.WriteAllToXmlXmlWriter(file);
        }

        public void SavePaperToXmlViaXmlWriter(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.WritePaperToXmlXmlWriter(file);
        }

        public void SaveFilmToXmlViaXmlWriter(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.WriteFilmToXmlXmlWriter(file);
        }

        public void LoadAllFromXmlViaStreamReader(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.ReadAllFromXmlStreamReader(file);
        }

        public void LoadAllFromXmlViaXmlReader(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.ReadAllFromXmlXmlReader(file);
        }
    }
}
