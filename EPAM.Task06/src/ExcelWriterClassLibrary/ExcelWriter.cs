using SessionClassLibrary;
using SessionClassLibrary.Entities.Assessment;
using SessionClassLibrary.Entities.Grade;
using SessionClassLibrary.Repositories;
using System.Collections.Generic;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using Spire.Xls;

namespace ExcelWriterClassLibrary
{
    public static class ExcelWriter
    {
        public static void WriteSessionReport(int session)
        {
            string directory = @"e:\session" + session.ToString();
            string subdirectory = string.Empty;
            if (!Directory.Exists(directory))
            {
                // creating new directory for excel files
                Directory.CreateDirectory(directory);
            }

            // creating repositories
            Repository<StudentGroup> groupsRep = new Repository<StudentGroup>();
            Repository<ExamAssessment> assessRep = new Repository<ExamAssessment>();
            Repository<Student> studentsRep = new Repository<Student>();
            Repository<PointGrade> gradesRep = new Repository<PointGrade>();
            Repository<Subject> subjRep = new Repository<Subject>();

            // retrieving data
            List<Assessment> assessments = (List<Assessment>)assessRep.GetAllAssessments();
            List<StudentGroup> groups = (List<StudentGroup>)groupsRep.GetAll();
            List<Student> students = (List<Student>)studentsRep.GetAll();
            List<Grade> grades = (List<Grade>)gradesRep.GetAllGrades();
            List<Subject> subjects = (List<Subject>)subjRep.GetAll();

            Excel.Application excelApp = new Excel.Application();

            List<Assessment> groupAssessments;  // list of the assessments of the specific group
            List<Student> groupStudents;        // list of the students of the specific group
            string subj = string.Empty;         // string to store the name of the subject

            // for each student group
            for (int k = 0; k < groups.Count; k++)
            {
                StudentGroup group = groups[k];
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                string file = directory + @"\" + group.Number + @".xlsx";
                string[] studInfo = new string[2]; // the array to store information about a student and his grade

                // retrieving students of the group
                groupStudents = students.Where(s => s.GroupId == group.Id).ToList();

                // retrieving assessments (tests or exams) of the group
                groupAssessments = assessments.Where(a => a.GroupId == group.Id).ToList();
                for (int j = 0; j < groupAssessments.Count; j++)
                {
                    Assessment assess = groupAssessments[j];

                    // creating new excel sheet for the assessment
                    Excel.Worksheet worksheet = (Excel.Worksheet)excelApp.Worksheets.Add();
                    int row = 1;
                    int column = 1;
                    subj = subjects.Find(s => s.Id == assess.SubjectId).Name;

                    // setting the name of the subject as the name of the excel sheet
                    worksheet.Name = subj;

                    // creating and setting up the header of the table
                    string[] header = { "Name", "Grade" };
                    Excel.Range headerRange = worksheet.get_Range((Excel.Range)worksheet.Cells[row, column],
                                                                  (Excel.Range)worksheet.Cells[row, column + 1]);
                    headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    headerRange.Font.Bold = true;
                    headerRange.Value = header;
                    row++;
                    Excel.Range studRange;  // the range of the excel sheet that contains the student's data
                    for (int i = 0; i < groupStudents.Count; i++)
                    {
                        Student st = groupStudents[i];
                        studRange = worksheet.get_Range((Excel.Range)worksheet.Cells[row, column], (Excel.Range)worksheet.Cells[row, column + 1]);

                        // student's name
                        studInfo[0] = st.Name;

                        if (assess is ExamAssessment)
                        {
                            PointGrade point = (PointGrade)grades.Find(g => g.StudentId == st.Id && g.AssessmentId == assess.Id);
                            if (point != null)
                            {
                                // student's point grade
                                studInfo[1] = point.Value.ToString();
                            }
                        }
                        else
                        {
                            PassFailGrade pass = (PassFailGrade)grades.Find(g => g.StudentId == st.Id && g.AssessmentId == assess.Id);
                            if (pass != null)
                            {
                                // student's pass/fail grade
                                studInfo[1] = pass.Value;
                            }
                        }

                        if (studInfo[1] != null)
                        {
                            studRange.Value = studInfo;
                        }
                        row++;
                    }

                    // setting the autofilter
                    Excel.AutoFilter filter = worksheet.AutoFilter;
                    Excel.Range filteringRange = worksheet.get_Range((Excel.Range)worksheet.Cells[1, column], (Excel.Range)worksheet.Cells[row, column + 1]);
                    filteringRange.AutoFilter(1);
                    filteringRange.AutoFilter(2);
                }
                workbook.SaveAs(file);
                workbook.Close();
            }
        }

