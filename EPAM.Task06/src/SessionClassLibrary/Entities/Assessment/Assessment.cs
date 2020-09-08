using System;

namespace SessionClassLibrary.Entities.Assessment
{
    /* the abstract class that presents a general assessment. 
     * all the assessents are divided into two types:
     * - exam,
     * - test. 
     */
    /// <include file='docs.xml' path='docs/members[@name="assessment"]/Assessment/*'/>
    public abstract class Assessment
    {
        /// <include file='docs.xml' path='docs/members[@name="assessment"]/Id/*'/>
        abstract public int Id { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="assessment"]/Date/*'/>
        abstract public DateTime Date { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="assessment"]/SubjectId/*'/>
        abstract public int SubjectId { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="assessment"]/GroupId/*'/>
        abstract public int GroupId { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="assessment"]/NumberOfSession/*'/>
        abstract public int NumberOfSession { get; set; }
    }
}
