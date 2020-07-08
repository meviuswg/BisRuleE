CREATE TABLE [dbo].[EventData]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(255),
	[EntityTypeName] VARCHAR(255),
	[Namespace] VARCHAR(255),
	[PreviousValue] VARCHAR(max),
	[CurrentValue] VARCHAR(max),
	[Created] DATETIME

)
