CREATE PROCEDURE [dbo].[SpGetAllActiveEmployees]
as
begin
Select * From dbo.Employees WHERE IsActive = 1
end