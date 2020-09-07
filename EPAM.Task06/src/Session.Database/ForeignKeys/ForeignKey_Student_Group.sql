USE [SessionDB]
ALTER TABLE [dbo].[Student]
	ADD CONSTRAINT  [ForeignKey_Student_Group] 
	FOREIGN KEY ([GroupId]) 
	REFERENCES [dbo].[StudentGroup] ([Id])