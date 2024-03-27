CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Age] INT NULL, 
    [Salary] INT NOT NULL, 
    [HireDate] DATE NOT NULL
, 
    [EmployeeId] NVARCHAR(50) NOT NULL, 
    [Title] NVARCHAR(50) NOT NULL)
