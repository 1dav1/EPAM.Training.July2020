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

namespace CustomSerializerClassLibrary
{
    public static class CustomSerializer<T> where T : ISerialize
    {
        public static void BinSerialize(T item, string file)
        {
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, item);
        }

        public static T BinDeserializeObject(string file)
        {
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
            T obj = (T)formatter.Deserialize(stream);
            return obj;
        }

        public static void JsonSerialize(T item, string file)
        {
            string jsonString = JsonSerializer.Serialize(item);
            try
            {
                File.WriteAllText(file, jsonString);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static T JsonDeserializeObject(string file)
        {
            // using Newtonsoft.Json for custom deserialization of JSON
            string jsonString = File.ReadAllText(file);
            Type type = typeof(T);
            T obj = default;

            // custom JSON converters
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

        public static void BinSerialize(ICollection<T> collection, string file)
        {
            Type type = collection.GetType();
            bool implementsCollection = type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>));
            if (implementsCollection)
            {
                IFormatter formatter = new BinaryFormatter();
                using Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, collection);
            }
        }

        public static ICollection<T> BinDeserializeCollection(string file)
        {
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
            List<T> collection = (List<T>)formatter.Deserialize(stream);
            return collection;
        }

        public static void JsonSerialize(ICollection<T> collection, string file)
        {
            Type type = collection.GetType();
            bool implementsCollection = type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>));
            if (implementsCollection)
            {
                string jsonString = JsonSerializer.Serialize(collection);
                try
                {
                    File.WriteAllText(file, jsonString);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static ICollection<T> JsonDeserializeCollection(string file)
        {
            List<T> collection = default;
            try
            {
                string jsonString = File.ReadAllText(file);
                collection = JsonConvert.DeserializeObject<List<T>>(jsonString);
            }
            catch(Exception ex)
            { 
                Console.WriteLine(ex.Message); 
            }
            return collection;
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
