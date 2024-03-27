﻿CREATE PROCEDURE [dbo].[SpGetEmployeeByName]
	@FirstName nvarchar(50),
	@lastName nvarchar(50)
AS
BEGIN
	IF @FirstName is not NULL AND @LastName is NULL
	BEGIN
		SELECT * FROM dbo.Employees WHERE @FirstName LIKE FirstName
	END
	IF @LastName is not NULL AND @FirstName is NULL
	BEGIN
		SELECT * From dbo.Employees WHERE @LastName LIKE FirstName
	END
	IF @FirstName is not NULL AND @LastName is not NULL
	BEGIN
		SELECT * FROM dbo.Employees WHERE @FirstName LIKE FirstName AND @LastName LIKE LastName
	END
END