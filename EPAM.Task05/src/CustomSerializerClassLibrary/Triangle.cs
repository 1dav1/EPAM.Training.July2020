using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CustomSerializerClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="triangle"]/Triangle/*'/>
    [Serializable]
    public class Triangle : Shape
    {
        private int _sidea;
        /// <include file='docs.xml' path='docs/members[@name="triangle"]/SideA/*'/>
        public int SideA
        {
            get => _sidea;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("The side should be positive.");
                _sidea = value;
            }
        }

        private int _sideb;
        /// <include file='docs.xml' path='docs/members[@name="triangle"]/SideB/*'/>
        public int SideB 
        {
            get => _sideb;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("The side should be positive.");
                _sideb = value;
            }
        }

        private int _sidec;
        /// <include file='docs.xml' path='docs/members[@name="triangle"]/SideC/*'/>
        public int SideC 
        {
            get => _sidec;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("The side should be positive.");
                _sidec = value;
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="triangle"]/Constructor/*'/>
        public Triangle() { }

        /// <include file='docs.xml' path='docs/members[@name="triangle"]/ParametrizedConstructor/*'/>
        protected Triangle(SerializationInfo info, StreamingContext context)
        {
            // check if the deserialized object has the same version
            if (info.MemberCount >= GetType().GetProperties().Length)
            {
                SideA = info.GetInt32("SideA");
                SideB = info.GetInt32("SideB");
                SideC = info.GetInt32("SideC");
            }
            else
            {
                throw new Exception("A property is missing.");
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="triangle"]/GetObjectData/*'/>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SideA", SideA);
            info.AddValue("SideB", SideB);
            info.AddValue("SideC", SideC);
        }

        /// <include file='docs.xml' path='docs/members[@name="triangle"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return obj is Triangle triangle &&
                   triangle.SideA == SideA &&
                   triangle.SideB == SideB &&
                   triangle.SideC == SideC;
        }

        /// <include file='docs.xml' path='docs/members[@name="triangle"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(SideA, SideB, SideC);
        }
    }
}
