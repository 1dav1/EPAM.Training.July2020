using ResultClassLibrary.Interfaces;
using System;

namespace ResultClassLibrary
{
    public class PercentageGrade : IGrade<int>
    {
        public string Name { get; set; }
        public string Test { get; set; }
        public DateTime Date { get; set; }

        private int _grade;
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

        public static explicit operator PercentageGrade(PointGrade grade)
        => new PercentageGrade
        {
            Name = grade.Name,
            Test = grade.Test,
            Date = grade.Date,
            Grade = grade.Grade * 10,
        };

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

            return new PercentageGrade { Name = grade.Name, Test = grade.Test, Date = grade.Date, Grade = g, };
        }

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

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Test, Date, Grade);
        }
    }
}
