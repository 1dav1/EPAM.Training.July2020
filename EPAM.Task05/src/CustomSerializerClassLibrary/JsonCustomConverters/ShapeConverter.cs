using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace CustomSerializerClassLibrary.JsonCustomConverters
{
    /// <include file='docs.xml' path='docs/members[@name="shapeconverter"]/ShapeConverter/*'/>
    public class ShapeConverter : JsonConverter
    {
        /// <include file='docs.xml' path='docs/members[@name="shapeconverter"]/ReadJsonShape/*'/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            if (objectType == typeof(Circle))
            {
                Circle circle = new Circle();
                if (obj.Properties().Count() >= circle.GetType().GetProperties().Length)
                {
                    circle.Radius = int.Parse(obj.Property("Radius").Value.ToString());
                    return circle;
                }
                else
                {
                    throw new Exception("A property is missing.");
                }
            }
            else if (objectType == typeof(Rectangle))
            {
                Rectangle rectangle = new Rectangle();
                if (obj.Properties().Count() >= rectangle.GetType().GetProperties().Length)
                {
                    rectangle.Height = int.Parse(obj.Property("Height").Value.ToString());
                    rectangle.Width = int.Parse(obj.Property("Width").Value.ToString());
                    return rectangle;
                }
                else
                {
                    throw new Exception("A property is missing.");
                }
            }
            else
            {
                Triangle triangle = new Triangle();
                if (obj.Properties().Count() >= triangle.GetType().GetProperties().Length)
                {
                    triangle.SideA = int.Parse(obj.Property("SideA").Value.ToString());
                    triangle.SideB = int.Parse(obj.Property("SideB").Value.ToString());
                    triangle.SideC = int.Parse(obj.Property("SideC").Value.ToString());
                    return triangle;
                }
                else
                {
                    throw new Exception("A property is missing.");
                }
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="shapeconverter"]/WriteJsonShape/*'/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <include file='docs.xml' path='docs/members[@name="shapeconverter"]/CanConvertShape/*'/>
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
