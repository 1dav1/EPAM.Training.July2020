CREATE TABLE [dbo].[Student]
(
	[Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (20) NOT NULL,
    [Gender]    NVARCHAR (20) NOT NULL,
    [BirthDate] DATE          NOT NULL,
    [GroupId]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
