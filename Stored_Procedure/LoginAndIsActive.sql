

create procedure Vishal_IsActive
@username as nvarchar(max),
@password as nvarchar(max)
as
begin
declare @id as int = (select id from Vishal_authentication where username = @username and password = @password)
update Vishal_authentication set Isactive = 'Yes' where id = @id;
end

create procedure Vishal_Logout
@username as nvarchar(max),
@password as nvarchar(max)
as
begin
declare @id as int = (select id from Vishal_authentication where username = @username and password = @password)
update Vishal_authentication set Isactive = 'No' where id = 5;
end

execute Vishal_Logout 'admin','admin'