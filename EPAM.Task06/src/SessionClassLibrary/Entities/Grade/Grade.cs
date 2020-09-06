using System;
using System.Collections.Generic;
using System.Text;

namespace SessionClassLibrary.Entities.Grade
{
    public abstract class Grade
    {
        public abstract int Id { get; set; }
        public abstract int AssessmentId { get; set; }
        public abstract int StudentId { get; set; }
    }
}
