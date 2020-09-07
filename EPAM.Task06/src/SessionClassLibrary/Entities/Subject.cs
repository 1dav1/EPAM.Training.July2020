using System;

namespace SessionClassLibrary
{
    public class Subject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("ID should be positive");
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
                    throw new ArgumentOutOfRangeException("The name should not be empty.");
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return obj is Subject subject &&
                   subject.Id == Id &&
                   subject.Name == Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
