using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace CustomSerializerClassLibrary
{
    [Serializable]
    public class Triangle : Shape
    {
        private int _sidea;
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

        public Triangle() { }

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

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SideA", SideA);
            info.AddValue("SideB", SideB);
            info.AddValue("SideC", SideC);
        }

        
    }
}
