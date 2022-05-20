----------------------------------------------------
-- 01. Find Names of All Employees by First Name --
----------------------------------------------------
SELECT FirstName,
LastName 
FROM Employees
WHERE FirstName LIKE 'Sa%'

----------------------------------------------------
-- 02. Find Names of All Employees by Last Name --
----------------------------------------------------
SELECT FirstName,
LastName
FROM Employees
WHERE LastName LIKE '%ei%'

-----------------------------------------------
-- 03. Find First Names of All Employess --
-----------------------------------------------
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10)
AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

-----------------------------------------------
-- 04. Find All Employees Except Engineers --
-----------------------------------------------
SELECT FirstName,
LastName
FROM Employees
WHERE JobTitle NOT LIKE '%Engineer%'

------------------------------------------
-- 05. Find Towns with Name Length --
------------------------------------------
SELECT Name
FROM Towns
WHERE DATALENGTH(Name) IN (5, 6)
ORDER BY Name

--------------------------------------
-- 06. Find Towns Starting With --
--------------------------------------
SELECT TownID,
Name
FROM Towns
WHERE LEFT(Name, 1) IN ('M', 'K', 'B', 'E')
ORDER BY Name

--------------------------------------
-- 07. Find Towns Not Starting With --
--------------------------------------
SELECT TownID,
Name
FROM Towns
WHERE LEFT(Name, 1) NOT IN ('R', 'B', 'D')
ORDER BY Name

-------------------------------------------
-- 08. Create View Employees Hired After --
-------------------------------------------
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,
LastName
FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000

-------------------------------
-- 09. Length of Last Name --
-------------------------------
SELECT FirstName,
LastName
FROM Employees
WHERE LEN(LastName) = 5

------------------------------------
-- 10. Rank Employees by Salary --
------------------------------------
SELECT EmployeeID,
FirstName, 
LastName,
Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS RANK
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC	

-------------------------------------------
-- 11. Find All Employees with Rank 2 --
-------------------------------------------
SELECT *
FROM (
       SELECT EmployeeID,
              FirstName,
              LastName,
              Salary,
              DENSE_RANK() over (partition by Salary ORDER BY EmployeeID) AS Rank
       FROM Employees
       WHERE Salary BETWEEN 10000 AND 50000) AS MyTable
WHERE Rank = 2
ORDER BY Salary DESC

--------------------------------
-- 12. Countries Holding 'A' --
--------------------------------
SELECT [CountryName], 
[IsoCode] FROM Countries
WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY IsoCode

---------------------------------------
-- 13. Mix of Peak and River Names --
---------------------------------------
SELECT p.PeakName,
r.RiverName,
LOWER(CONCAT(SUBSTRING(p.PeakName, 1, LEN(p.PeakName)-1), r.RiverName)) AS Mix
FROM Rivers as r, Peaks as p
WHERE LEFT(r.RiverName,1) = RIGHT(p.PeakName, 1)
ORDER BY Mix

---------------------------------------
-- 14. Games From 2011 and 2012 Year --
---------------------------------------
SELECT TOP(50) Name,
FORMAT(Start, 'yyyy-MM-dd') AS Start
FROM Games
WHERE DATEPART(YEAR, Start) IN (2011, 2012)
ORDER BY Start, Name

---------------------------------------
-- 14. Games From 2011 and 2012 Year --
---------------------------------------
SELECT TOP(50) Name,
FORMAT(Start, 'yyyy-MM-dd') AS Start
FROM Games
WHERE DATEPART(YEAR, Start) IN (2011, 2012)
ORDER BY Start, Name

--------------------------------
-- 15. User Email Providers --
--------------------------------
SELECT [Username],
SUBSTRING([Email], CHARINDEX('@', [Email]) + 1,  LEN([Email]) - CHARINDEX('@', [Email]) + 1) AS [Email Provider]
FROM Users
ORDER BY [Email Provider],
[Username]

-------------------------------------------------
-- 16. Get Users with IPAddress Like Pattern --
-------------------------------------------------
SELECT Username,
IpAddress
FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username

----------------------------------------
-- 17. Show All Games with Duration --
----------------------------------------
SELECT [Name] AS [Game],
CASE WHEN DATEPART(HH, [Start]) >= 0 AND DATEPART(HH, [Start]) < 12 THEN 'Morning'
WHEN DATEPART(HH, [Start])  >= 12 AND DATEPART(HH, [Start]) < 18 THEN 'Afternoon'
WHEN DATEPART(HH, [Start])  >= 18 AND DATEPART(HH, [Start]) <24 THEN 'Evening'
END AS [Part of the Day],
CASE WHEN [Duration] <= 3 THEN 'Extra Short'
WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
WHEN [Duration] > 6 THEN 'Long'
WHEN NULLIF([Duration], '') IS NULL THEN 'Extra Long'
END AS [Duration]
FROM Games
ORDER BY [Name], [Duration]

------------------------
-- 18. Orders Table --
------------------------
SELECT[ProductName],
[OrderDate],
DATEADD(DAY, 3, [OrderDate]) AS [Pay Due],
DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
FROM [Orders]
