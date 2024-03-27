CREATE PROCEDURE [dbo].[SpDeleteEmployeeRecord]
	@Id int
AS
	DELETE FROM dbo.Employees WHERE Id = @Id
