----------------------------
-- 01. Records’ Count --
----------------------------
SELECT COUNT(*) AS [Count]
FROM WizzardDeposits

----------------------------
-- 02. Longest Magic Wand --
----------------------------
SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits

--------------------------------------------------
-- 03. Longest Magic Wand per Deposit Groups --
--------------------------------------------------
SELECT DepositGroup,
MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits
GROUP BY DepositGroup

------------------------------------------------------
-- 04. Smallest Deposit Group per Magic Wand Size --
------------------------------------------------------
SELECT TOP(2) DepositGroup
FROM
(SELECT DepositGroup,
AVG(MagicWandSize) AS AvgMagicWand FROM WizzardDeposits
GROUP BY DepositGroup) AS AvgWandSizeQuery ORDER BY AvgMagicWand ASC

-----------------------
-- 05. Deposits Sum --
-----------------------
SELECT wd.DepositGroup,
SUM(wd.DepositAmount) AS TotalSum
FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup

----------------------------------------------
-- 06. Deposits Sum for Ollivander Family --
----------------------------------------------
SELECT wd.DepositGroup,
SUM(wd.DepositAmount) AS TotalSum
FROM WizzardDeposits AS wd
WHERE wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup

---------------------------
-- 07. Deposits Filter --
---------------------------
SELECT * FROM
(SELECT wd.DepositGroup,
SUM(wd.DepositAmount) AS TotalSum
FROM WizzardDeposits AS wd
WHERE wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup) AS GroupAndTotalSumQuery
WHERE GroupAndTotalSumQuery.TotalSum < 150000
ORDER BY GroupAndTotalSumQuery.TotalSum DESC

---------------------------
-- 08. Deposit Charge --
---------------------------
SELECT DepositGroup,
MagicWandCreator,
MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

------------------------
-- 10. First Letter --
------------------------
SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)

---------------------------
-- 11. Average Interest --
---------------------------
SELECT DepositGroup,
IsDepositExpired,
AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY IsDepositExpired, DepositGroup
ORDER BY DepositGroup DESC, 
IsDepositExpired

-----------------------------------
-- 12. Rich Wizard, Poor Wizard --
-----------------------------------
SELECT SUM(DepositDiffQuery.Difference) AS SumDifference
FROM
(SELECT FirstName AS [Host Wizard],
DepositAmount AS [Host Wizard Deposit],
LEAD(FirstName) OVER(ORDER BY [Id]) AS [Guest Wizard],
LEAD(DepositAmount) OVER (ORDER BY [Id]) AS [Guest Wizard Deposit],
DepositAmount - LEAD(DepositAmount) OVER (ORDER BY [Id]) AS Difference
FROM WizzardDeposits) AS DepositDiffQuery

-------------------------------------
-- 13. Departments Total Salaries --
-------------------------------------
SELECT e.DepartmentID,
SUM(Salary) AS [TotalSalary] FROM Employees AS e
GROUP BY e.DepartmentID

-------------------------------------
-- 14. Employees Minimum Salaries --
-------------------------------------
SELECT DepartmentID,
MIN(Salary) AS MinimumSalary
FROM Employees
WHERE HireDate > '2000-01-01' AND DepartmentID IN (2, 5, 7)
GROUP BY DepartmentID

-------------------------------------
-- 15. Employees Average Salaries --
-------------------------------------
SELECT *
INTO EmployeesCopy
FROM Employees
WHERE Salary > 30000


DELETE FROM EmployeesCopy 
WHERE ManagerID = 42

UPDATE EmployeesCopy
SET Salary = Salary + 5000
WHERE DepartmentID = 1


SELECT DepartmentID,
AVG(Salary) AS AverageSalary 
FROM EmployeesCopy
GROUP BY DepartmentID

-------------------------------------
-- 16. Employees Maximum Salaries --
-------------------------------------
SELECT * FROM
(SELECT DepartmentID,
MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID) AS MaxSalaryQuery
WHERE MaxSalary NOT BETWEEN 30000 AND 70000

------------------------------------
-- 17. Employees Count Salaries --
------------------------------------
SELECT COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

------------------------------
-- 18. 3rd Highest Salary --
------------------------------
SELECT DISTINCT DepartmentID, 
Salary
FROM
(SELECT DepartmentID, Salary, DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
FROM Employees) AS SalaryRankedQuery
WHERE Rank = 3

----------------------------
-- 19. Salary Challenge --
----------------------------
SELECT TOP(10) FirstName, LastName, DepartmentID
FROM Employees AS e
WHERE Salary > (SELECT AVG(Salary) FROM Employees as es GROUP BY DepartmentID HAVING e.DepartmentID = es.DepartmentID) 
ORDER BY e.DepartmentID