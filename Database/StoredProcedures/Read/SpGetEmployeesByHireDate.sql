CREATE PROCEDURE [dbo].[SpGetEmployeeByHireDate]
	@HireDate date,
	@GreaterThan bit = 0,
	@LessThan bit = 0,
	@EqualTo bit = 0
AS
BEGIN
	IF @EqualTo = 1
	BEGIN
		SELECT * FROM dbo.Employees WHERE HireDate = @HireDate
	END
	ELSE IF @GreaterThan = 1 AND @LessThan = 0
	BEGIN
		SELECT * FROM dbo.Employees WHERE HireDate > @HireDate
	END
	ELSE IF @LessThan = 1 AND @GreaterThan = 0
	BEGIN
		SELECT * FROM dbo.Employees WHERE HireDate < @HireDate
	END
END