using SessionClassLibrary.Entities.Assessment;
using SessionClassLibrary.Entities.Grade;
using System;
using System.Data.SqlClient;

namespace SessionClassLibrary.Helpers
{
    public static class MapperHelper
    {
        public static T RecordToModel<T>(this SqlDataReader record) where T : class, new()
        {
            var entity = new T();

            foreach (var property in typeof(T).GetProperties())
            {
                var fieldName = property.Name;
                var fieldValue = record[fieldName];
                if (fieldValue is string)
                {
                    fieldValue = fieldValue.ToString().Trim();
                }

                property.SetValue(entity, fieldValue);
            }
            return entity;
        }

        public static Grade RecordToGrade(this SqlDataReader record)
        {
            if (record["GradeType"].ToString() == "PassFail")
            {
                var entity = new PassFailGrade();
                entity.Id = (int)record["Id"];
                entity.StudentId = (int)record["StudentId"];
                entity.AssessmentId = (int)record["AssessmentId"];
                entity.Value = record["Value"].ToString();
                return entity;
            }
            else
            {
                var entity = new PointGrade();
                entity.Id = (int)record["Id"];
                entity.StudentId = (int)record["StudentId"];
                entity.AssessmentId = (int)record["AssessmentId"];
                entity.Value = int.Parse(record["Value"].ToString());
                return entity;
            }
        }

        public static Assessment RecordToAssessment(this SqlDataReader record)
        {
            int i = 0;
            if (record["AssessmentType"].ToString() == "Exam")
            {
                var entity = new ExamAssessment
                {
                    Id = (int)record["Id"],
                    Date = (DateTime)record["Date"],
                    GroupId = (int)record["GroupId"],
                    NumberOfSession = (int)record["NumberOfSession"],
                    SubjectId = (int)record["SubjectId"],
                };
                return entity;
            }
            else
            {
                var entity = new TestAssessment
                {
                    Id = (int)record["Id"],
                    Date = (DateTime)record["Date"],
                    GroupId = (int)record["GroupId"],
                    NumberOfSession = (int)record["NumberOfSession"],
                    SubjectId = (int)record["SubjectId"],
                };
                return entity;
            }
        }
    }
}
