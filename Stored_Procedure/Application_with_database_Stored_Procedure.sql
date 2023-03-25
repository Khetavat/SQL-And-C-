


alter procedure Vishal_InsertIntoPayments
	@Year as nvarchar(20),
	@MonthId as int,
	@CustomerId as int,
	@Status as nvarchar(20),
	@PaymentMethodid as int

as
begin
	if exists (select * from Vishal_customers where customerid = @customerid)
	begin
	insert into Vishal_Payments values(@year,@monthid,@customerid,@status,@paymentmethodid)
	end
end


alter procedure Vishal_PaymentPendingReport

as
begin
	select vp.customerid,concat(vc.firstname,' ',vc.lastname) as CustomerName,va.areaname,concat(va1.firstname,' ',va1.lastname) as Agentname,sum(plancost) as [PendingAmount] 
from Vishal_Payments vp inner join Vishal_Plans vp1 on vp.customerid = vp1.customerid 
inner join Vishal_customers vc on vp.customerid = vc.customerid inner join Vishal_Areas va on vc.areaid = va.areaid
inner join Vishal_agents va1 on va1.agentid = va.agentid
where vp.status = 'Not Paid'
group by 
	vp.customerid,
	concat(vc.firstname,' ',vc.lastname),
	va.areaname,
	concat(va1.firstname,' ',va1.lastname)
end

execute Vishal_PaymentPendingReport


create procedure Vishal_TodayComplaint
as
begin
select 
	vc.customerid,
	va.areaname,
	va1.agentid,
	count(vc1.complaint) as TotalComplaint
from Vishal_customers vc inner join Vishal_Areas va on vc.areaid = va.areaid
inner join Vishal_agents va1 on va1.agentid = va.agentid join Vishal_Complaints vc1 on vc.customerid = vc1.customerid
where vc1.Agentid is null
group by 
	vc.customerid,
	va.areaname,
	va1.agentid
end
select * from Vishal_areas




