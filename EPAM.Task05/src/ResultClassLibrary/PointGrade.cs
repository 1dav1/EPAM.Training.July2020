using ResultClassLibrary.interfaces;
using System;
using System.Collections.Generic;
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
    }
}
