CREATE PROCEDURE [dbo].[SpInsertEmployee]
	@FirstName nvarChar(50),
	@LastName nvarChar(50),
	@Salary int,
	@Age int,
	@Title nvarchar(50),
	@EmployeeId nvarchar(50),
	@IsActive bit
AS
	INSERT INTO dbo.Employees (FirstName, LastName, Salary, Age, Title, EmployeeId, IsActive) 
	VALUES (@FirstName, @LastName, @Salary, @Age, @Title, @EmployeeId, @IsActive)

