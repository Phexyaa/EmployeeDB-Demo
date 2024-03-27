CREATE PROCEDURE [dbo].[SpGetEmployeeBySalary]
	@Salary money = 0,
	@GreaterThan binary = 0,
	@LessThan binary = 0,
	@EqualTo binary = 0
AS
BEGIN
	IF @EqualTo = 1
	BEGIN
		SELECT * FROM dbo.Employees WHERE Salary = @Salary
	END
	ELSE IF @GreaterThan = 1 AND @LessThan = 0
	BEGIN 
		SELECT * FROM dbo.Employees WHERE Salary > @Salary
	END
	ELSE IF @LessThan = 1 AND @GreaterThan = 0
	BEGIN
		SELECT * FROM dbo.Employees WHERE Salary < @Salary
	END
END