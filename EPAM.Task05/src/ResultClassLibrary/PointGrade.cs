using ResultClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ResultClassLibrary
{
    public class PointGrade : IGrade<int>
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
                if (value <= 0 || value > 10)
                    throw new ArgumentOutOfRangeException("Grade should be from 1 to 10 points.");
                _grade = value;
            }
        }

        public static explicit operator PointGrade(PercentageGrade grade)
        => new PointGrade
        {
            Name = grade.Name,
            Test = grade.Test,
            Date = grade.Date,
            Grade = (int)Math.Round((decimal)grade.Grade / 10),
        };

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

            return new PointGrade { Name = grade.Name, Test = grade.Test, Date = grade.Date, Grade = g, };
        }

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

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Test, Date, Grade);
        }
    }
}
