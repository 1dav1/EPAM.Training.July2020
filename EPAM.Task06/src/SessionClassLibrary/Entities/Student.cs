using System;

namespace SessionClassLibrary
{
    public class Student
    {
        private int _id;
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

        public DateTime BirthDate { get; set; }

        private int _groupId;
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

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Gender, BirthDate, GroupId);
        }
    }
}
