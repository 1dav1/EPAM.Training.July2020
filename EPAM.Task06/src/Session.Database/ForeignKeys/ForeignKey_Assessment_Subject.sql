USE [SessionDB]
ALTER TABLE [dbo].[Assessment]
	ADD CONSTRAINT  [ForeignKey_Assessment_Subject] 
	FOREIGN KEY ([SubjectId]) 
	REFERENCES [dbo].[Subject] ([Id])
