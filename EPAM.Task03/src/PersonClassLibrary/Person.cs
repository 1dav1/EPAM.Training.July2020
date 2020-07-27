using System;
using System.Collections.Generic;
using ShapeClassLibrary;

namespace PersonClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="person"]/Person/*'/>
    public class Person
    {
        /// <include file='docs.xml' path='docs/members[@name="person"]/Color/*'/>
        public Colors Color { get; private set; }

        private static Box Box { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="person"]/Constructor1/*'/>
        public Person()
        {
            Color = Colors.None;
            Box = new Box();
        }

        /// <include file='docs.xml' path='docs/members[@name="person"]/Constructor2/*'/>
        public Person(Box box)
        {
            Box = box;
        }

        /// <include file='docs.xml' path='docs/members[@name="person"]/SetColor/*'/>
        public void SetColor(Colors color)
        {
            Color = color;
        }

        /// <include file='docs.xml' path='docs/members[@name="person"]/ColorShape/*'/>
        public Shape ColorShape(Shape shape)
        {
            if (shape is null)
                throw new ArgumentNullException();

            // if color is not set, throw exception
            if (Color == Colors.None)
                throw new Exception("Choose a color.");

            // if the specified shape is of paper, it can be colored
            if (shape is IPaper paper)
            {
                if (paper.Color != Colors.None)
                    throw new Exception("The shape is already colored.");

                paper.Color = Color;
                return shape;
            }

            // otherwise throw exception
            throw new ArgumentException("Film shapes cannot be colored.");
        }

        // cut from paper
        /// <include file='docs.xml' path='docs/members[@name="person"]/CutShape/*'/>
        public Shape CutShape(IPaper material, params double[] parameters)
        {
            return Scissors.Cut(material, parameters);
        }

        // cut from film
        /// <include file='docs.xml' path='docs/members[@name="person"]/CutShape/*'/>
        public Shape CutShape(IFilm material, params double[] parameters)
        {
            return Scissors.Cut(material, parameters);
        }

        /// <include file='docs.xml' path='docs/members[@name="person"]/CutShapeFromShape/*'/>
        public Shape CutShapeFromShape(Shape shape, params double[] parameters)
        {
            return Scissors.Cut(shape, parameters);
        }

        /// <include file='docs.xml' path='docs/members[@name="person"]/PutShapeToBox/*'/>
        public void PutShapeToBox(Shape shape)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.PushShape(shape);
        }

        /// <include file='docs.xml' path='docs/members[@name="person"]/FindShapeById/*'/>
        public Shape FindShapeById(int id)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.FindById(id);
        }

        /// <include file='docs.xml' path='docs/members[@name="person"]/GetShapeById/*'/>
        public Shape GetShapeById(int id)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.PullShapeById(id);
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/ReplaceById/*'/>
        public void ReplaceShapeById(Shape shape, int id)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.ReplaceById(shape, id);
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/FindByTemplate/*'/>
        public IEnumerable<Shape> FindShapeByTemplate(Shape template)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.FindByTemplate(template);
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/Count/*'/>
        public int CountShapes()
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.Count();
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/GetTotalArea/*'/>
        public double GetTotalArea()
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.GetTotalArea();
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/GetTotalPerimeter/*'/>
        public double GetTotalPerimeter()
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.GetTotalPerimeter();
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/PullCircles/*'/>
        public IEnumerable<Shape> PullAllCircles()
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.PullCircles();
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/PullFilmShapes/*'/>
        public IEnumerable<Shape> PullAllFilmShapes()
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            return Box.PullFilmShapes();
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/AllStreamWriter/*'/>
        public void SaveAllToXmlViaStreamWriter(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.WriteAllToXmlStreamWriter(file);
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/PaperStreamWriter/*'/>
        public void SavePaperToXmlViaStreamWriter(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.WritePaperToXmlStreamWriter(file);
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/FilmStreamWriter/*'/>
        public void SaveFilmToXmlViaStreamWriter(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.WriteFilmToXmlStreamWriter(file);
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/AllXmlWriter/*'/>
        public void SaveAllToXmlViaXmlWriter(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.WriteAllToXmlXmlWriter(file);
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/PaperXmlWriter/*'/>
        public void SavePaperToXmlViaXmlWriter(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.WritePaperToXmlXmlWriter(file);
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/FilmXmlWriter/*'/>
        public void SaveFilmToXmlViaXmlWriter(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.WriteFilmToXmlXmlWriter(file);
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/AllStreamReader/*'/>
        public void LoadAllFromXmlViaStreamReader(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.ReadAllFromXmlStreamReader(file);
        }

        /// <include file='docs.xml' path='docs/members[@name="box"]/AllXmlReader/*'/>
        public void LoadAllFromXmlViaXmlReader(string file)
        {
            if (Box == null)
                throw new Exception("The girl has no box.");

            Box.ReadAllFromXmlXmlReader(file);
        }
    }
}
