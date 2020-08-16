using CustomSerializerClassLibrary.Interfaces;
using CustomSerializerClassLibrary.JsonCustomConverters;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CustomSerializerClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="product"]/Product/*'/>
    [Serializable]
    [JsonConverter(typeof(ProductConverter))]
    public class Product : ISerialize
    {
        /// <include file='docs.xml' path='docs/members[@name="product"]/Name/*'/>
        public string Name { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="product"]/Price/*'/>
        public decimal Price { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="product"]/Constructor/*'/>
        public Product() { }

        /// <include file='docs.xml' path='docs/members[@name="product"]/ParametrizedConstructor/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="product"]/GetObjectData/*'/>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Price", Price);
        }

        /// <include file='docs.xml' path='docs/members[@name="product"]/Equals/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="product"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price);
        }
    }
}
