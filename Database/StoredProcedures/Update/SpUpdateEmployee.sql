CREATE PROCEDURE [dbo].[SpUpdateEmployee]
	@Id int,
	@FirstName nvarChar(50),
	@LastName nvarChar(50),
	@Salary int,
	@Age int,
	@Title nvarchar(50),
	@EmployeeId nvarchar(50),
	@IsActive bit
AS
	UPDATE dbo.Employees SET 
	FirstName = @FirstName,
	LastName = @LastName,
	Salary = @Salary,
	Age = @Age,
	Title = @Title,
	EmployeeId = @EmployeeId,
	IsActive = @IsActive

	WHERE Id = @Id