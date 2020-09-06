CREATE TABLE [dbo].[Assessment]
(
	[Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Date]            DATE          NOT NULL,
    [SubjectId]       INT           NOT NULL,
    [GroupId]         INT           NOT NULL,
    [NumberOfSession] INT           NOT NULL,
    [AssessmentType]  NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
