namespace SessionClassLibrary.Entities.Grade
{
    /* the abstract class that presents the abstraction of the grade.
       grade can be of two different types:
       - pass-fail grade and
       - point grade (10 points). */
    /// <include file='docs.xml' path='docs/members[@name="grade"]/Grade/*'/>
    public abstract class Grade
    {
        /// <include file='docs.xml' path='docs/members[@name="grade"]/Id/*'/>
        public abstract int Id { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="grade"]/AssessmentId/*'/>
        public abstract int AssessmentId { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="grade"]/StudentId/*'/>
        public abstract int StudentId { get; set; }
    }
}
