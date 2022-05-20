----------------------------
-- 01. Employee Address --
----------------------------
SELECT TOP(5)
e.EmployeeID,
e.JobTitle,
e.AddressID,
a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

--------------------------------
-- 02. Addresses with Towns --
--------------------------------
SELECT TOP(50) 
e.FirstName,
e.LastName,
t.Name AS Town,
a.AddressText
FROM Employees AS e LEFT JOIN Addresses AS a ON e.AddressID = a.AddressID 
LEFT JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName ASC, e.LastName

----------------------------
-- 03. Sales Employees --
----------------------------
SELECT e.EmployeeID,
e.FirstName,
e.LastName,
d.Name AS DepartmentName
FROM Employees AS e 
LEFT JOIN Departments as d
ON e.DepartmentID = d.DepartmentID
WHERE Name = 'Sales'
ORDER BY EmployeeID ASC

-------------------------------
-- 04. Employee Departments --
--------------------------------
SELECT TOP(5)
e.EmployeeID,
e.FirstName,
e.Salary,
d.Name
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY d.DepartmentID

------------------------------------
-- 05. Employees Without Projects --
------------------------------------
SELECT TOP(3)
e.EmployeeID,
e.FirstName
FROM Employees AS e LEFT OUTER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ProjectID IS NULL
ORDER BY EmployeeID

--------------------------------
-- 06. Employees Hired After --
--------------------------------
SELECT e.FirstName,
e.LastName,
e.HireDate,
d.Name AS DeptName
FROM Employees AS e 
JOIN Departments as d
ON e.DepartmentID = d.DepartmentID
WHERE Name IN ('Sales', 'Finance') AND HireDate > '01-01-1999'
ORDER BY e.HireDate ASC

--------------------------------
-- 07. Employees With Project --
--------------------------------
SELECT TOP(5)
e.EmployeeID,
e.FirstName,
p.Name
FROM Employees AS e JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

----------------------
-- 08. Employee 24 --
----------------------
SELECT
e.EmployeeID,
e.FirstName,
p.Name AS ProjectName
FROM Employees AS e JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
LEFT OUTER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
AND p.StartDate < '20050101'
WHERE ep.EmployeeID = 24

---------------------------
-- 09. Employee Manager --
---------------------------
SELECT e.EmployeeID,
e.FirstName, 
e.ManagerID,
m.FirstName AS ManagerName
FROM Employees AS e join Employees as m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)

---------------------------
-- 10. Employees Summary --
---------------------------
SELECT TOP(50)
e.EmployeeID,
e.FirstName + ' ' + e.LastName AS EmployeeName,
m.FirstName + ' ' + m.LastName AS ManagerName,
d.Name AS DepartmentName
FROM Employees AS e
LEFT JOIN Employees AS m ON m.EmployeeID = e.ManagerID
LEFT JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID ASC

-----------------------------
-- 11. Min Average Salary --
-----------------------------
SELECT MIN(s.AvgSalary) AS MinAverageSalary FROM 
(SELECT AVG(Salary) AS AvgSalary FROM Employees GROUP BY DepartmentID) AS s	

-------------------------------------
-- 12. Highest Peaks in Bulgaria --
-------------------------------------
SELECT c.CountryCode,
m.MountainRange,
p.PeakName,
p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Peaks AS p on mc.MountainId = p.MountainId
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--------------------------------
-- 13. Count Mountain Ranges --
--------------------------------
SELECT c.CountryCode,
COUNT(*) AS MountainRanges
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE c.CountryCode IN ('BG', 'RU', 'US') 
GROUP BY c.CountryCode

-------------------------------------------
-- 14. Countries With or Without Rivers --
-------------------------------------------
SELECT TOP(5)
c.CountryName,
r.RiverName
FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT OUTER JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName ASC

------------------------------------
-- 15. Continents and Currencies --
------------------------------------
SELECT ContinentCode,
CurrencyCode,
CurrencyCount AS CurrencyUsage FROM 
(SELECT *,
DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY [CurrencyCount] DESC) AS CurrencyRank
FROM
(SELECT [ContinentCode], [CurrencyCode], COUNT([CurrencyCode]) AS [CurrencyCount] FROM [Countries]
GROUP BY [ContinentCode], [CurrencyCode]) AS [CurrencyCountQuery]
WHERE [CurrencyCount] > 1) AS [CurrencyRankingSubquery]
WHERE CurrencyRank = 1

-------------------------------------------
-- 16. Countries Without any Mountains --
-------------------------------------------
SELECT COUNT(CountriesWithoutMountainsQuery.CountryName) AS Count
FROM
(SELECT c.CountryName FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode 
WHERE mc.MountainId IS NULL) AS CountriesWithoutMountainsQuery

---------------------------------------------------
-- 17. Highest Peak and Longest River by Country --
---------------------------------------------------
SELECT TOP(5) c.[CountryName],
MAX(p.[Elevation]) AS [HighestPeakElevation],
MAX(r.[Length]) AS [LongestRiverLength]
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc 
ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] AS m 
ON mc.[MountainID] = m.[Id]
LEFT JOIN [Peaks] AS p
ON m.[Id] = p.[MountainId]
LEFT JOIN [CountriesRivers] AS cr
ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r
ON cr.[RiverId] = r.[Id]
GROUP BY c.[CountryName]
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName

------------------------------------------------------
-- 18. Highest Peak Name and Elevation by Country --
------------------------------------------------------
SELECT TOP(5) [CountryName] AS [Country],
ISNULL([PeakName], '(no highest peak)') AS [Highest Peak Name],
ISNULL([Elevation], 0) AS [Highest Peak Elevation],
ISNULL([MountainRange], '(no mountain)') AS [Mountain]
FROM 
(SELECT c.[CountryName],
p.[PeakName],
p.[Elevation],
m.[MountainRange],
DENSE_RANK() OVER (PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC) AS [PeakRank]
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] AS m 
ON mc.[MountainId] = m.[Id]
LEFT JOIN [Peaks] AS p
ON m.[Id] = p.[MountainId]) AS [PeaksRankingSubQuery]
WHERE PeakRank = 1
ORDER BY [Country], [Highest Peak Name]