        public static void WritePivot()
        {
            Workbook workbook = new Workbook();
            Worksheet sourceSheet = workbook.Worksheets[0];
            Worksheet pivotSheet = workbook.Worksheets[1];
            sourceSheet.Name = "Data";
            pivotSheet.Name = "Summary";
            string directory = @"e:\session1";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string file = directory + @"\pivot.xlsx";

            int row = 1;                // row counter for setting the data range

            // creating repositories
            Repository<StudentGroup> groupsRep = new Repository<StudentGroup>();
            Repository<ExamAssessment> assessRep = new Repository<ExamAssessment>();
            Repository<Student> studentsRep = new Repository<Student>();
            Repository<PointGrade> gradesRep = new Repository<PointGrade>();
            Repository<Subject> subjRep = new Repository<Subject>();

            // retrieving data
            List<Assessment> assessments = (List<Assessment>)assessRep.GetAllAssessments();
            List<StudentGroup> groups = (List<StudentGroup>)groupsRep.GetAll();
            List<Student> students = (List<Student>)studentsRep.GetAll();
            List<Grade> grades = (List<Grade>)gradesRep.GetAllGrades();
            List<Subject> subjects = (List<Subject>)subjRep.GetAll();

            List<Grade> studGrades;     // grades of the specific student
            string subj = string.Empty; // string to store the name of the subject

            // writing header of the source table
            string[] header = { "Name", "Group", "Subject", "Grade", };
            CellRange headerRange = sourceSheet.Range["A1:D1"];
            headerRange["A1"].Value = header[0];
            headerRange["B1"].Value = header[1];
            headerRange["C1"].Value = header[2];
            headerRange["D1"].Value = header[3];

            string[] studData = new string[3];  // array to store data of the specific student
            CellRange dataRange;                // range of the excel sheet to write data

            foreach (var student in students)
            {
                studData[0] = student.Name;
                var group = groups.Find(g => g.Id == student.GroupId);
                studData[1] = group.Number;
                studGrades = grades.Where(g => g.StudentId == student.Id).ToList();
                foreach (var grade in studGrades)
                {
                    int subjId = assessments.Find(a => a.Id == grade.AssessmentId).SubjectId;
                    string subject = subjects.Find(s => s.Id == subjId).Name;
                    studData[2] = subject;

                    // retrieving only point grades to calculate average, select min and max
                    if (grade is PointGrade point)
                    {
                        row++;
                        dataRange = sourceSheet.Range["A" + row + ":D" + row];
                        dataRange["A" + row].Value = studData[0];
                        dataRange["B" + row].Value = studData[1];
                        dataRange["C" + row].Value = studData[2];
                        dataRange["D" + row].Value = point.Value.ToString();
                    }
                }
            }

            // range of the excel sheet that contains source data for pivot table
            CellRange sourceRange = sourceSheet.Range["A1:D" + row];

            // creating cache of pivot table
            PivotCache cache = workbook.PivotCaches.Add(sourceRange);

            // creating pivot table
            PivotTable table = pivotSheet.PivotTables.Add("Pivot Table", sourceSheet.Range["A1"], cache);

            // creating field of the pivot table
            var groupField = table.PivotFields["Group"];
            groupField.Axis = AxisTypes.Row;

            // adding Average, Min and Max fields
            table.DataFields.Add(table.PivotFields["Grade"], "AverageGrade", SubtotalTypes.Average);
            table.DataFields.Add(table.PivotFields["Grade"], "MinGrade", SubtotalTypes.Min);
            table.DataFields.Add(table.PivotFields["Grade"], "MaxGrade", SubtotalTypes.Max);

            workbook.SaveToFile(file, ExcelVersion.Version2016);
        }

        public static void GetExpulsionList()
        {
            Workbook workbook = new Spire.Xls.Workbook();
            Worksheet sourceSheet = workbook.Worksheets[0];
            Worksheet pivotSheet = workbook.Worksheets[1];
            sourceSheet.Name = "Data";
            pivotSheet.Name = "Summary";

            string directory = @"e:\session1";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string file = directory + @"\expulsionlist.xlsx";

            // creating repositories
            Repository<StudentGroup> groupsRep = new Repository<StudentGroup>();
            Repository<ExamAssessment> assessRep = new Repository<ExamAssessment>();
            Repository<Student> studentsRep = new Repository<Student>();
            Repository<PointGrade> gradesRep = new Repository<PointGrade>();
            Repository<Subject> subjRep = new Repository<Subject>();

            // retrieving data
            List<Assessment> assessments = (List<Assessment>)assessRep.GetAllAssessments();
            List<StudentGroup> groups = (List<StudentGroup>)groupsRep.GetAll();
            List<Student> students = (List<Student>)studentsRep.GetAll();
            List<Grade> grades = (List<Grade>)gradesRep.GetAllGrades();
            List<Subject> subjects = (List<Subject>)subjRep.GetAll();

            List<Student> groupStudents;
            List<PointGrade> pointGrades = (from g in grades
                                            where g is PointGrade
                                            select g).Cast<PointGrade>().ToList();
            List<PointGrade> lowGrades;
            string[] header = { "Group", "Name", };
            CellRange headerRange = sourceSheet.Range["A1:B1"];
            headerRange["A1"].Value = header[0];
            headerRange["B1"].Value = header[1];
            int row = 1;

            string groupNumber = string.Empty;  // array to store data of the specific student
            CellRange dataRange;                // range of the excel sheet to write data

            foreach (var g in groups)
            {
                groupNumber = g.Number;

                lowGrades = (from lg in pointGrades
                             where lg.Value < 4
                             select lg).ToList();

                groupStudents = (from s in students
                                 join gr in lowGrades on s.Id equals gr.StudentId
                                 where s.GroupId == g.Id
                                 select s).ToList();

                foreach (var s in groupStudents)
                {
                    row++;
                    dataRange = sourceSheet.Range["A" + row + ":B" + row];
                    dataRange["A" + row].Value = groupNumber;
                    dataRange["B" + row].Value = s.Name;
                }
            }

            // range of the excel sheet that contains source data for pivot table
            CellRange sourceRange = sourceSheet.Range["A1:B" + row];

            // creating cache of pivot table
            PivotCache cache = workbook.PivotCaches.Add(sourceRange);

            // creating pivot table
            PivotTable table = pivotSheet.PivotTables.Add("Pivot Table", sourceSheet.Range["A1"], cache);

            // creating field for group numbers of the pivot table
            var groupField = table.PivotFields["Group"];
            groupField.Axis = AxisTypes.Row;

            // creating field for names of the pivot table
            var nameField = table.PivotFields["Name"];
            nameField.Axis = AxisTypes.Row;

            workbook.SaveToFile(file, ExcelVersion.Version2016);
        }
    }
}
