
create procedure Vishal_RaiseComplaint
	@CustomerId as int,
	@Description as nvarchar(max)
as
begin
	insert into Vishal_Complaints(Complaint,CustomerId,DateOfComplaint) values(@Description,@CustomerId,GETDATE())
end

execute Vishal_RaiseComplaint 3,'No Signal'

alter PROCEDURE Vishal_CompanitMultipleExpense
	@complaintid as int,
	@MultipleExpense as nvarchar(max),
	@AgentId as int
	
AS
BEGIN
		IF EXISTS (select * from Vishal_Complaints where ComplaintId = @complaintid)
		begin
				declare @xml as xml
				set @xml = cast(@MultipleExpense as xml)
				declare @table as table(expensetypeid nvarchar(max),cost nvarchar(max))
				insert into @table (expensetypeid,cost) 
				SELECT 
					T.c.value('@typeid', 'VARCHAR(50)') AS specification_type,
					T.c.value('@cost', 'VARCHAR(50)') AS specification_value
				FROM @xml.nodes('/Expenses/Expense') AS T(c);

				insert into Vishal_Expenses(ExpenseTypeId,Cost,ComplaintId) 
				(select cast(expensetypeid as int),cast(cost as int),@complaintid from @table 
				where expensetypeid not in (select expensetypeid from Vishal_Expenses where complaintid = @complaintid ))
				
				execute Vishal_ResolveComplaint @complaintid,@AgentId
		
				update ve
				set ve.ExpenseTypeId = t.expensetypeid,ve.Cost = t.cost
				from Vishal_Expenses ve inner join @table t on ve.ExpenseTypeId = t.expensetypeid where ve.ComplaintId = @complaintid

		end

		else
		begin
			print 'No complaint'
		end
END

execute Vishal_CompanitMultipleExpense 5,'<Expenses>
							<Expense typeid="103" cost="650"/>
							<Expense typeid="102" cost="550"/>
							</Expenses>',101



create PROCEDURE Vishal_ResolveComplaint
	@CompanitId as int,
	@MultipleExpense as nvarchar(max)
	
AS
BEGIN
		IF EXISTS (select * from Vishal_Complaints where ComplaintId = @CompanitId)
		begin
				declare @table as table (expense nvarchar(40))
				insert into @table(expense) select value from string_split(@MultipleExpense,',')
			IF not EXISTS (select * from Vishal_Expenses where ComplaintId = @CompanitId)
			begin

				insert into Vishal_Expenses(ExpenseTypeId,Cost,ComplaintId) select 
				(select ExpenseTypeId from Vishal_ExpenseTypes where TypeName =
				substring(expense,1,CHARINDEX(':',expense,1)-1)),
				substring(expense,CHARINDEX(':',expense,1)+1,3),@CompanitId from @table
			end
			else
			begin
				update Vishal_Expenses set ExpenseTypeId = (select ExpenseTypeId from Vishal_ExpenseTypes where TypeName =
				substring(expense,1,CHARINDEX(':',expense,1)-1)),Cost = substring(expense,CHARINDEX(':',expense,1)+1,3) from @table where ComplaintId = @CompanitId
			end
		end

		else
		begin
			print 'No complaint'
		end
END


create procedure Vishal_ResolveComplaint
	@CompanitId as int,
	@ResolvedAgentId as int
	
AS
BEGIN
	update Vishal_Complaints set AgentId = @ResolvedAgentId,ResolvedDate = GETDATE() where ComplaintId = @CompanitId
END



