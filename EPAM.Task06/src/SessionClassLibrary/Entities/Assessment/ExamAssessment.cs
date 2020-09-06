using System;
using System.Collections.Generic;
using System.Text;

namespace SessionClassLibrary.Entities.Assessment
{
    public class ExamAssessment : Assessment
    {
        public override int Id { get; set; }
        public override DateTime Date { get; set; }
        public override int NumberOfSession { get; set; }
        public override int SubjectId { get; set; }
        public override int GroupId { get; set; }
    }
}
