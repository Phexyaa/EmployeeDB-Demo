CREATE PROCEDURE [dbo].[SpGetEmployeeByTitle]
	@Title nvarchar(50) 
AS
BEGIN
	SELECT * FROM dbo.Employees WHERE Title LIKE @Title
END
