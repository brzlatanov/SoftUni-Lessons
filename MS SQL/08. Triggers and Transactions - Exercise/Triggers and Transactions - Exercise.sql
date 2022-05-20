---------------------------
-- 01. Create Table Logs --
---------------------------
CREATE TRIGGER tr_InsertIntoLogsOnAccountUpdate
ON Accounts
AFTER UPDATE
AS
IF(UPDATE(Balance))
BEGIN
INSERT INTO Logs(AccountId, OldSum, NewSum)
SELECT i.Id, d.Balance, i.Balance
FROM inserted AS i 
JOIN deleted AS d ON i.Id = d.Id
WHERE i.Balance <> d.Balance
END

------------------------------
-- 02. Create Table Emails --
------------------------------
CREATE TRIGGER tr_CreateEmailOnLogsInsert
ON Logs
AFTER INSERT
AS
INSERT INTO NotificationEmails(Recipient, Subject, Body)
SELECT AccountId,
'Balance change for account: ' + CAST(AccountId AS VARCHAR(20)),
'On ' + CAST(GETDATE() AS VARCHAR(20)) + ' your balance was changed from ' + CAST(OldSum AS VARCHAR(20)) + ' to ' + CAST(NewSum AS VARCHAR(20))		
FROM Logs

------------------------
-- 03. Deposit Money --
------------------------
CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(13,4))
AS
IF @MoneyAmount > 0.000
UPDATE Accounts
SET Balance += @MoneyAmount
WHERE Id = @AccountID

-------------------------
-- 04. Withdraw Money --
-------------------------
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(13,4))
AS
IF @MoneyAmount > 0.000
UPDATE Accounts
SET Balance -= @MoneyAmount
WHERE Id = @AccountId

------------------------
-- 05. Money Transfer --
------------------------
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(13, 4)) 
AS
BEGIN TRANSACTION 
IF((SELECT Balance FROM Accounts WHERE Id = @SenderId) < @Amount)
ROLLBACK
ELSE
BEGIN
UPDATE Accounts
SET Balance -= @Amount WHERE Id = @SenderId 
UPDATE Accounts
SET Balance += @Amount WHERE Id = @ReceiverID
COMMIT
END

------------------------------------------
-- 08. Employees with Three Projects --
------------------------------------------
CREATE OR ALTER PROCEDURE usp_AssignProject(@EmployeeID INT, @ProjectID INT)
AS
BEGIN
DECLARE @employeeProjectsNumber INT 
SET @employeeProjectsNumber = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @EmployeeID)
IF(@employeeProjectsNumber >= 3)
THROW 50001, 'The employee has too many projects!', 1
INSERT INTO EmployeesProjects VALUES (@EmployeeID, @ProjectID)
END

---------------------------
-- 09. Delete Employees --
---------------------------
CREATE TRIGGER tr_InsertIntoDeletedEmployeesOnDeletion
ON Employees
FOR DELETE
AS
INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
SELECT  d.FirstName, d.LastName, d.MiddleName, d.JobTitle, d.DepartmentID, d.Salary FROM deleted AS d