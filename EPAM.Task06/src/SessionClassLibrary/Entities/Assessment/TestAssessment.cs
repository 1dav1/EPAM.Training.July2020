using System;

namespace SessionClassLibrary.Entities.Assessment
{
    public class TestAssessment : Assessment
    {
        private int _id;
        public override int Id
        {
            get => _id;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("ID should be positive.");
                _id = value;
            }
        }

        public override DateTime Date { get; set; }

        private int _numberOfSession;
        public override int NumberOfSession
        {
            get => _numberOfSession;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Number of the session should be positive.");
                _numberOfSession = value;
            }
        }

        private int _subjectId;
        public override int SubjectId
        {
            get => _subjectId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Subject ID should be positive.");
                _subjectId = value;
            }
        }

        private int _groupId;
        public override int GroupId
        {
            get => _groupId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Group ID should be positive");
                _groupId = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return obj is TestAssessment test &&
                   test.Id == Id &&
                   test.GroupId == GroupId &&
                   test.Date == Date &&
                   test.SubjectId == SubjectId &&
                   test.NumberOfSession == NumberOfSession;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Date, NumberOfSession, SubjectId, GroupId);
        }
    }
}
