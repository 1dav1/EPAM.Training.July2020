using System;

namespace SessionClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="studentgroup"]/StudentGroup/*'/>
    public class StudentGroup
    {
        private int _id;
        /// <include file='docs.xml' path='docs/members[@name="studentgroup"]/Id/*'/>
        public int Id { get => _id;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("ID should be positive");
                _id = value;
            }
        }

        private string _number;
        /// <include file='docs.xml' path='docs/members[@name="studentgroup"]/Number/*'/>
        public string Number 
        { 
            get => _number; 
            set
            {
                if (value == string.Empty || value is null)
                    throw new ArgumentOutOfRangeException("The group number should not be empty.");
                _number = value;
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="studentgroup"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return obj is StudentGroup group &&
                   group.Id == Id &&
                   group.Number == Number;
        }

        /// <include file='docs.xml' path='docs/members[@name="studentgroup"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Number);
        }
    }
}
