using System;
using System.Xml.Serialization;

namespace ShapeClassLibrary
{
    [XmlRoot(ElementName = "shape")]
    [XmlInclude(typeof(PaperCircle))]
    [XmlInclude(typeof(PaperRectangle))]
    [XmlInclude(typeof(PaperTriangle))]
    [XmlInclude(typeof(FilmCircle))]
    [XmlInclude(typeof(FilmRectangle))]
    [XmlInclude(typeof(FilmTriangle))]
    public abstract class Shape
    {
        //public abstract Shape() { }
        //public abstract Shape(Shape parentShape, params double[] parameters);

        public abstract int Id { get; set; }

        public abstract double GetArea();

        public abstract double GetPerimeter();
    }
}
