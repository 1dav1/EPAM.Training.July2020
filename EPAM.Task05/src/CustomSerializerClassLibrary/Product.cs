using CustomSerializerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CustomSerializerClassLibrary
{
    public class Product : ISerialize
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product() { }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
