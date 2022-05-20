---------------------------------------------
-- 01. Employees with Salary Above 35000 --
---------------------------------------------
CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS SELECT FirstName,
LastName
FROM Employees
WHERE Salary > 35000

---------------------------------------------
-- 02. Employees with Salary Above Number --
---------------------------------------------
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@salaryInput DECIMAL(18,4))
AS SELECT FirstName,
LastName
FROM Employees
WHERE Salary >= @salaryInput

-----------------------------------
-- 03. Town Names Starting With --
-----------------------------------
CREATE PROC usp_GetTownsStartingWith(@input VARCHAR(50))
AS
SELECT Name
FROM Towns
WHERE Name LIKE @input + '%'

------------------------------
-- 04. Employees from Town --
------------------------------
CREATE PROC usp_GetEmployeesFromTown(@townName VARCHAR(50))
AS
SELECT e.FirstName,
e.LastName FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
WHERE t.Name = @townName

--------------------------------
-- 05. Salary Level Function --
--------------------------------
CREATE FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS VARCHAR(50)
AS
BEGIN
DECLARE @salaryLevel VARCHAR(50)
IF(@Salary < 30000) 
BEGIN
SET @salaryLevel = 'Low'
END
ELSE IF(@Salary BETWEEN 30000 AND 50000)
BEGIN
SET @salaryLevel = 'Average'
END
ELSE IF(@Salary > 50000)
BEGIN
SET @salaryLevel = 'High'
END
RETURN @salaryLevel
END

-----------------------------------
-- 06. Employees by Salary Level --
-----------------------------------
CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(50))
AS 
SELECT FirstName,
LastName
FROM Employees
WHERE @salaryLevel = dbo.ufn_GetSalaryLevel(Salary)

--------------------------
-- 07. Define Function --
--------------------------
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(255), @word VARCHAR(255))
RETURNS BIT
AS
BEGIN
DECLARE @wordLength INT = LEN(@word)
DECLARE @index INT = 1
DECLARE @isComprised BIT = 1
DECLARE @letter CHAR
WHILE @index <= @wordLength
BEGIN
SET @letter = SUBSTRING(@word, @index, 1)
IF(CHARINDEX(@letter, @setOfLetters) = 0)
BEGIN
SET @isComprised = 0
END
SET @index = @index + 1
END
RETURN @isComprised
END

-------------------------------------------
-- 08. Delete Employees and Departments --
-------------------------------------------
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN

    DELETE FROM [EmployeesProjects]
    WHERE [EmployeeID] IN (
                            SELECT [EmployeeID]
                              FROM [Employees]
                             WHERE [DepartmentID] = @departmentId
                          )
    
  
    UPDATE [Employees]
    SET [ManagerID] = NULL
    WHERE [ManagerID] IN (
                            SELECT [EmployeeID]
                              FROM [Employees]
                             WHERE [DepartmentID] = @departmentId
                          )
 
 
    ALTER TABLE [Departments]
    ALTER COLUMN [ManagerID] INT
 
    UPDATE [Departments]
    SET [ManagerID] = NULL
    WHERE [ManagerID] IN (
                            SELECT [EmployeeID]
                              FROM [Employees]
                             WHERE [DepartmentID] = @departmentId
                          )
    

    DELETE FROM [Employees]
    WHERE [DepartmentID] = @departmentId
 
    DELETE FROM [Departments]
    WHERE [DepartmentID] = @departmentId
 
    SELECT COUNT(*)
      FROM [Employees]
     WHERE [DepartmentID] = @departmentId
END

-------------------------
-- 09. Find Full Name --
-------------------------
CREATE PROC usp_GetHoldersFullName AS
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
FROM AccountHolders

-------------------------------------------
-- 10. People with Balance Higher Than --
-------------------------------------------
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@accountBalance DECIMAL(10,2)) 
AS
SELECT [First Name],
[Last Name] FROM
(SELECT a.FirstName AS [First Name],
a.LastName AS [Last Name],
SUM(ac.Balance) AS [Sum]
FROM AccountHolders AS a 
JOIN Accounts AS ac ON a.Id = ac.AccountHolderId
GROUP BY a.FirstName,
a.LastName) AS BalanceSumQuery
WHERE BalanceSumQuery.Sum > @accountBalance
ORDER BY [First Name],
[Last Name]

---------------------------------
-- 11. Future Value Function --
---------------------------------
CREATE FUNCTION ufn_CalculateFutureValue(@initialSum DECIMAL(12,4), @yearlyInterestRate FLOAT(53), @numberOfYears INT)
RETURNS DECIMAL(15,4)
AS
BEGIN
DECLARE @finalSum DECIMAL(15,4) = 0
SET @finalSum = @initialSum * (POWER((1 + @yearlyInterestRate), @numberOfYears))
RETURN @finalSum
END

--------------------------------
-- 12. Calculating Interest --
--------------------------------
CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT(53)) AS
SELECT a.Id AS [Account Id],
a.FirstName AS [First Name],
a.LastName AS [Last Name],
ac.Balance AS [Current Balance],
dbo.ufn_CalculateFutureValue(ac.Balance, @interestRate, 5) AS [Balance in 5 years]
FROM AccountHolders AS a
JOIN Accounts AS ac ON a.Id = ac.AccountHolderId
WHERE ac.Id = @accountId

---------------------------------------
-- 13. Cash in User Games Odd Rows --
---------------------------------------
CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS TABLE 
AS
RETURN
SELECT SUM(GameNameAndCashQuery.Cash) AS [SumCash] FROM
(SELECT ROW_NUMBER() OVER (PARTITION BY g.Id ORDER BY ug.Cash DESC) AS [Row], g.Name, g.Id, ug.Cash
FROM Games AS g
JOIN UsersGames AS ug
ON g.Id = ug.GameId) AS GameNameAndCashQuery
WHERE GameNameAndCashQuery.Row % 2 <> 0 AND GameNameAndCashQuery.Name = @gameName