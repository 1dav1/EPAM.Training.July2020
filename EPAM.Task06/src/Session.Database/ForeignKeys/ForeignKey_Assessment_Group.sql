ALTER TABLE [dbo].[Assessment]
	ADD CONSTRAINT  [ForeignKey_Assessment_Group] 
	FOREIGN KEY ([GroupId]) 
	REFERENCES [dbo].[StudentGroup] ([Id])
