

alter procedure Vishal_InsertIntoUsersWithReference
	@RoleId as int,
	@Firstname as nvarchar(20),
	@Lastname as nvarchar(20),
	@DateOfBirth as nvarchar(20),
	@DateOfConnection as nvarchar(20),
	@Planid as int,
	@Areaid as int,
	@Username as nvarchar(max),
	@Password as nvarchar(50)
as
begin
	if @RoleId = 1
	begin
		insert into Vishal_Authentication(username,password,roleid,isactive,referenceid) 
		values(@Username,@Password,@Roleid,'No',null)
	end
	else
	begin
		insert into Vishal_customers(Firstname,lastname,dateofbirth,dateofconnection,planid,areaid) 
		values(@Firstname,@lastname,@DateOfBirth,@DateOfConnection,@Planid,@Areaid)
		declare @id as int = @@Identity
		insert into Vishal_Authentication(username,password,roleid,isactive,referenceid) 
		values(@Username,@Password,@Roleid,'No',@id)
	end
end


create procedure Vishal_InsertIntoUsersReferenceWithAgent
	@RoleId as int,
	@Firstname as nvarchar(20),
	@Lastname as nvarchar(20),
	@Username as nvarchar(max),
	@Password as nvarchar(50)
as
begin
		insert into Vishal_agents(Firstname,lastname) 
		values(@Firstname,@lastname)
		declare @id as int = @@Identity
		insert into Vishal_Authentication(username,password,roleid,isactive,referenceid) 
		values(@Username,@Password,@Roleid,'No',@id)
end



