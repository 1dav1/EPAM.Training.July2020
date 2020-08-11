using ResultClassLibrary.Interfaces;
using System;

namespace ResultClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="lettergrade"]/LetterGrade/*'/>
    [Serializable]
    public class LetterGrade : IGrade<char>
    {
        /// <include file='docs.xml' path='docs/members[@name="lettergrade"]/Name/*'/>
        public string Name { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="lettergrade"]/Subject/*'/>
        public string Subject { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="lettergrade"]/Date/*'/>
        public DateTime Date { get; set; }

        private char _grade;

        /// <include file='docs.xml' path='docs/members[@name="lettergrade"]/Grade/*'/>
        public char Grade
        {
            get => _grade;
            set
            {
                if (value != 'A' && value != 'B' && value != 'C' && value != 'D' && value != 'F')
                    throw new ArgumentOutOfRangeException("Grade is incorrect.");
                _grade = value;
            }
        }

        // overloading of convertion operators to enable the convertion from one grading system to another
        /// <include file='docs.xml' path='docs/members[@name="lettergrade"]/ConvertionPointToLetter/*'/>
        public static explicit operator LetterGrade(PointGrade grade)
        {
            char g = char.MinValue;

            if (grade.Grade > 9 && grade.Grade <= 10)
            {
                g = 'A';
            }
            else if (grade.Grade > 8 && grade.Grade <= 9)
            {
                g = 'B';
            }
            else if (grade.Grade > 6 && grade.Grade <= 8)
            {
                g = 'C';
            }
            else if (grade.Grade > 4 && grade.Grade <= 6)
            {
                g = 'D';
            }
            else if (grade.Grade >= 0 && grade.Grade <= 4)
            {
                g = 'F';
            }

            return new LetterGrade { Name = grade.Name, Subject = grade.Subject, Date = grade.Date, Grade = g, };
        }

        /// <include file='docs.xml' path='docs/members[@name="lettergrade"]/ConvertionPercentageToLetter/*'/>
        public static explicit operator LetterGrade(PercentageGrade grade)
        {
            char g = char.MinValue;

            if (grade.Grade > 90 && grade.Grade <= 100)
                g = 'A';
            else if (grade.Grade > 80 && grade.Grade <= 90)
                g = 'B';
            else if (grade.Grade > 60 && grade.Grade <= 80)
                g = 'C';
            else if (grade.Grade > 40 && grade.Grade <= 60)
                g = 'D';
            else if (grade.Grade >= 0 && grade.Grade <= 40)
                g = 'F';

            return new LetterGrade { Name = grade.Name, Subject = grade.Subject, Date = grade.Date, Grade = g, };
        }

        /// <include file='docs.xml' path='docs/members[@name="lettergrade"]/Equals/*'/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            if (obj is PercentageGrade percentageGrade)
                return Grade == ((LetterGrade)percentageGrade).Grade;
            if (obj is PointGrade pointGrade)
                return Grade == ((LetterGrade)pointGrade).Grade;

            return (obj is LetterGrade letterGrade) && (letterGrade.Grade == Grade);
        }

        /// <include file='docs.xml' path='docs/members[@name="lettergrade"]/GetHashCode/*'/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Subject, Date, Grade);
        }
    }
}
