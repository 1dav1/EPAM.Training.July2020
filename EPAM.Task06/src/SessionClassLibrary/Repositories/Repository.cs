using SessionClassLibrary.Entities.Assessment;
using SessionClassLibrary.Entities.Grade;
using SessionClassLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SessionClassLibrary.Repositories
{
    /// <include file='docs.xml' path='docs/members[@name="repository"]/Repository/*'/>
    public class Repository<T> where T : class, new()
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SessionDB;Integrated Security=True";
        private readonly string _tableName;
        private readonly IEnumerable<string> _fields;

        /// <include file='docs.xml' path='docs/members[@name="repository"]/Constructor/*'/>
        public Repository()
        {
            if (typeof(T).Name.Contains("Grade"))
            {
                _tableName = "Grade";
                List<string> tempList = typeof(T)
                                        .GetProperties()
                                        .Select(prop => prop.Name).ToList();
                tempList.Add("GradeType");
                _fields = tempList;
            }
            else if (typeof(T).Name.Contains("Assessment"))
            {
                _tableName = "Assessment";
                List<string> tempList = typeof(T)
                                        .GetProperties()
                                        .Select(prop => prop.Name).ToList();
                tempList.Add("AssessmentType");
                _fields = tempList;
            }
            else
            {
                _tableName = $"{typeof(T).Name}";
                _fields = typeof(T)
                          .GetProperties()
                          .Select(prop => prop.Name);
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="repository"]/Insert/*'/>
        public void Insert(T item)
        {
            var query = $"INSERT INTO [dbo].[{_tableName}] VALUES({_fields.GetParameters()})";
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    foreach (var property in item.GetType().GetProperties())
                    {
                        /* the property 'Value' is of type 'int' in the 'PointGrade' class and
                         * of type enum 'PassFail' in the 'PassFailGrade' class.
                         * convert the two properties to string to bring them to a common type */
                        if (property.Name == "Value")
                        {
                            command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(item).ToString());
                        }
                        else
                        {
                            command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(item));
                        }
                    }

                    switch (typeof(T).Name)
                    {
                        case "PassFailGrade":
                            command.Parameters.AddWithValue("@GradeType", "PassFail");
                            break;
                        case "PointGrade":
                            command.Parameters.AddWithValue("@GradeType", "Point");
                            break;
                        case "ExamAssessment":
                            command.Parameters.AddWithValue("@AssessmentType", "Exam");
                            break;
                        case "TestAssessment":
                            command.Parameters.AddWithValue("@AssessmentType", "Test");
                            break;
                        default:
                            break;
                    }
                    connection.Open();
                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected != 1)
                        {
                            throw new Exception("The record is not inserted.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="repository"]/Update/*'/>
        public void Update(T item)
        {
            var query = $"UPDATE [dbo].[{_tableName}] " +
                        $"SET {_fields.ValuesToParams()} " +
                        $"WHERE [Id]=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    foreach (var property in item.GetType().GetProperties())
                    {
                        if (property.Name == "Value")
                        {
                            command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(item).ToString());
                        }
                        else
                        {
                            command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(item));
                        }
                    }

                    switch (typeof(T).Name)
                    {
                        case "PassFailGrade":
                            command.Parameters.AddWithValue("@GradeType", "PassFail");
                            break;
                        case "PointGrade":
                            command.Parameters.AddWithValue("@GradeType", "Point");
                            break;
                        case "ExamAssessment":
                            command.Parameters.AddWithValue("@AssessmentType", "Exam");
                            break;
                        case "TestAssessment":
                            command.Parameters.AddWithValue("@AssessmentType", "Test");
                            break;
                        default:
                            break;
                    }

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected != 1)
                    {
                        throw new Exception("The record is not found.");
                    }
                }
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="repository"]/Delete/*'/>
        public void Delete(T item)
        {
            var query = $"DELETE FROM [dbo].[{_tableName}] " +
                        $"WHERE [Id]=@Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue($"@Id", item.GetType().GetProperty("Id").GetValue(item));
                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected != 1)
                    {
                        throw new Exception("The record is not found.");
                    }
                }
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="repository"]/GetAll/*'/>
        public IEnumerable<T> GetAll()
        {
            var query = $"SELECT {_fields.GetFields()} FROM [dbo].[{_tableName}]";
            List<T> entities = new List<T>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entities.Add(reader.RecordToModel<T>());
                        }
                    }
                }
            }
            return entities;
        }

        /// <include file='docs.xml' path='docs/members[@name="repository"]/GetAllGrades/*'/>
        public IEnumerable<Grade> GetAllGrades()
        {
            var query = $"SELECT {_fields.GetFields()} FROM [dbo].[{_tableName}]";
            List<Grade> grades = new List<Grade>();
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            grades.Add(reader.RecordToGrade());
                        }
                    }
                }
            }
            return grades;
        }

        /// <include file='docs.xml' path='docs/members[@name="repository"]/GetAllAssessments/*'/>
        public IEnumerable<Assessment> GetAllAssessments()
        {
            var query = $"SELECT {_fields.GetFields()} FROM [dbo].[{_tableName}]";
            List<Assessment> assessments = new List<Assessment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            assessments.Add(reader.RecordToAssessment());
                        }
                    }
                }
            }
            return assessments;
        }

        /// <include file='docs.xml' path='docs/members[@name="repository"]/GetById/*'/>
        public T GetById(int id)
        {
            var query = $"SELECT {_fields.GetFields()} FROM [dbo].[{_tableName}] WHERE [Id]=@Id";
            T entity = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity = reader.RecordToModel<T>();
                        }
                    }
                }
            }
            return entity;
        }

        /// <include file='docs.xml' path='docs/members[@name="repository"]/GetGradeById/*'/>
        public Grade GetGradeById(int id)
        {
            var query = $"SELECT {_fields.GetFields()} FROM [dbo].[{_tableName}] WHERE [Id]=@Id";
            Grade grade = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            grade = reader.RecordToGrade();
                        }
                    }
                }
            }
            return grade;
        }

        /// <include file='docs.xml' path='docs/members[@name="repository"]/GetAssessmentById/*'/>
        public Assessment GetAssessmentById(int id)
        {
            var query = $"SELECT {_fields.GetFields()} FROM [dbo].[{_tableName}] WHERE [Id]=@Id";
            Assessment assessment = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            assessment = reader.RecordToAssessment();
                        }
                    }
                }
            }
            return assessment;
        }
    }
}
