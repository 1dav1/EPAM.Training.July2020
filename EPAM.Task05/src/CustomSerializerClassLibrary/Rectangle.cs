using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CustomSerializerClassLibrary
{
    [Serializable]
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

        protected Rectangle(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount >= GetType().GetProperties().Length)
            {
                Height = info.GetInt32("Height");
                Width = info.GetInt32("Width");
            }
            else
            {
                throw new Exception("A property is missing.");
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Height", Height);
            info.AddValue("Width", Width);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return obj is Rectangle rectangle &&
                   rectangle.Height == Height &&
                   rectangle.Width == Width;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Height, Width);
        }
    }
}
