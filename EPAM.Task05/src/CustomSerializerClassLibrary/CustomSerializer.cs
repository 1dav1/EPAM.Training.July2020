using CustomSerializerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;

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

        public static void XmlSerialize(T item)
        {

        }

        public static void XmlDeserialize(T item)
        {

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

        public static void XmlSerialize(ICollection<T> collection)
        {

        }

        public static void XmlDeserialize(ICollection<T> collection)
        {

        }
    }
}
