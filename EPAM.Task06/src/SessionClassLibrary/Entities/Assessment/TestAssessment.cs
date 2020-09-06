using System;

namespace SessionClassLibrary.Entities.Assessment
{
    public class TestAssessment : Assessment
    {
        public override int Id { get; set; }
        public override DateTime Date { get; set; }
        public override int NumberOfSession { get; set; }
        public override int SubjectId { get; set; }
        public override int GroupId { get; set; }
    }
}
