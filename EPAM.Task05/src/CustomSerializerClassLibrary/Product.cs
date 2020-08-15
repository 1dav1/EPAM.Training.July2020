using CustomSerializerClassLibrary.Interfaces;
using CustomSerializerClassLibrary.JsonCustomConverters;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CustomSerializerClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(ProductConverter))]
    public class Product : ISerialize
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product() { }

        protected Product(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount >= GetType().GetProperties().Length)
            {
                Name = info.GetString("Name");
                Price = info.GetDecimal("Price");
            }
            else
            {
                throw new Exception("A property is missing.");
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Price", Price);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return obj is Product product &&
                   product.Name == Name &&
                   product.Price == Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price);
        }
    }
}
