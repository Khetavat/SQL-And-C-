alter procedure Vishal_PaymentPendingReportYearWise
@Year as int,
@CustomerId as nvarchar(max),
@AgentId as nvarchar(max)
as
begin
select Distinct
    vc.firstname as CustomerName, 
    year_month.Year as Year, 
    year_month.MonthId as MonthId, 
    isnull(vp.status,'N/A') as PaymentStatus, 
    va.areaname as Areaname, 
    va1.firstname as AgentName,
    vc.dateofconnection as DateOfConnection,
	(select  count(*) from Vishal_complaints vc2 join Vishal_customers vc3
	on vc2.customerid = vc3.customerid where vc.firstname = vc3.firstname group by vc3.customerid) as TotalComplaint
from 
    (select 2020 as Year, 1 as MonthId union select 2020, 2 union select 2020, 3 union select 2020, 4 union select 2020, 
	5 union select 2020, 6 union select 2020, 7 union select 2020, 8 union select 2020, 9 union select 2020, 10 union select 2020, 
	11 union select 2020, 12 union select 2021, 1 union select 2021, 2 union select 2021, 3 union select 2021, 4 union select 2021, 
	5 union select 2021, 6 union select 2021, 7 union select 2021, 8 union select 2021, 9 union select 2021, 10 union select 2021, 
	11 union select 2021, 12 union select 2022, 1 union select 2022, 2 union select 2022, 3 union select 2022, 4 union select 2022, 
	5 union select 2022, 6 union select 2022, 7 union select 2022, 8 union select 2022, 9 union select 2022, 10 union select 2022, 
	11 union select 2022, 12 union select 2023, 1 union select 2023, 2 union select 2023, 3 ) year_month
    left join Vishal_Customers vc on year(vc.dateofconnection) <= year_month.year
    left join Vishal_Areas va on vc.areaid = va.areaid 
    left join Vishal_Agents va1 on va1.agentid = va.agentid 
    left join Vishal_Payments vp on vc.customerid = vp.customerid and vp.year = year_month.year and vp.MonthId = year_month.MonthId
    left join Vishal_Complaints vc1 on vc.customerid = vc1.customerid
where
	(@year is null or year_month.Year = @year) and (@customerid is null or vc.customerid in (select value from string_split(@customerid,',')) or 
	vc.firstname in (select value from string_split(@customerid,','))) and (@agentid is null or va1.agentid in (select value from string_split(@agentid,',')) or
	va1.firstname in (select value from string_split(@agentid,',')))
group by
	vc.firstname,
    year_month.Year, 
    year_month.MonthId, 
    isnull(vp.status,'N/A'),
    va.areaname, 
    va1.firstname,
    vc.dateofconnection
order by
	year_month.Year
end

execute Vishal_PaymentPendingReportYearWise null,null,null

