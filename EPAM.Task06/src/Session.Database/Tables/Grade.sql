CREATE TABLE [dbo].[Grade]
(
	[Id]           INT           IDENTITY (1, 1) NOT NULL,
    [AssessmentId] INT           NOT NULL,
    [StudentId]    INT           NOT NULL,
    [Value]        NVARCHAR (20) NOT NULL,
    [GradeType]    NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
