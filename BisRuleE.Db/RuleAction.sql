CREATE TABLE [dbo].[RuleAction]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[RuleId] INT NOT NULL,
	[ActionType] VARCHAR(200),
	[ActionDate] VARCHAR(max)
)
