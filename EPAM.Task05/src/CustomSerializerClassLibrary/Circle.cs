using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CustomSerializerClassLibrary
{
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

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
