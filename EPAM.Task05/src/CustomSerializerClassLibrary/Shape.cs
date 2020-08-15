using CustomSerializerClassLibrary.Interfaces;
using CustomSerializerClassLibrary.JsonCustomConverters;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace CustomSerializerClassLibrary
{
    [Serializable]
    [JsonConverter(typeof(ShapeConverter))]
    public abstract class Shape : ISerialize
    {
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
    }
}
