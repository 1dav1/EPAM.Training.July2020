using CustomSerializerClassLibrary.Interfaces;
using CustomSerializerClassLibrary.JsonCustomConverters;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace CustomSerializerClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="shape"]/Shape/*'/>
    [Serializable]
    [JsonConverter(typeof(ShapeConverter))]
    public abstract class Shape : ISerialize
    {
        /// <include file='docs.xml' path='docs/members[@name="shape"]/GetObjectData/*'/>
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
    }
}
