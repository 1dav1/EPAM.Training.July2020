using System;
using System.Collections.Generic;
using System.Text;

namespace SessionClassLibrary.Entities.Grade
{
    public class PointGrade : Grade
    {
        public override int Id { get; set; }
        public override int AssessmentId { get; set; }
        public override int StudentId { get; set; }
        public int Value { get; set; }
    }
}
