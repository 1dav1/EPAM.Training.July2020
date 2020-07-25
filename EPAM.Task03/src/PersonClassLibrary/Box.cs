using ShapeClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace PersonClassLibrary
{
    public class Box
    {
        public IEnumerable<Shape> Shapes { get; set; }

        public Box()
        {
            Shapes = new List<Shape>();
        }

        public void PushShape(Shape shape)
        {
            Shapes.Append(shape);
        }

        public Shape FindById(int id)
        {
            var shape = from s in Shapes
                        where s.Id == id
                        select s;

            // if id is unique and only one shape is found
            if (shape.Count() == 1)
                return shape.First();

            // otherwise throw exception
            throw new Exception("The ID is not unique.");
        }

        public Shape PullShapeById(int id)
        {
            var shape = from s in Shapes
                        where s.Id == id
                        select s;

            // if ID is unique and only one shape is found
            if (shape.Count() == 1)
            {
                // select all the shapes in the collection except the shape specified by id 
                Shapes = from s in Shapes
                         where s.Id != id
                         select s;

                // return the specified shape
                return shape.First();
            }

            // otherwise throw exception
            throw new Exception("The ID is not unique.");
        }

        public void ReplaceById(Shape shape, int id)
        {
            // convert IEnumerable to List to be able to find an index of the item with the specified ID
            List<Shape> listOfShapes = Shapes.ToList();

            // select items with the specified ID
            var shapes = from s in listOfShapes
                         where s.Id == id
                         select s;

            // if ID is unique and only one item is found
            if (shapes.Count() == 1)
            {
                // get the Shape object
                Shape targetShape = shapes.First();

                // get its index
                int index = listOfShapes.IndexOf(targetShape);

                // remove the target shape and insert the new spacified shape
                listOfShapes.RemoveAt(index);
                listOfShapes.Insert(index, shape);
            }
            else
                // otherwise throw exception
                throw new Exception("The ID is not unique.");
        }

        public IEnumerable<Shape> FindByTemplate(Shape template)
        {
            // convert into List to be able to use FindAll() method
            List<Shape> listOfShapes = Shapes.ToList();
            return listOfShapes.FindAll(s => s.Equals(template));
        }

        public int Count()
            => Shapes.Count();

        public double GetTotalArea()
            => (from s in Shapes
                select s.GetArea()).Sum();

        public double GetTotalPerimeter()
            => (from s in Shapes
                select s.GetPerimeter()).Sum();

        public IEnumerable<Shape> PullCircles()
            => from s in Shapes
               where (s is PaperCircle) || (s is FilmCircle)
               select s;

        public IEnumerable<Shape> PullFilmShapes()
            => from s in Shapes
               where s is IFilm
               select s;

        public void WriteAllToXmlStreamWriter(string file)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(IEnumerable<Shape>));

            using TextWriter textWriter = new StreamWriter(file);
            xmlSerializer.Serialize(textWriter, Shapes);
        }

        public void WritePaperToXmlStreamWriter(string file)
        {
            var paperShapes = from s in Shapes
                              where s is IPaper
                              select s;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(IEnumerable<Shape>));

            using TextWriter textWriter = new StreamWriter(file);
            xmlSerializer.Serialize(textWriter, paperShapes);
        }

        public void WriteFilmToXmlStreamWriter(string file)
        {
            var filmShapes = from s in Shapes
                             where s is IFilm
                             select s;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(IEnumerable<Shape>));

            using TextWriter textWriter = new StreamWriter(file);
            xmlSerializer.Serialize(textWriter, filmShapes);
        }

        public void WriteAllToXmlXmlWriter(string file)
        {
            using XmlWriter xmlWriter = XmlWriter.Create(file);
        }
    }
}
