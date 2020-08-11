using CustomSerializerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CustomSerializerClassLibrary
{
    public class Person : ISerialize
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Person() { }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
