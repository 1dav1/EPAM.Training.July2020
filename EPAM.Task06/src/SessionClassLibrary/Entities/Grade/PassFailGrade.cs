using System;

namespace SessionClassLibrary.Entities.Grade
{
    // the derived class that presents the pass-fail grade
    /// <include file='docs.xml' path='docs/members[@name="passfailgrade"]/PassFailGrade/*'/>
    public class PassFailGrade : Grade
    {
        private int _id;
        /// <include file='docs.xml' path='docs/members[@name="passfailgrade"]/Id/*'/>
        public override int Id
        {
            get => _id;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("ID should be positive.");
                _id = value;
            }
        }

        private int _assessmentId;
        /// <include file='docs.xml' path='docs/members[@name="passfailgrade"]/AssessmentId/*'/>
        public override int AssessmentId 
        {
            get => _assessmentId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Assessment ID should be positive.");
            } 
        }

        private int _studentId;
        /// <include file='docs.xml' path='docs/members[@name="passfailgrade"]/StudentId/*'/>
        public override int StudentId 
        { 
            get => _studentId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Student ID should be positive");
                _studentId = value;
            } 
        }

        private string _value;
        /// <include file='docs.xml' path='docs/members[@name="passfailgrade"]/Value/*'/>
        public string Value
        {
            get => _value;
            set
            {
                if (value != "Pass" && value != "Fail")
                    throw new ArgumentOutOfRangeException("Wrong value. Grade should be 'Pass' or 'Fail'.");
                _value = value;
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="passfailgrade"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return obj is PassFailGrade grade &&
                   grade.Id == Id &&
                   grade.StudentId == StudentId &&
                   grade.AssessmentId == AssessmentId &&
                   grade.Value == Value;
        }

        /// <include file='docs.xml' path='docs/members[@name="passfailgrade"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, AssessmentId, StudentId, Value);
        }
    }
}
