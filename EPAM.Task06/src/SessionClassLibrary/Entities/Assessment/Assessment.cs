using System;

namespace SessionClassLibrary.Entities.Assessment
{
    public abstract class Assessment
    {
        abstract public int Id { get; set; }
        abstract public DateTime Date { get; set; }
        abstract public int SubjectId { get; set; }
        abstract public int GroupId { get; set; }
        abstract public int NumberOfSession { get; set; }
    }
}
