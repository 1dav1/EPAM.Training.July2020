using CustomSerializerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CustomSerializerClassLibrary
{
    public abstract class Shape : ISerialize
    {
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
    }
}
