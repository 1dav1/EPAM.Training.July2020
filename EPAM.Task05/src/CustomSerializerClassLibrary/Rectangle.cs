using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CustomSerializerClassLibrary
{
    public class Rectangle : Shape
    {
        private int _height;
        public int Height
        {
            get => _height;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("The height should be positive.");
                _height = value;
            }
        }

        private int _width;
        public int Width 
        {
            get => _width;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("The width should be positive.");
                _width = value;
            }

        }

        public Rectangle() { }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
