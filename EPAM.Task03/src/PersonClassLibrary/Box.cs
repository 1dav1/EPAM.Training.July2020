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

            List<Shape> shapes = Shapes.ToList();

            if (shapes.Count == 20)
                throw new Exception("The box is full.");

            shapes.Add(shape);
            Shapes = shapes;
        }

        public Shape FindById(int id)
        {
            var shape = from s in Shapes
                        where s.Id == id
                        select s;

            // if id is unique and only one shape is found
            if (shape.Count() == 1)
                return shape.First();

            if (shape.Count() == 0)
                throw new Exception("The shape is not found.");

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
            if (shape is null)
                throw new ArgumentNullException();

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
                Shapes = listOfShapes;
            }
            else
                // otherwise throw exception
                throw new Exception("The ID is not unique.");
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
            => from s in Shapes
               where (s is PaperCircle) || (s is FilmCircle)
               select s;

        public IEnumerable<Shape> PullFilmShapes()
            => from s in Shapes
               where s is IFilm
               select s;

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
