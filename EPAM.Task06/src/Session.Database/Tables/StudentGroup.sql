CREATE TABLE [dbo].[StudentGroup]
(
	[Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Number] NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
