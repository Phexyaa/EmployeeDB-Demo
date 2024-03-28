CREATE PROCEDURE [dbo].[SpGetEmployeeByDatabaseId]
	@EmployeeId nvarchar(50)
AS
BEGIN
	SELECT * FROM dbo.Employees WHERE @EmployeeId = EmployeeId
END
