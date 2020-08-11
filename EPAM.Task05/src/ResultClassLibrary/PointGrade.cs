using ResultClassLibrary.Interfaces;
using System;

namespace ResultClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/PointGrade/*'/>
    [Serializable]
    public class PointGrade : IGrade<int>
    {
        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/Name/*'/>
        public string Name { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/Subject/*'/>
        public string Subject { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/Date/*'/>
        public DateTime Date { get; set; }

        private int _grade;
        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/Grade/*'/>
        public int Grade
        {
            get => _grade;
            set
            {
                if (value <= 0 || value > 10)
                    throw new ArgumentOutOfRangeException("Grade should be from 1 to 10 points.");
                _grade = value;
            }
        }

        // overloading of convertion operators to enable the convertion from one grading system to another
        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/ConvertionPercentageToPoints/*'/>
        public static explicit operator PointGrade(PercentageGrade grade)
        => new PointGrade
        {
            Name = grade.Name,
            Subject = grade.Subject,
            Date = grade.Date,
            /* Math.Round() is used to provide a correct convertion from percents to points according to the rounding rule.
             * Example: 95% are being converted to 10 points and 94% - to 9 points. */
            Grade = (int)Math.Round((decimal)grade.Grade / 10),
        };

        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/ConvertionLetterToPoints/*'/>
        public static explicit operator PointGrade(LetterGrade grade)
        {
            int g = 0;

            if (grade.Grade == 'A')
                g = 10;
            else if (grade.Grade == 'B')
                g = 8;
            else if (grade.Grade == 'C')
                g = 6;
            else if (grade.Grade == 'D')
                g = 4;
            else if (grade.Grade == 'F')
                g = 2;

            return new PointGrade { Name = grade.Name, Subject = grade.Subject, Date = grade.Date, Grade = g, };
        }

        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            if (obj is LetterGrade letterGrade)
                return Grade == ((PointGrade)letterGrade).Grade;
            if (obj is PointGrade pointGrade)
                return Grade == ((PointGrade)pointGrade).Grade;

            return (obj is PercentageGrade percentageGrade) && (percentageGrade.Grade == Grade);
        }

        /// <include file='docs.xml' path='docs/members[@name="pointgrade"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Subject, Date, Grade);
        }
    }
}
