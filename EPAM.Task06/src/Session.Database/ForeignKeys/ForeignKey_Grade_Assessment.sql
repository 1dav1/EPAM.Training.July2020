USE [SessionDB]
ALTER TABLE [dbo].[Grade]
	ADD CONSTRAINT  [ForeignKey_Grade_Assessment] 
	FOREIGN KEY ([AssessmentId]) 
	REFERENCES [dbo].[Assessment] ([Id])
