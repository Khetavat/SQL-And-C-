DECLARE @Year AS DATE = '1996-01-01'
SET @Year = '1997-02-01';

DECLARE @StartDate AS DATE = '1996-01-01';
DECLARE @EndDate AS DATE = '2020-01-01';
SELECT * FROM Orders o WHERE DATEPART(YEAR,o.OrderDate) >= DATEPART(YEAR,@StartDate) AND DATEPART(YEAR,o.OrderDate) <= DATEPART(YEAR,@EndDate);

SELECT GETDATE()
SELECT CONVERT(NVARCHAR,'1996-01-01',107)

SELECT  * FROM Products p
DECLARE @start AS INT = 10;
DECLARE @end AS INT = 20;
SELECT * FROM Products p WHERE (P.UnitsInStock >= @start OR @start IS NULL) AND (p.UnitsInStock <= @end OR @end IS NULL);

SELECT COUNT(*) FROM Products p WHERE p.UnitsInStock >= 
CASE
WHEN @start IS NULL THEN 0
ELSE @start
END
AND p.UnitsInStock <= 
CASE
WHEN @end IS NULL THEN p.UnitsInStock
ELSE @end
END

SELECT COUNT(*), * FROM Products p WHERE p.UnitsInStock >= ISNULL(@start,0) AND P.UnitsInStock <= ISNULL(@end,P.UnitsInStock);


DECLARE @value AS INT = 10;
SELECT * FROM Products p WHERE p.UnitsInStock = ISNULL(@value,p.UnitsInStock);

DECLARE @ProductName AS NVARCHAR = NULL;
DECLARE @UnitsInStock AS INT = NULL;
DECLARE @ReorderLevel AS INT = NULL;
SELECT * FROM Products p WHERE 
(p.ProductName = @ProductName OR @ProductName IS NULL) AND 
(P.UnitsInStock = @UnitsInStock OR @UnitsInStock IS NULL) AND (P.ReorderLevel = @ReorderLevel OR @ReorderLevel IS NULL);


--Stored Procedure
