using CustomSerializerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CustomSerializerClassLibrary
{
    public static class CustomSerializer<T> where T : ISerialize
    {
        public static void BinSerialize(T item)
        {

        }

        public static void BinDeserialize(T item)
        {

        }

        public static void JsonSerialize(T item)
        {

        }

        public static void JsonDeserialize(T item)
        {

        }

        public static void XmlSerialize(T item, string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using TextWriter writer = new StreamWriter(file);
            serializer.Serialize(writer, item);
        }

        public static T XmlDeserializeObject(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using StreamReader reader = new StreamReader(file);
            T obj = (T)serializer.Deserialize(reader);
            return obj;
        }

        public static void BinSerialize(ICollection<T> collection)
        {

        }

        public static void BinDeserialize(ICollection<T> collection)
        {

        }

        public static void JsonSerialize(ICollection<T> collection)
        {

        }

        public static void JsonDeserialize(ICollection<T> collection)
        {

        }

        public static void XmlSerialize(ICollection<T> collection, string file)
        {
            Type type = collection.GetType();
            bool implementsCollection = type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>));
            if (implementsCollection)
            {
                XmlSerializer serializer = new XmlSerializer(type);
                using TextWriter writer = new StreamWriter(file);
                serializer.Serialize(writer, collection);
            }
        }

        public static ICollection<T> XmlDeserializeCollection(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using StreamReader reader = new StreamReader(file);
            List<T> collection = (List<T>)serializer.Deserialize(reader);
            return collection;
        }
    }
}
