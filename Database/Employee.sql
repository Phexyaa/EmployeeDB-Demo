CREATE TABLE [dbo].[People]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Age] INT NULL, 
    [Salary] INT NOT NULL, 
    [HireDate] DATETIME NOT NULL
, 
    [EmpoloyeeId] NVARCHAR(50) NULL)
