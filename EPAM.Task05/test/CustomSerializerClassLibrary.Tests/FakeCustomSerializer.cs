using CustomSerializerClassLibrary.Interfaces;
using CustomSerializerClassLibrary.JsonCustomConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CustomSerializerClassLibrary.Tests
{
    /* FakeCustomSerializer class has the functionality of the original class.
     * designed for testing. */
    public class FakeCustomSerializer<T> where T : ISerialize
    {
        public static byte[] BinSerialize(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException();
            }

            IFormatter formatter = new BinaryFormatter();
            using MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, item);
            return memoryStream.ToArray();
        }

        public static T BinDeserializeObject(byte[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException();
            }

            IFormatter formatter = new BinaryFormatter();
            using MemoryStream memoryStream = new MemoryStream(array);
            T obj = (T)formatter.Deserialize(memoryStream);
            return obj;
        }

        public static string JsonSerialize(T item)
        {
            return !(item is null) ? JsonSerializer.Serialize(item) : throw new ArgumentNullException();
        }

        public static T JsonDeserializeObject(string jsonString)
        {
            if (jsonString is null)
            {
                throw new ArgumentNullException();
            }

            Type type = typeof(T);
            T obj;

            /* using Newtonsoft.Json for custom deserialization of JSON
             * custom JSON converters */
            if (type == typeof(Person))
            {
                obj = JsonConvert.DeserializeObject<T>(jsonString, new PersonConverter());
            }
            else if (type == typeof(Product))
            {
                obj = JsonConvert.DeserializeObject<T>(jsonString, new ProductConverter());
            }
            else
            {
                obj = JsonConvert.DeserializeObject<T>(jsonString, new ShapeConverter());
            }
            return obj;
        }

        public static string XmlSerialize(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, item);
            return stringWriter.ToString();
        }

        public static T XmlDeserializeObject(string xmlString)
        {
            if (xmlString is null)
            {
                throw new ArgumentNullException();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using StringReader reader = new StringReader(xmlString);
            T obj = (T)serializer.Deserialize(reader);
            return obj;
        }

        public static byte[] BinSerialize(ICollection<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException();
            }

            Type type = collection.GetType();
            bool implementsCollection = type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>));
            if (implementsCollection)
            {
                IFormatter formatter = new BinaryFormatter();

                using MemoryStream memoryStream = new MemoryStream();
                formatter.Serialize(memoryStream, collection);
                return memoryStream.ToArray();
            }
            else
                return null;
        }

        public static ICollection<T> BinDeserializeCollection(byte[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException();
            }

            IFormatter formatter = new BinaryFormatter();
            using MemoryStream memoryStream = new MemoryStream(array);
            List<T> collection = (List<T>)formatter.Deserialize(memoryStream);
            return collection;
        }

        public static string JsonSerialize(ICollection<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException();
            }

            Type type = collection.GetType();
            bool implementsCollection = type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>));
            if (implementsCollection)
            {
                return JsonSerializer.Serialize(collection);
            }
            return null;
        }

        public static ICollection<T> JsonDeserializeCollection(string jsonString)
        {
            if (jsonString is null)
            {
                throw new ArgumentNullException();
            }

            List<T> collection = default;
            try
            {
                collection = JsonConvert.DeserializeObject<List<T>>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return collection;
        }

        public static string XmlSerialize(ICollection<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException();
            }

            Type type = collection.GetType();
            bool implementsCollection = type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>));
            if (implementsCollection)
            {
                XmlSerializer serializer = new XmlSerializer(type);
                using var stringWriter = new StringWriter();
                serializer.Serialize(stringWriter, collection);
                return stringWriter.ToString();
            }
            return null;
        }

        public static ICollection<T> XmlDeserializeCollection(string xmlString)
        {
            if (xmlString is null)
            {
                throw new ArgumentNullException();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using StringReader reader = new StringReader(xmlString);
            List<T> collection = (List<T>)serializer.Deserialize(reader);
            return collection;
        }
    }
}
