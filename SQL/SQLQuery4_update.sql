SELECT * FROM Vishal_Complaints vc
ALTER TABLE dbo.Vishal_Complaints
	ADD ResolvedDate DATE  -- COLLATE Latin1_General_CI_AS
	-- CONSTRAINT DF_Vishal_Complaints_DateOfComplaint DEFAULT NULL
GO
SELECT * FROM Vishal_Customers vc
UPDATE Vishal_Complaints SET ResolvedDate = '2021-04-15' WHERE CustomerId = 2
UPDATE Vishal_Complaints SET AgentId = null WHERE ComplaintId = 5


SELECT * FROM Vishal_Expenses ve
SELECT * FROM Vishal_ExpenseTypes vet