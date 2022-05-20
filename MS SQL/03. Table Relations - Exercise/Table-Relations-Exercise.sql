----------------------------------------------------
-- 01. One-To-One Relationship --
----------------------------------------------------
CREATE TABLE Persons(PersonID INT NOT NULL, 
FirstName VARCHAR(50), 
Salary DECIMAL(8,2),
PassportID int)

CREATE TABLE Passports(PassportID INT PRIMARY KEY NOT NULL, 
PassportNumber VARCHAR(30))

INSERT INTO Persons(PersonID, FirstName, Salary, PassportID)
VALUES (1, 'Roberto', 43300.00, 102),
(2, 'Tom', 56100.00, 103),
(3, 'Yana', 60200.00, 101)

INSERT INTO Passports(PassportID, PassportNumber)
VALUES(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')	

ALTER TABLE Persons
ADD CONSTRAINT PK_Persons_PersonID PRIMARY KEY (PersonID)
ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

----------------------------------------
-- 02. One-To-Many Relationship --
----------------------------------------
CREATE TABLE Models(ModelID INT PRIMARY KEY IDENTITY(101,1) NOT NULL, Name VARCHAR(15), ManufacturerID INT NOT NULL)

CREATE TABLE Manufacturers(ManufacturerID INT PRIMARY KEY IDENTITY NOT NULL, Name VARCHAR(15), EstablishedOn DATETIME2 NOT NULL)

INSERT INTO Models(Name, ManufacturerID)
VALUES('X1', 1),
('i6', 1),
('Model S', 2),
('Model x', 2),
('Model 3', 2),
('Nova', 3)

INSERT INTO Manufacturers(Name, EstablishedOn)
VALUES('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

ALTER TABLE Models
ADD CONSTRAINT FK_Models_Manufacturers FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)

--------------------------------------
-- 03. Many-To-Many Relationship --
--------------------------------------
CREATE TABLE Students(StudentID INT PRIMARY KEY IDENTITY NOT NULL,
Name VARCHAR(30))

CREATE TABLE Exams(ExamID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
NAME VARCHAR(30))

CREATE TABLE StudentsExams(StudentID INT NOT NULL,
ExamID INT NOT NULL,
CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID),
CONSTRAINT FK_StudentsExams_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY(ExamID) REFERENCES Exams(ExamID))

INSERT INTO Students(Name)
VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams(Name)
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
VALUES(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

-----------------------------
-- 04. Self-Referencing --
----------------------------
CREATE TABLE Teachers(TeacherID INT PRIMARY KEY IDENTITY(101,1),
Name VARCHAR(30), 
ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID))

INSERT INTO Teachers(Name,
ManagerID)
VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

----------------------------------
-- 05. Online Store Database --
----------------------------------
CREATE TABLE Orders(OrderID INT PRIMARY KEY IDENTITY NOT NULL,
CustomerID INT NOT NULL)

CREATE TABLE Customers(CustomerID INT PRIMARY KEY IDENTITY NOT NULL,
Name VARCHAR(50),
Birthday DATETIME2,
CityID INT NOT NULL)

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)

CREATE TABLE Cities(CityID INT PRIMARY KEY IDENTITY NOT NULL,
Name VARCHAR(50))

ALTER TABLE Customers
ADD CONSTRAINT FK_Customers_Cities FOREIGN KEY (CityID) REFERENCES Cities(CityID)

CREATE TABLE OrderItems(OrderID INT NOT NULL, 
ItemID INT NOT NULL,
CONSTRAINT PK_OrderItems PRIMARY KEY(OrderID, ItemID),
CONSTRAINT FK_OrderItems FOREIGN KEY(OrderID) REFERENCES Orders(OrderID))

CREATE TABLE Items(ItemID INT PRIMARY KEY IDENTITY NOT NULL, 
Name VARCHAR(50),
ItemTypeID INT NOT NULL)

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_Items FOREIGN KEY(ItemID) REFERENCES Items(ItemID)

CREATE TABLE ItemTypes(ItemTypeID INT PRIMARY KEY IDENTITY NOT NULL,
Name VARCHAR(50))

ALTER TABLE Items
ADD CONSTRAINT FK_Items_ItemTypes FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)

--------------------------------
-- 06. University Database --
--------------------------------
CREATE TABLE Majors(MajorID INT PRIMARY KEY IDENTITY NOT NULL,
Name VARCHAR(30)) 

CREATE TABLE Students(StudentID INT PRIMARY KEY IDENTITY NOT NULL,
StudentNumber INT NOT NULL,
StudentName VARCHAR(50),
MajorID INT FOREIGN KEY REFERENCES Majors(MajorID) NOT NULL)

CREATE TABLE Payments(PaymentID INT PRIMARY KEY NOT NULL,
PaymentDate DATETIME2 NOT NULL,
PaymentAmount DECIMAL(8,2) NOT NULL,
StudentID INT FOREIGN KEY REFERENCES Students(StudentID))

CREATE TABLE Agenda(StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
SubjectID INT NOT NULL,
CONSTRAINT PK_Agenda PRIMARY KEY(StudentID, SubjectID))

CREATE TABLE Subjects(SubjectID INT PRIMARY KEY NOT NULL,
SubjectName VARCHAR(50))

ALTER TABLE Agenda
ADD CONSTRAINT FK_Agenda_Subjects FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)

----------------------------
-- 09. Peaks in Rila --
----------------------------
SELECT m.MountainRange, 
p.PeakName, 
p.Elevation 
FROM Mountains as m 
JOIN Peaks as p 
ON m.Id = p.MountainId
WHERE m.MountainRange = 'Rila'
ORDER BY Elevation DESC

