SELECT CONCAT(DATEPART(DAY,OrderDate),'-',DATEPART(Month,OrderDate),'-',DATEPART(YEAR,OrderDate)),OrderDate FROM Orders;

SELECT * FROM Orders o WHERE o.OrderDate >= '1996';

SELECT * FROM Orders o WHERE o.OrderDate BETWEEN '1996' AND '1998';


SELECT CONVERT(NVARCHAR,o.OrderDate,107),o.OrderDate FROM Orders o
SELECT CONVERT(NVARCHAR,o.OrderDate,106),o.OrderDate FROM Orders o

SELECT * FROM Orders o WHERE o.OrderDate BETWEEN '2019' AND '2023';
SELECT * FROM Orders WHERE OrderDate IN (orderDate,DATEADD(YEAR,-3,OrderDate));

SELECT * FROM Customers;

SELECT SUBSTRING(c.ContactName,1,CHARINDEX(' ',c.ContactName)) AS FirstName,SUBSTRING(c.ContactName,CHARINDEX(' ',c.ContactName),LEN(c.ContactName)) AS LastName FROM Customers c;

CREATE TABLE User_Vishal(
Id INT PRIMARY KEY,
UserName NVARCHAR(20),
Password NVARCHAR(20),
FirstName NVARCHAR(20),
LastName NVARCHAR(20),
DateOfBirth DATE,
Location NVARCHAR(20),
CityId INT
)


INSERT INTO User_Vishal VALUES (1,'admin','admin','vishal','khetavat','12-02-2001','Pune',10);
INSERT INTO User_Vishal VALUES (2,'test','test','pradip','Bhor','12-02-2001','Pune',11);

SELECT * FROM User_Vishal;

SELECT CONCAT(FirstName,' ',LastName) AS FullName,DATEDIFF(YEAR,DateOfBirth,GETDATE()) AS Age,CAST( FROM User_Vishal;

SELECT * FROM User_Vishal WHERE Location = 'Pune';

SELECT 
CASE 
WHEN od.Quantity > 50 THEN 'Hi'
WHEN od.Quantity > 40 THEN 'Medium'
ELSE cast(od.Quantity AS NVARCHAR(20))
END AS Quantity
FROM [Order Details] od;

SELECT * FROM Products p WHERE p.CategoryID IS not NULL;
SELECT * FROM Categories c;

SELECT P.ProductName,c.CategoryName FROM Products p INNER JOIN Categories c ON P.CategoryID = c.CategoryID;

SELECT c.CategoryName,COUNT(*) FROM  Categories c INNER JOIN Products p ON P.CategoryID = c.CategoryID GROUP BY c.CategoryName;

CREATE DATABASE hello;
