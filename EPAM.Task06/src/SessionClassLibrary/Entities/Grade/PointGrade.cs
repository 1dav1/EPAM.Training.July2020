using System;
using System.Collections.Generic;
using System.Text;

namespace SessionClassLibrary.Entities.Grade
{
    public class PointGrade : Grade
    {
        private int _id;
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

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, AssessmentId, StudentId, Value);
        }
    }
}
