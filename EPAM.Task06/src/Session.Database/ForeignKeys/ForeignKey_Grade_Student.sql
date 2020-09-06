ALTER TABLE [dbo].[Grade]
	ADD CONSTRAINT  [ForeignKey_Grade_Student] 
	FOREIGN KEY ([StudentId]) 
	REFERENCES [dbo].[Student] ([Id])
