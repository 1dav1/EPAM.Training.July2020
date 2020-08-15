using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace CustomSerializerClassLibrary.JsonCustomConverters
{
    /* custom JSON converter for deserialization. 
     * checks if the version of the class in JSON file corresponds with the current version of the class. */
    public class PersonConverter : JsonConverter
    {
        // custom deserialization
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            Person person = new Person();
            if (obj.Properties().Count() >= person.GetType().GetProperties().Length)
            {
                person.FirstName = obj.Property("FirstName").Value.ToString();
                person.Age = int.Parse(obj.Property("Age").Value.ToString());

                /* if in JSON file the Person class has 'Gender' property of type 'string',
                   check if it has an acceptable value */
                if (obj.Property("Gender").Value.ToString().ToLower() == "male" ||
                    obj.Property("Gender").Value.ToString().ToLower() == "female" ||
                    obj.Property("Gender").Value.ToString().ToLower() == "none")
                {
                    string gender = obj.Property("Gender").Value.ToString().First().ToString().ToUpper() +
                                    obj.Property("Gender").Value.ToString().Substring(1).ToLower();
                    person.Gender = (Gender)Enum.Parse(typeof(Gender), gender);
                }
                else
                {
                    person.Gender = (Gender)Enum.Parse(typeof(Gender), obj.Property("Gender").Value.ToString());
                }
                return person;
            }
            else
            {
                throw new Exception("A property is missing.");
            }
        }

        // custom serialization is not used
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
