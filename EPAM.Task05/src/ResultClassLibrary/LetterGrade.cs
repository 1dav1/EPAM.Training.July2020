using ResultClassLibrary.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResultClassLibrary
{
    public class LetterGrade : IGrade<char>
    {
        public string Name { get; set; }
        public string Test { get; set; }
        public DateTime Date { get; set; }

        private char _grade;
        public char Grade
        {
            get => _grade;
            set
            {
                if (value != 'A' && value != 'B' && value != 'C' && value != 'D' && value != 'E' && value != 'F')
                    throw new ArgumentOutOfRangeException("Grade is incorrect.");
                _grade = value;
            }
        }

    }
}
