CREATE TABLE [dbo].[News]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [body] VARCHAR(5000) NULL, 
    [heading] VARCHAR(1000) NULL, 
    [date] DATETIME NULL
)
