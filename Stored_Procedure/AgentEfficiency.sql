create procedure Vishal_AgentEfficiency
as
begin

select 
	va.areaname,
	count(*) TotalComplaints,
	(select count(*) from Vishal_areas va2 join Vishal_agents va1 on va2.agentid = va1.agentid 
	join Vishal_Complaints vc2 on va1.agentid = vc2.agentid where va2.areaname = va.areaname) ComplaintResolveByAgent,
	((cast((select count(*) from Vishal_areas va2 join Vishal_agents va1 on va2.agentid = va1.agentid 
	join Vishal_Complaints vc2 on va1.agentid = vc2.agentid where va2.areaname = va.areaname) as float))/(cast(count(*) as float))*100) Efficiency
from 
	Vishal_Customers vc join Vishal_areas va on vc.areaid = va.areaid join  Vishal_Complaints vc1
	on vc1.customerid = vc.customerid
group by 
	va.areaname
end

execute AgentEfficiency