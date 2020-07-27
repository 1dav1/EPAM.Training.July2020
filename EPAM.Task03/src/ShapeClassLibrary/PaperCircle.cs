using System;
using System.Xml.Serialization;

namespace ShapeClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="papercircle"]/PaperCircle/*'/>
    [Serializable]
    [XmlType("PaperCircle")]
    public class PaperCircle : Shape, IPaper
    {
        private int _id;
        /// <include file='docs.xml' path='docs/members[@name="papercircle"]/Id/*'/>
        public override int Id 
        { 
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("ID should be non-negative.");
            }
        }

        private double _radius;
        /// <include file='docs.xml' path='docs/members[@name="papercircle"]/Radius/*'/>
        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Radius should be posisitve.");
                _radius = value;
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="papercircle"]/Color/*'/>
        public Colors Color { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="papercircle"]/Constructor1/*'/>
        public PaperCircle() 
        {
            Color = Colors.None;
        }

        /// <include file='docs.xml' path='docs/members[@name="papercircle"]/Constructor2/*'/>
        public PaperCircle(double radius)
        {
            Radius = radius;
            Color = Colors.None;
        }

        /// <include file='docs.xml' path='docs/members[@name="papercircle"]/Constructor3/*'/>
        public PaperCircle(Shape parentShape, double radius)
        {
            if (parentShape is IFilm)
                throw new ArgumentException("Parent shape is of wrong material.");

            double area = Math.PI * Math.Pow(radius, 2);
            if (parentShape.GetArea() < area)
                throw new Exception("The area of the derived shape should be less than the area of the parent shape.");

            // down-casting the parent shape to get property 'Color'
            if (parentShape is PaperCircle paperCircle)
            {
                Color = paperCircle.Color;
            }
            else if (parentShape is PaperRectangle paperRectangle)
            {
                Color = paperRectangle.Color;
            }
            else
            {
                PaperTriangle paperTriangle = (PaperTriangle)parentShape;
                Color = paperTriangle.Color;
            }

            Radius = radius;
        }

        /// <include file='docs.xml' path='docs/members[@name="papercircle"]/GetPerimeter/*'/>
        public override double GetPerimeter()
            => 2 * Math.PI * Radius;

        /// <include file='docs.xml' path='docs/members[@name="papercircle"]/GetArea/*'/>
        public override double GetArea()
            => Math.PI * Math.Pow(Radius, 2);

        /// <include file='docs.xml' path='docs/members[@name="papercircle"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            return obj is PaperCircle paperCircle &&
                paperCircle.Radius == Radius &&
                paperCircle.Color == Color;
        }

        /// <include file='docs.xml' path='docs/members[@name="papercircle"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Radius, Color);
        }

        /// <include file='docs.xml' path='docs/members[@name="papercircle"]/ToString/*'/>
        public override string ToString()
        {
            return $"PaperCircle. ID: {Id}. Radius: {Radius}. Color: {Color}.";
        }
    }
}
