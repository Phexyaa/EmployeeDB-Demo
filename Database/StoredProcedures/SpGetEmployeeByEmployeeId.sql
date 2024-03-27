CREATE PROCEDURE [dbo].[SpGetEmployeeByEmployeeId]
	@Id int
AS
BEGIN
	SELECT * FROM dbo.Employees WHERE Id = @id
END
