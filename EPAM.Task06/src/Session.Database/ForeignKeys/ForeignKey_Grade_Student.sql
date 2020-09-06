ALTER TABLE [dbo].[Grade]
	ADD CONSTRAINT  [ForeignKey_Grade_Assessment] 
	FOREIGN KEY ([StudentId]) 
	REFERENCES [dbo].[Student] ([Id])
