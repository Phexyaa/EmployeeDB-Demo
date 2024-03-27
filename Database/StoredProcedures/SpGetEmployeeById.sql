CREATE PROCEDURE [dbo].[SpGetEmployeeById]
	@EmployeeId nvarchar(50)
AS
BEGIN
	SELECT * FROM dbo.Employees WHERE @EmployeeId = EmployeeId
END
