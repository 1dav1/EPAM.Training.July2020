using System;

namespace SessionClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="student"]/Student/*'/>
    public class Student
    {
        private int _id;
        /// <include file='docs.xml' path='docs/members[@name="student"]/Id/*'/>
        public int Id
        {
            get => _id;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("ID should be positive.");
                _id = value;
            }
        }

        private string _name;
        /// <include file='docs.xml' path='docs/members[@name="student"]/Name/*'/>
        public string Name
        {
            get => _name;
            set
            {
                if (value is null || value == "")
                    throw new ArgumentOutOfRangeException("The name string should not be empty.");
                _name = value;
            }
        }

        private string _gender;
        /// <include file='docs.xml' path='docs/members[@name="student"]/Gender/*'/>
        public string Gender
        {
            get => _gender;
            set
            {
                if (value != "Male" && value != "Female")
                    throw new ArgumentOutOfRangeException("Gender should be 'Male' or 'Female'.");
                _gender = value;
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="student"]/BirthDate/*'/>
        public DateTime BirthDate { get; set; }

        private int _groupId;
        /// <include file='docs.xml' path='docs/members[@name="student"]/GroupId/*'/>
        public int GroupId
        {
            get => _groupId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Group ID should be positive.");
                _groupId = value;
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="student"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return obj is Student student &&
                   student.Id == Id &&
                   student.Name == Name &&
                   student.Gender == Gender &&
                   student.BirthDate == BirthDate &&
                   student.GroupId == GroupId;
        }

        /// <include file='docs.xml' path='docs/members[@name="student"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Gender, BirthDate, GroupId);
        }
    }
}
