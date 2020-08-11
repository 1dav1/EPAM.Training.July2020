using ResultClassLibrary.Interfaces;
using System;

namespace ResultClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="percentagegrade"]/PercentageGrade/*'/>
    [Serializable]
    public class PercentageGrade : IGrade<int>
    {
        /// <include file='docs.xml' path='docs/members[@name="percentagegrade"]/Name/*'/>
        public string Name { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="percentagegrade"]/Subject/*'/>
        public string Subject { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="percentagegrade"]/Date/*'/>
        public DateTime Date { get; set; }

        private int _grade;
        /// <include file='docs.xml' path='docs/members[@name="percentagegrade"]/Grade/*'/>
        public int Grade
        {
            get => _grade;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("Grade should be from 0 to 100 percent.");
                _grade = value;
            }
        }

        // overloading of convertion operators to enable the convertion from one grading system to another
        /// <include file='docs.xml' path='docs/members[@name="percentagegrade"]/ConvertionPointToPercentage/*'/>
        public static explicit operator PercentageGrade(PointGrade grade)
        => new PercentageGrade
        {
            Name = grade.Name,
            Subject = grade.Subject,
            Date = grade.Date,
            Grade = grade.Grade * 10,
        };

        /// <include file='docs.xml' path='docs/members[@name="percentagegrade"]/ConvertionLetterToPercentage/*'/>
        public static explicit operator PercentageGrade(LetterGrade grade)
        {
            int g = 0;

            if (grade.Grade == 'A')
                g = 100;
            else if (grade.Grade == 'B')
                g = 80;
            else if (grade.Grade == 'C')
                g = 60;
            else if (grade.Grade == 'D')
                g = 40;
            else if (grade.Grade == 'F')
                g = 10;

            return new PercentageGrade { Name = grade.Name, Subject = grade.Subject, Date = grade.Date, Grade = g, };
        }

        /// <include file='docs.xml' path='docs/members[@name="percentagegrade"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            if (obj is LetterGrade letterGrade)
                return Grade == ((PercentageGrade)letterGrade).Grade;
            if (obj is PointGrade pointGrade)
                return Grade == ((PercentageGrade)pointGrade).Grade;

            return (obj is PercentageGrade percentageGrade) && (percentageGrade.Grade == Grade);
        }

        /// <include file='docs.xml' path='docs/members[@name="percentagegrade"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Subject, Date, Grade);
        }
    }
}
