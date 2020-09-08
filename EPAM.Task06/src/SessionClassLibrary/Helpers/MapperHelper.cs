using SessionClassLibrary.Entities.Assessment;
using SessionClassLibrary.Entities.Grade;
using System;
using System.Data.SqlClient;

namespace SessionClassLibrary.Helpers
{
    /// <include file='docs.xml' path='docs/members[@name="mapperhelper"]/MapperHelper/*'/>
    public static class MapperHelper
    {
        /// <include file='docs.xml' path='docs/members[@name="mapperhelper"]/RecordToModel/*'/>
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

        /* specific method for 'Grade' entities. used in case of retreiving a list of grades.
           if a generic list of base class 'Grade' is used to store the entities, 
           the generic method cannot be used */
        /// <include file='docs.xml' path='docs/members[@name="mapperhelper"]/RecordToGrade/*'/>
        public static Grade RecordToGrade(this SqlDataReader record)
        {
            if (record["GradeType"].ToString() == "PassFail")
            {
                var entity = new PassFailGrade
                {
                    Id = (int)record["Id"],
                    StudentId = (int)record["StudentId"],
                    AssessmentId = (int)record["AssessmentId"],
                    Value = record["Value"].ToString()
                };
                return entity;
            }
            else
            {
                var entity = new PointGrade
                {
                    Id = (int)record["Id"],
                    StudentId = (int)record["StudentId"],
                    AssessmentId = (int)record["AssessmentId"],
                    Value = int.Parse(record["Value"].ToString())
                };
                return entity;
            }
        }

        /* specific method for 'Grade' entities. used in case of retreiving a list of assessments.
           if a generic list of base class 'Assessment' is used to store the entities, 
           the generic method cannot be used */
        /// <include file='docs.xml' path='docs/members[@name="mapperhelper"]/RecordToAssessment/*'/>
        public static Assessment RecordToAssessment(this SqlDataReader record)
        {
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
