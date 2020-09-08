using System;

namespace SessionClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="subject"]/Subject/*'/>
    public class Subject
    {
        private int _id;
        /// <include file='docs.xml' path='docs/members[@name="subject"]/Id/*'/>
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
        /// <include file='docs.xml' path='docs/members[@name="subject"]/Name/*'/>
        public string Name
        {
            get => _name;
            set
            {
                if (value is null || value == "")
                    throw new ArgumentOutOfRangeException("The name should not be empty.");
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="subject"]/Equals/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="subject"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
