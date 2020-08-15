using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace CustomSerializerClassLibrary.JsonCustomConverters
{
    /* custom JSON converter for deserialization. 
     * checks if the version of the class in JSON file corresponds with the current version of the class. */
    /// <include file='docs.xml' path='docs/members[@name="productconverter"]/ProductConverter/*'/>
    public class ProductConverter : JsonConverter
    {
        // custom deserialization
        /// <include file='docs.xml' path='docs/members[@name="productconverter"]/ReadJsonProduct/*'/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            Product product = new Product();
            if (obj.Properties().Count() >= product.GetType().GetProperties().Length)
            {
                product.Name = obj.Property("Name").Value.ToString();
                product.Price = decimal.Parse(obj.Property("Price").Value.ToString());
                return product;
            }
            else
            {
                throw new Exception("A property is missing.");
            }
        }

        // custom serialization is not used
        /// <include file='docs.xml' path='docs/members[@name="productconverter"]/WriteJsonProduct/*'/>
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <include file='docs.xml' path='docs/members[@name="productconverter"]/CanConvertProduct/*'/>
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
