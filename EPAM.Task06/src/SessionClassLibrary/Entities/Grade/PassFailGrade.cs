using System;

namespace SessionClassLibrary.Entities.Grade
{
    public class PassFailGrade : Grade
    {
        public override int Id { get; set; }
        public override int AssessmentId { get; set; }
        public override int StudentId { get; set; }

        private string _value;
        public string Value
        {
            get => _value;
            set
            {
                if (value != "Pass" && value != "Fail")
                    throw new Exception("Wrong value. Grade should be 'Pass' or 'Fail'.");
                _value = value;
            }
        }
    }
}
