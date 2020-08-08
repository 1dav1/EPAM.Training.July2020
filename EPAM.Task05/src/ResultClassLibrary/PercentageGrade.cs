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
        public int Grade { get => _grade;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("Grade should be from 0 to 100 percent.");
                _grade = value;
            }
        }
    }
}
