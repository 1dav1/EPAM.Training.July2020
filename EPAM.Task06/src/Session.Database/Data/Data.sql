INSERT INTO [dbo].[StudentGroup] 
			(Number) 
VALUES ('G1'),
	   ('G2'),
	   ('G3')

INSERT INTO [dbo].[Subject]
			(Name)
VALUES ('Subject1'),
	   ('Subject2'),
	   ('Subject3'),
	   ('Subject4'),
	   ('Subject5')

INSERT INTO [dbo].[Student]
			(Name, Gender, BirthDate, GroupId)
VALUES ('Student1', 'Male',	'2020-08-30', 1),
	   ('Student2', 'Female', '1987-01-12',	1),
	   ('Student3', 'Male',	'1986-09-14', 1),
	   ('Student4', 'Male',	'1990-01-20', 2),
	   ('Student5', 'Male',	'1989-05-01', 2),
	   ('Student6', 'Female', '1988-06-03',	2),
	   ('Student6', 'Male',	'1990-03-02', 3),
	   ('Student7', 'Male',	'1990-03-02', 3),
	   ('Student8', 'Male',	'1989-10-02', 3),
	   ('Student9', 'Female', '1980-07-11',	3),
	   ('Student10', 'Male', '1980-07-12', 2),
	   ('Student11', 'Male', '1980-08-12', 3)

INSERT INTO [dbo].[Assessment]
			(Date, SubjectId, GroupId, NumberOfSession, AssessmentType)
VALUES ('2018-08-30', 1, 1, 1, 'Test'),
	   ('2018-08-20', 2, 1, 1, 'Test'),
	   ('2018-08-25', 3, 1, 1, 'Test'),
	   ('2019-08-30', 1, 2, 2, 'Exam'),
	   ('2019-09-01', 4, 2, 2, 'Test'),
	   ('2020-08-10', 5, 3, 3, 'Exam'),
	   ('2020-08-15', 1, 3, 3, 'Exam'),
	   ('2020-08-18', 2, 3, 3, 'Test')

INSERT INTO [dbo].[Grade]
(AssessmentId, StudentId, Value, GradeType)
VALUES (1, 2, 'Pass', 'PassFail'),
	   (1, 3, 'Pass', 'PassFail'),
	   (1, 4, 'Fail', 'PassFail'),
	   (2, 2, 'Pass', 'PassFail'),
	   (2, 3, 'Pass', 'PassFail'),
	   (2, 4, 'Pass', 'PassFail'),
	   (3, 2, 'Pass', 'PassFail'),
	   (3, 3, 'Pass', 'PassFail'),
	   (4, 5, '9', 'Point'),
	   (4, 6, '8', 'Point'),
	   (4, 7, '7', 'Point'),
	   (5, 5, 'Fail', 'PassFail'),
	   (5, 6, 'Pass', 'PassFail'),
	   (5, 7, 'Pass', 'PassFail'),
	   (6, 8, '6', 'Point'),
	   (6, 9, '9', 'Point'),
	   (6, 10, '9', 'Point'),
	   (7, 8, '7', 'Point'),
	   (7, 9, '7', 'Point'),
	   (7, 10, '7', 'Point'),
	   (8, 8, 'Pass', 'PassFail'),
	   (8, 9, 'Pass', 'PassFail'),
	   (8, 10, 'Pass', 'PassFail'),
	   (7, 11, '3', 'Point'),
	   (7, 12, '3', 'Point')