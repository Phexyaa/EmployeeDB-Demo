CREATE PROCEDURE [dbo].[SpGetAllInActiveEmployees]
as
begin
Select * From dbo.Employees WHERE IsActive = 0
end