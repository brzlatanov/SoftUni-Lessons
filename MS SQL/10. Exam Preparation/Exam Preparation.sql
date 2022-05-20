--------------
-- 01. DDL --
--------------
CREATE TABLE Clients(ClientId INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50)  NOT NULL,
Phone VARCHAR(12)  NOT NULL,
CHECK(LEN(Phone) = 12))

CREATE TABLE Mechanics(MechanicId INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Address VARCHAR(255) NOT NULL)

CREATE TABLE Models(ModelId INT PRIMARY KEY IDENTITY NOT NULL,
Name VARCHAR(50) UNIQUE NOT NULL)

CREATE TABLE Jobs(JobId INT PRIMARY KEY IDENTITY NOT NULL,
ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
Status VARCHAR(11) DEFAULT 'Pending' NOT NULL,
CHECK(Status IN ('Pending', 'In Progress', 'Finished')),
ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId) NULL,
IssueDate DATE NOT NULL, 
FinishDate DATE NULL)

CREATE TABLE Orders(OrderId INT PRIMARY KEY IDENTITY NOT NULL,
JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
IssueDate DATE NULL,
Delivered BIT DEFAULT 0  NOT NULL)

CREATE TABLE Parts(PartId INT PRIMARY KEY IDENTITY NOT NULL,
SerialNumber VARCHAR(50) UNIQUE NOT NULL,
Description VARCHAR(255) NULL,
Price DECIMAL(6,2) NOT NULL,
CHECK(Price > 0),
CHECK(Price <= 9999.99),
VendorId INT NOT NULL,
StockQty INT DEFAULT 0 NOT NULL,
CHECK(StockQty >= 0))

CREATE TABLE OrderParts(OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL,
PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
Quantity INT DEFAULT 1 NOT NULL,
CHECK(Quantity > 0),
PRIMARY KEY(OrderId, PartId))

CREATE TABLE PartsNeeded(JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
Quantity INT DEFAULT 1 NOT NULL,
CHECK(Quantity > 0),
PRIMARY KEY(JobId, PartId))

CREATE TABLE Vendors(VendorId INT PRIMARY KEY IDENTITY NOT NULL,
Name VARCHAR(50) UNIQUE NOT NULL)

ALTER TABLE Parts
ADD FOREIGN KEY (VendorId) REFERENCES Vendors(VendorId)


-------------------
-- 02. Insert --
-------------------
INSERT INTO Clients(FirstName, LastName, Phone)
VALUES('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO  Parts(SerialNumber, Description, Price, VendorId)
VALUES('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

-------------------
-- 03. Update --
-------------------
UPDATE Jobs
SET MechanicId = 3
WHERE Status = 'Pending'

UPDATE Jobs
SET Status = 'In Progress'
WHERE Status = 'Pending'

-------------------
-- 04. Delete --
-------------------
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

-------------------------------
-- 05. Mechanic Assignments --
-------------------------------
SELECT FirstName + ' ' + LastName AS [Mechanic],
j.Status, 
j.IssueDate
FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId,
j.IssueDate,
j.JobId

--------------------------
-- 06. Current Clients --
--------------------------
SELECT c.FirstName + ' ' + c.LastName AS [Client],
DATEDIFF(Day, IssueDate, '2017-04-24') AS [DaysGoing],
j.Status
FROM Clients AS c
JOIN Jobs AS j ON c.ClientId = j.ClientId
WHERE j.Status <> 'Finished'
ORDER BY [DaysGoing] DESC, 
c.ClientId ASC

-------------------------------
-- 07. Mechanic Performance --
-------------------------------
SELECT [Mechanic], [Average Days]
FROM
(SELECT m.MechanicId,
m.FirstName + ' ' + m.LastName AS [Mechanic],
AVG(DATEDIFF(Day, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE j.FinishDate IS NOT NULL
GROUP BY m.MechanicId, m.FirstName + ' ' + m.LastName) AS IdMechanicAverageDaysSubQuery
ORDER BY MechanicId ASC

-------------------------------
-- 08. Available Mechanics --
-------------------------------
SELECT FirstName + ' ' + LastName AS Available FROM Mechanics 
WHERE FirstName + ' ' + LastName NOT IN
(SELECT m.FirstName + ' ' + m.LastName FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE j.Status = 'In Progress')
ORDER BY MechanicId

------------------------
-- 09. Past Expenses --
------------------------
SELECT j.JobId,
SUM(p.Price) AS [Total]
FROM Jobs AS j 
JOIN PartsNeeded AS pn ON j.JobId = pn.JobId
JOIN Parts AS p ON pn.PartId = p.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, 
j.JobId ASC

------------------------
-- 10. Missing Parts --
------------------------
SELECT * FROM(
SELECT p.PartId, 
p.Description,
pn.Quantity AS [Required],
p.StockQty AS [In Stock],
ISNULL(op.Quantity, 0) AS [Ordered]
FROM Jobs AS j
LEFT JOIN PartsNeeded AS pn ON j.JobId = pn.JobId
LEFT JOIN Parts AS p ON pn.PartId = p.PartId
LEFT JOIN Orders AS o ON j.JobId = o.JobId
LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
WHERE j.Status <> 'Finished' AND (o.Delivered = 0 OR o.Delivered IS NULL)) AS PartsQuantitySubquery
WHERE [Required] > [In Stock] + [Ordered]
ORDER BY PartId

------------------------
-- 12. Cost of Order --
------------------------
CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(8,2)
AS 
BEGIN 
  DECLARE @totalCost DECIMAL(8,2)

  DECLARE @jobOrdersCount INT = 
  (SELECT COUNT(OrderId) FROM Jobs AS j
  LEFT JOIN Orders AS o ON j.JobId = o.JobId 
  WHERE j.JobId = @jobId)

  IF @jobOrdersCount = 0
  BEGIN
  RETURN 0
  END

  SET @totalCost = 
  (SELECT SUM(p.Price * op.Quantity) FROM Jobs AS j
  LEFT JOIN Orders AS o ON j.JobId = o.JobId 
  LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
  LEFT JOIN Parts AS p ON op.PartId = p.PartId
  WHERE j.JobId = @jobId)

  RETURN @totalCost

END