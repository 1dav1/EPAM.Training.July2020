using ShapeClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (shape is null)
                throw new ArgumentNullException();

            if (Shapes.Count() == 20)
                throw new Exception("The box is full.");

            List<Shape> shapes = Shapes.ToList();

            // trying to find a shape with this ID in the box
            var sameShape = (from s in Shapes
                             where s.Id == shape.Id
                             select s).ToList();
            // if a shape with the same id is found, throw exception
            if (sameShape.Count != 0)
            {
                throw new Exception("The ID of the shape to push is not unique.");
            }

            shapes.Add(shape);
            Shapes = shapes;
        }

        public Shape FindById(int id)
        {
            var shape = from s in Shapes
                        where s.Id == id
                        select s;

            if (shape.Count() == 1)
                return shape.First();

            throw new Exception("The shape is not found.");
        }

        public Shape PullShapeById(int id)
        {
            var shape = from s in Shapes
                        where s.Id == id
                        select s;

            if (shape.Count() == 1)
            {
                // pass to the collection of shapes the old collection except the shape specified by id 
                Shapes = from s in Shapes
                         where s.Id != id
                         select s;

                // return the specified shape
                return shape.First();
            }

            throw new Exception("The shape is not found.");
        }

        public void ReplaceById(Shape shape, int id)
        {
            if (shape is null)
                throw new ArgumentNullException();

            // convert IEnumerable to List to be able to find an index of the item with the specified ID
            List<Shape> listOfShapes = Shapes.ToList();

            // select items with the specified ID
            var shapes = from s in listOfShapes
                         where s.Id == id
                         select s;

            if (shapes.Count() == 1)
            {
                // get the Shape object
                Shape targetShape = shapes.First();

                // get its index
                int index = listOfShapes.IndexOf(targetShape);

                // remove the target shape and insert the new spacified shape
                listOfShapes.RemoveAt(index);
                listOfShapes.Insert(index, shape);
                Shapes = listOfShapes;
            }
            else
                throw new Exception("The shape is not found.");
        }

        public IEnumerable<Shape> FindByTemplate(Shape template)
        {
            if (template is null)
                throw new ArgumentNullException();

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
        {
            var shapes = (from s in Shapes
                          where (s is PaperCircle) || (s is FilmCircle)
                          select s).ToList();

            if (shapes.Count() != 0)
            {
                // pass to the collection of shapes the old collection except the circles
                Shapes = from s in Shapes
                         where !(s is PaperCircle) && !(s is FilmCircle)
                         select s;
            }

            // return the found circles
            return shapes;
        }

        public IEnumerable<Shape> PullFilmShapes()
        {
            var shapes = (from s in Shapes
                          where s is IFilm
                          select s).ToList();

            if (shapes.Count() != 0)
            {
                // pass to the collection of shapes the old collection except the shapes of film
                Shapes = from s in Shapes
                         where !(s is FilmCircle) && !(s is FilmRectangle) && !(s is FilmTriangle)
                         select s;
            }

            // return the found shapes of film
            return shapes;
        }

        public void WriteAllToXmlStreamWriter(string file)
        {
            if (file is null)
                throw new ArgumentNullException();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Shape>));

            using TextWriter textWriter = new StreamWriter(file);
            xmlSerializer.Serialize(textWriter, Shapes);
        }

        public void WritePaperToXmlStreamWriter(string file)
        {
            if (file is null)
                throw new ArgumentNullException();

            var paperShapes = (from s in Shapes
                               where s is IPaper
                               select s).ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Shape>));

            using TextWriter textWriter = new StreamWriter(file);
            xmlSerializer.Serialize(textWriter, paperShapes);
        }

        public void WriteFilmToXmlStreamWriter(string file)
        {
            if (file is null)
                throw new ArgumentNullException();

            var filmShapes = (from s in Shapes
                              where s is IFilm
                              select s).ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Shape>));

            using TextWriter textWriter = new StreamWriter(file);
            xmlSerializer.Serialize(textWriter, filmShapes);
        }

        public void WriteAllToXmlXmlWriter(string file)
        {
            if (file is null)
                throw new ArgumentNullException();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Shape>));
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true
            };

            using XmlWriter xmlWriter = XmlWriter.Create(file, settings);
            xmlSerializer.Serialize(xmlWriter, Shapes.ToList());
        }

        public void WritePaperToXmlXmlWriter(string file)
        {
            if (file is null)
                throw new ArgumentNullException();

            var paperShapes = (from s in Shapes
                               where s is IPaper
                               select s).ToList();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Shape>));
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true
            };

            using XmlWriter xmlWriter = XmlWriter.Create(file, settings);
            xmlSerializer.Serialize(xmlWriter, paperShapes);
        }

        public void WriteFilmToXmlXmlWriter(string file)
        {
            if (file is null)
                throw new ArgumentNullException();

            var filmShapes = (from s in Shapes
                              where s is IFilm
                              select s).ToList();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Shape>));
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true
            };

            using XmlWriter xmlWriter = XmlWriter.Create(file, settings);
            xmlSerializer.Serialize(xmlWriter, filmShapes);
        }

        public void ReadAllFromXmlStreamReader(string file)
        {
            if (file is null)
                throw new ArgumentNullException();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Shape>));
            using StreamReader reader = new StreamReader(file);
            List<Shape> list = (List<Shape>)serializer.Deserialize(reader);

            Shapes = list;
        }

        public void ReadAllFromXmlXmlReader(string file)
        {
            if (file is null)
                throw new ArgumentNullException();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Shape>));
            using XmlReader xmlReader = XmlReader.Create(file);
            List<Shape> shapes = (List<Shape>)xmlSerializer.Deserialize(xmlReader);
            Shapes = shapes;
        }
    }
}
