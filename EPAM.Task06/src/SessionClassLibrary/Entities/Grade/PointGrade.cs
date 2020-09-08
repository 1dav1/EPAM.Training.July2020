using System;

namespace SessionClassLibrary.Entities.Grade
{
    // the derived class that presents the 10-points grade
    /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/PointGrade/*'/>
    public class PointGrade : Grade
    {
        private int _id;
        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/Id/*'/>
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
        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/AssessmentId/*'/>
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
        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/StudentId/*'/>
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

        private int _value;
        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/Value/*'/>
        public int Value 
        { 
            get => _value; 
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentOutOfRangeException("The value should be within 0 - 10.");
                _value = value;
            } 
        }

        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return obj is PointGrade grade &&
                   grade.Id == Id &&
                   grade.StudentId == StudentId &&
                   grade.AssessmentId == AssessmentId &&
                   grade.Value == Value;
        }

        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, AssessmentId, StudentId, Value);
        }
    }
}
