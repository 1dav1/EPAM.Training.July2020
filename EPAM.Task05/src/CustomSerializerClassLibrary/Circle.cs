using System;
using System.Runtime.Serialization;

namespace CustomSerializerClassLibrary
{
    [Serializable]
    public class Circle : Shape
    {
        private int _radius;
        public int Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("The radius should be positive.");
                _radius = value;
            }
        }

        public Circle() { }

        protected Circle(SerializationInfo info, StreamingContext context)
        {
            
            if (info.MemberCount >= GetType().GetProperties().Length)
            {
                Radius = info.GetInt32("Radius");
            }
            else
            {
                throw new Exception("A property is missing.");
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Radius", Radius);
        }
    }
}
