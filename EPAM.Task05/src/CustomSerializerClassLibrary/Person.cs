using CustomSerializerClassLibrary.Interfaces;
using CustomSerializerClassLibrary.JsonCustomConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Xml;
using System.Xml.Schema;

namespace CustomSerializerClassLibrary
{
    [Serializable]
    public enum Gender
    {
        Male,
        Female,
        None,
    }

    [Serializable]
    [JsonConverter(typeof(PersonConverter))]
    public class Person : ISerialize
    {
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value is null || value == "" || value == " ")
                    throw new ArgumentOutOfRangeException("First Name should not be empty.");
                _firstName = value;
            }
        }

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("The age should be positive.");
                _age = value;
            }
        }

        public Gender Gender { get; set; }

        public Person() { }

        protected Person(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount >= GetType().GetProperties().Length)
            {
                FirstName = info.GetString("FirstName");
                Age = info.GetInt32("Age");
                try
                {
                    Gender = (Gender)info.GetValue("Gender", typeof(Gender));
                }
                catch (Exception)
                {
                    /* if the deserializable property Gender is string and it has one the possible values
                     * pass this value to the property Gender of the created object */
                    if (info.GetString("Gender").ToUpper() == "male" ||
                        info.GetString("Gender").ToUpper() == "female" ||
                        info.GetString("Gender").ToUpper() == "none")
                    {
                        string gender = info.GetString("Gender").First().ToString().ToUpper() + info.GetString("Gender").Substring(1);
                        Gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    }
                }
            }
            else
            {
                throw new Exception("A property is missing.");
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", FirstName);
            info.AddValue("Age", Age);
            info.AddValue("Gender", Gender);
        }

        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            int count = 0;
            using var inner = reader.ReadSubtree();
            while (inner.Read())
                count++;

            // check if the number of nodes in the XML file equals number of properties of the current class
            if (count >= GetType().GetMembers().Length)
            {
                XmlTextReader textReader = (XmlTextReader)reader;
                while (textReader.Read())
                {
                    switch (textReader.Name)
                    {
                        case "FirstName":
                            FirstName = textReader.ReadString();
                            break;
                        case "Age":
                            Age = int.Parse(textReader.ReadString());
                            break;
                        case "Gender":
                            Gender = (Gender)Enum.Parse(typeof(Gender), textReader.ReadString());
                            break;
                        default: break;
                    }
                }
            }
            else
            {
                throw new Exception("A property is missing.");
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            Dictionary<string, PropertyInfo> propertyInfoDic = new Dictionary<string, PropertyInfo>();
            PropertyInfo[] properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                propertyInfoDic.Add(property.Name, property);
            }

            foreach (string key in propertyInfoDic.Keys.ToList())
            {
                object valueObject = propertyInfoDic[key].GetValue(this);
                writer.WriteStartElement(key);
                writer.WriteString(valueObject.ToString());
                writer.WriteEndElement();
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;
            return obj is Person person &&
                   person.FirstName == FirstName &&
                   person.Age == Age &&
                   person.Gender == Gender;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, Age, Gender);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
