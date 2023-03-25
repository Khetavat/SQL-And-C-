SELECT 'vishal' AS FirstName,'khetavat' AS LastName,ISNULL(Fax,ISNULL(Region,'N/A')) AS Contact,Fax,Region FROM Customers;

SELECT 'vishal' AS FirstName,'khetavat' AS LastName,COALESCE(fax,'N/A',Region) AS Contact,Fax,Region FROM Customers;

SELECT fax + Region + City + ''  AS 'UsingAddition' ,fax,Region,City, CONCAT(fax,Region,city) AS 'UsingConcat'  FROM Customers;




