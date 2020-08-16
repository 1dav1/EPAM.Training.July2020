using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CustomSerializerClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="circle"]/Circle/*'/>
    [Serializable]
    public class Circle : Shape
    {
        private int _radius;
        /// <include file='docs.xml' path='docs/members[@name="circle"]/Radius/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="circle"]/Constructor/*'/>
        public Circle() { }

        /// <include file='docs.xml' path='docs/members[@name="circle"]/ParametrizedConstructor/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="circle"]/GetObjectData/*'/>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Radius", Radius);
        }

        /// <include file='docs.xml' path='docs/members[@name="circle"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return obj is Circle circle &&
                   circle.Radius == Radius;
        }

        /// <include file='docs.xml' path='docs/members[@name="circle"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Radius);
        }
    }
}
