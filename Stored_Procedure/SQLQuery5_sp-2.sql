DECLARE @ProductId AS NVARCHAR = '1 2 3';
DECLARE @CategoryId AS NVARCHAR = NULL;
DECLARE @Startdate AS DATE = '2021-01-02';
DECLARE @Enddate AS DATE = '2024-01-02';
DECLARE @ExpireMonth AS DATE = NULL;
SELECT 
	CONCAT(P.ProductName,' ',c.CategoryName) AS ProductName_CategoryName,
	p.UnitsInStock AS AvailableUnits,
	p.Discontinued AS IsNotAvailable,
	CASE
		WHEN @ExpireMonth IS NOT NULL THEN 'Yes'
		ELSE 'N/A'
	END AS ExpirayDate,
	CASE
		WHEN p.UnitsOnOrder < 10 THEN 1
		ELSE 0
	END AS NeedToOrder,
	CASE
		WHEN @startdate IS NOT NULL THEN 'Yes'
		WHEN @enddate IS NOT NULL THEN 'Yes'
		WHEN @startdate IS NULL AND @enddate IS NULL THEN 'N/A'
	END AS IsExpiring

FROM 
	Products p INNER JOIN Categories c ON P.CategoryID = c.CategoryID
WHERE
	(@ProductId IS NULL OR p.ProductID IN (SELECT Value FROM STRING_SPLIT(@ProductId,' ') )) 
	AND (@CategoryId IS NULL OR c.CategoryID IN (SELECT Value FROM STRING_SPLIT(@categoryId,' ')))