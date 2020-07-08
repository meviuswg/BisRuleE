CREATE TABLE [dbo].[Rules]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100),
	[EntityTypeName] VARCHAR(255),
	[Namespace] VARCHAR(255),
	[RulesSet] VARCHAR(max),
	[RuleGroup] VARCHAR(255),
	[Order] INT
)
