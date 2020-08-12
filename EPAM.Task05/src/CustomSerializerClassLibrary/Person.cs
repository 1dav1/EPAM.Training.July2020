using CustomSerializerClassLibrary.Interfaces;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

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
                    if (info.GetString("Gender").ToUpper() == "MALE" ||
                        info.GetString("Gender").ToUpper() == "FEMALE" ||
                        info.GetString("Gender").ToUpper() == "NONE")
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", FirstName);
            info.AddValue("Age", Age);
            info.AddValue("Gender", Gender);
        }
    }
}
