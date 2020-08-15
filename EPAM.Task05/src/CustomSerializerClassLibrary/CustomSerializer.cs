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
    /// <include file='docs.xml' path='docs/members[@name="serializer"]/CustomSerializer/*'/>
    public static class CustomSerializer<T> where T : ISerialize
    {
        /// <include file='docs.xml' path='docs/members[@name="serializer"]/BinSerialize/*'/>
        public static void BinSerialize(T item, string file)
        {
            if (item is null || file is null)
            {
                throw new ArgumentNullException();
            }

            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, item);
        }

        /// <include file='docs.xml' path='docs/members[@name="serializer"]/BinDeserializeObject/*'/>
        public static T BinDeserializeObject(string file)
        {
            if (file is null)
            {
                throw new ArgumentNullException();
            }

            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
            T obj = (T)formatter.Deserialize(stream);
            return obj;
        }

        /// <include file='docs.xml' path='docs/members[@name="serializer"]/JsonSerialize/*'/>
        public static void JsonSerialize(T item, string file)
        {
            if (item is null || file is null)
            {
                throw new ArgumentNullException();
            }

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

        /// <include file='docs.xml' path='docs/members[@name="serializer"]/JsonDeserializeObject/*'/>
        public static T JsonDeserializeObject(string file)
        {
            if (file is null)
            {
                throw new ArgumentNullException();
            }

            // using Newtonsoft.Json for custom deserialization of JSON
            string jsonString = File.ReadAllText(file);
            Type type = typeof(T);
            T obj;

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

        /// <include file='docs.xml' path='docs/members[@name="serializer"]/XmlSerialize/*'/>
        public static void XmlSerialize(T item, string file)
        {
            if (item is null || file is null)
            {
                throw new ArgumentNullException();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using TextWriter writer = new StreamWriter(file);
            serializer.Serialize(writer, item);
        }

        /// <include file='docs.xml' path='docs/members[@name="serializer"]/XmlDeserializeObject/*'/>
        public static T XmlDeserializeObject(string file)
        {
            if (file is null)
            {
                throw new ArgumentNullException();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using StreamReader reader = new StreamReader(file);
            T obj = (T)serializer.Deserialize(reader);
            return obj;
        }

        /// <include file='docs.xml' path='docs/members[@name="serializer"]/BinSerializeCollection/*'/>
        public static void BinSerialize(ICollection<T> collection, string file)
        {
            if (collection is null || file is null)
            {
                throw new ArgumentNullException();
            }

            Type type = collection.GetType();
            bool implementsCollection = type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>));
            if (implementsCollection)
            {
                IFormatter formatter = new BinaryFormatter();
                using Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, collection);
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="serializer"]/BinDeserializeCollection/*'/>
        public static ICollection<T> BinDeserializeCollection(string file)
        {
            if (file is null)
            {
                throw new ArgumentNullException();
            }

            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
            List<T> collection = (List<T>)formatter.Deserialize(stream);
            return collection;
        }

        /// <include file='docs.xml' path='docs/members[@name="serializer"]/JsonSerializeCollection/*'/>
        public static void JsonSerialize(ICollection<T> collection, string file)
        {
            if (collection is null || file is null)
            {
                throw new ArgumentNullException();
            }

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

        /// <include file='docs.xml' path='docs/members[@name="serializer"]/JsonDeserializeCollection/*'/>
        public static ICollection<T> JsonDeserializeCollection(string file)
        {
            if (file is null)
            {
                throw new ArgumentNullException();
            }

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

        /// <include file='docs.xml' path='docs/members[@name="serializer"]/XmlSerializeCollection/*'/>
        public static void XmlSerialize(ICollection<T> collection, string file)
        {
            if (collection is null || file is null)
            {
                throw new ArgumentNullException();
            }

            Type type = collection.GetType();
            bool implementsCollection = type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>));
            if (implementsCollection)
            {
                XmlSerializer serializer = new XmlSerializer(type);
                using TextWriter writer = new StreamWriter(file);
                serializer.Serialize(writer, collection);
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="serializer"]/XmlDeserializeCollection/*'/>
        public static ICollection<T> XmlDeserializeCollection(string file)
        {
            if (file is null)
            {
                throw new ArgumentNullException();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using StreamReader reader = new StreamReader(file);
            List<T> collection = (List<T>)serializer.Deserialize(reader);
            return collection;
        }
    }
}
