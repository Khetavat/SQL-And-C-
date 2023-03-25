


1)
SELECT * FROM Vishal_Areas;
SELECT * FROM Vishal_Customers vc;
SELECT va.AreaName,COUNT(*) FROM  Vishal_Areas va INNER JOIN Vishal_Customers vc ON vc.AreaId = va.AreaId GROUP BY va.AreaName

2)
SELECT * FROM Vishal_Areas;
SELECT * FROM Vishal_Complaints vc;
SELECT * FROM Vishal_Customers vc;
SELECT va.AreaName,COUNT(*)  FROM Vishal_Customers vc1 INNER JOIN Vishal_Areas va ON vc1.AreaId = va.AreaId INNER JOIN Vishal_Complaints vc ON vc1.CustomerId = vc.CustomerId GROUP BY va.AreaName

3)
SELECT * FROM Vishal_ExpenseTypes;
SELECT * FROM Vishal_Expenses ve
SELECT ve.ExpenseTypeId,vet.TypeName,SUM(ve.Cost) AS TotalCost FROM Vishal_Expenses ve INNER JOIN Vishal_ExpenseTypes vet ON ve.ExpenseTypeId = vet.ExpenseTypeId GROUP BY ve.ExpenseTypeId,vet.TypeName

4)
SELECT * FROM Vishal_Complaints vc;
SELECT * FROM Vishal_Expenses ve
SELECT ve.ComplaintId,SUM(ve.Cost) AS TotalCost FROM Vishal_Expenses ve INNER JOIN Vishal_Complaints vc ON ve.ComplaintId = vc.ComplaintId GROUP BY ve.ComplaintId

5)
SELECT * FROM Vishal_Complaints vc;
SELECT * FROM Vishal_Agents va
SELECT COUNT(*) FROM Vishal_Complaints vc WHERE vc.AgentId = 100;

7)
SELECT * FROM Vishal_Complaints vc;
SELECT * FROM Vishal_Expenses ve
SELECT * FROM Vishal_Customers vc
SELECT va.AreaName,sum(ve.Cost) AS TotalCost  FROM Vishal_Areas va  INNER JOIN Vishal_Customers vc ON va.AreaId = vc.AreaId INNER JOIN Vishal_Complaints vc1 ON vc.CustomerId = vc1.CustomerId INNER JOIN Vishal_Expenses ve ON ve.ComplaintId = vc1.ComplaintId  GROUP BY va.AreaName

8)
SELECT * FROM Vishal_Expenses ve
SELECT SUM(ve.Cost) FROM Vishal_Expenses ve

9)
SELECT * FROM Vishal_Expenses ve
SELECT * FROM Vishal_Complaints vc
SELECT SUM(ve.Cost) FROM Vishal_Expenses ve INNER JOIN Vishal_Complaints vc ON ve.ComplaintId = vc.ComplaintId WHERE vc.ResolvedDate BETWEEN '2019-01-01' and '2022-02-01'

--for 1 Agent
SELECT sum(ve.Cost) FROM Vishal_Expenses ve INNER JOIN Vishal_Complaints vc ON ve.ComplaintId = vc.ComplaintId WHERE vc.AgentId = 100;

--for 1 Area
SELECT sum(ve.Cost) FROM Vishal_Expenses ve INNER JOIN Vishal_Complaints vc ON ve.ComplaintId = vc.ComplaintId INNER JOIN Vishal_Areas va ON vc.AgentId = va.AgentId WHERE va.AreaName = 'Pimpri';

--for 1 ExpenseType
SELECT sum(ve.Cost) FROM Vishal_Expenses ve INNER JOIN Vishal_ExpenseTypes vet ON ve.ExpenseTypeId = vet.ExpenseTypeId WHERE vet.TypeName = 'wire'


10)
SELECT * FROM Vishal_Customers vc
SELECT * FROM Vishal_Agents va
SELECT * FROM Vishal_Areas va
SELECT va.FirstName FROM Vishal_Areas va INNER JOIN Vishal_Customers vc ON va.AreaId = vc.AreaId INNER JOIN Vishal_Agents va1 ON va1.AgentId = va.AgentId WHERE vc.CustomerId = 1; 

11)
UPDATE Vishal_Customers SET PackageId = 100 WHERE CustomerId = 1

SELECT * FROM Vishal_Payments vp
SELECT * FROM Vishal_Customers vc
SELECT * FROM Vishal_Plans vp
SELECT vp1.CustomerId ,SUM(vp.PlanCost) FROM Vishal_Customers vc INNER JOIN Vishal_Plans vp ON vc.PackageId = vp.PlanId INNER JOIN Vishal_Payments vp1 ON vc.CustomerId = vp1.CustomerId WHERE vp1.Status = 'Not Paid'  GROUP BY vp1.CustomerId 

12)
SELECT vp1.CustomerId ,SUM(vp.PlanCost) FROM Vishal_Customers vc INNER JOIN Vishal_Plans vp ON vc.PackageId = vp.PlanId INNER JOIN Vishal_Payments vp1 ON vc.CustomerId = vp1.CustomerId WHERE vp1.Status = 'Paid' AND vp1.year = 2023 GROUP BY vp1.CustomerId 

13)
SELECT vp1.CustomerId ,count(vp1.MonthId) FROM Vishal_Customers vc INNER JOIN Vishal_Plans vp ON vc.PackageId = vp.PlanId INNER JOIN Vishal_Payments vp1 ON vc.CustomerId = vp1.CustomerId WHERE vp1.Status = 'Not Paid'  GROUP BY vp1.CustomerId 

15)
SELECT CustomerId FROM Vishal_Customers WHERE DateOfConnection = (SELECT MIN(DateOfConnection) FROM Vishal_Customers)

16)
SELECT CustomerId FROM Vishal_Customers WHERE DATEPART(YEAR,DateOfConnection) = (SELECT DATEADD(MONTH,5,DateOfConnection) FROM Vishal_Customers)
