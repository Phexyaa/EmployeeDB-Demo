CREATE PROCEDURE [dbo].[SpGetEmployeeByAge]
	@Age int = 0,
	@GreaterThan binary = 0,
	@LessThan binary = 0,
	@EqualTo binary = 0
AS
BEGIN
	IF @EqualTo = 1
	BEGIN
		SELECT * FROM dbo.Employees WHERE Age = @Age
	END
	ELSE IF @GreaterThan = 1 AND @LessThan = 0
	BEGIN 
		SELECT * FROM dbo.Employees WHERE Age > @Age
	END
	ELSE IF @LessThan = 1 AND @GreaterThan = 0
		SELECT * FROM dbo.Employees WHERE Age < @Age
END
