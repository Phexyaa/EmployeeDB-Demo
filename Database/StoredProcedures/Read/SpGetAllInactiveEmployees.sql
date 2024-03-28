CREATE PROCEDURE [dbo].[SpGetAllInactiveEmployees]
as
begin
Select * From dbo.Employees WHERE IsActive = 0
end