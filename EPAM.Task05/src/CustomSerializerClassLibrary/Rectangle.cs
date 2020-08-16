using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CustomSerializerClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="rectangle"]/Rectangle/*'/>
    [Serializable]
    public class Rectangle : Shape
    {
        private int _height;
        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/Height/*'/>
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
        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/Width/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/Constructor/*'/>
        public Rectangle() { }

        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/ParametrizedConstructor/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/GetObjectData/*'/>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Height", Height);
            info.AddValue("Width", Width);
        }

        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/Equals/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="rectangle"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Height, Width);
        }
    }
}
