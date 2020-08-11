using CustomSerializerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace CustomSerializerClassLibrary
{
    public class CustomSerializer<T> where T : ISerialize
    {
        public void BinSerialize(T item)
        {

        }

        public void BinDeserialize(T item)
        {

        }

        public void JsonSerialize(T item)
        {

        }

        public void JsonDeserialize(T item)
        {

        }

        public void XmlSerialize(T item)
        {

        }

        public void XmlDeserialize(T item)
        {

        }

        public void BinSerialize(ICollection<T> collection)
        {

        }

        public void BinDeserialize(ICollection<T> collection)
        {

        }

        public void JsonSerialize(ICollection<T> collection)
        {

        }

        public void JsonDeserialize(ICollection<T> collection)
        {

        }

        public void XmlSerialize(ICollection<T> collection)
        {

        }

        public void XmlDeserialize(ICollection<T> collection)
        {

        }
    }
}
