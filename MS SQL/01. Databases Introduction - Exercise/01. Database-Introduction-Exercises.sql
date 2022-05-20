------------------------------------
-- 01. Create Database --
------------------------------------
CREATE DATABASE Minions

------------------------------------
-- 02. Create Tables --
------------------------------------
CREATE TABLE Minions (Id INT PRIMARY KEY, Name VARCHAR, Age INT)
CREATE TABLE Towns (Id INT PRIMARY KEY, Name VARCHAR)

------------------------------------
-- 03. Alter Minions Table --
------------------------------------
ALTER TABLE Minions
ADD TownId INT
ALTER TABLE Minions
ADD CONSTRAINT FK_Minions_Towns FOREIGN KEY (TownId) REFERENCES Towns(Id)

------------------------------------
-- 04. Insert Records in Both Tables --
------------------------------------
INSERT INTO Towns(Id, Name)
VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions(Id, Name, Age, TownId)
VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

------------------------------------
-- 05. Truncate Table Minions --
------------------------------------
TRUNCATE TABLE Minions

------------------------------------
-- 06. Drop All Tables --
------------------------------------
DROP TABLE Minions
DROP TABLE Towns

------------------------------------
-- 07. Create Table People --
------------------------------------
CREATE TABLE People(
Id int IDENTITY(1,1),
Name NVARCHAR(200) NOT NULL,
Picture VARBINARY(max)
CHECK (DATALENGTH(Picture) <= 2000000),
Height DECIMAL(4,2),
Weight DECIMAL(6,2),
Gender CHAR(1) NOT NULL,
CHECK(Gender = 'm' OR Gender = 'f'),
Birthdate DATETIME2 NOT NULL,
Biography NVARCHAR(max))

ALTER TABLE People
ADD CONSTRAINT PK_UsersId PRIMARY KEY(Id)

INSERT INTO People(Name, Height, Weight, Gender, Birthdate)
VALUES
('Ivan Petrov', 1.98, 150, 'm', '1990-12-22'),
('Petar Ivanov', 1.67, 80, 'm', '1990-12-22'),
('Suzi Suzanova', 1.50, 56, 'f', '1990-03-04'),
('Todor Kableshkov', 1.80, 77, 'm', '2003-03-04'),
('George Draganov', 1.76, 83, 'm', '1986-05-13')

------------------------------------
-- 08. Create Table Users --
------------------------------------
CREATE TABLE Users
(
Id BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
Username VARCHAR(30) NOT NULL UNIQUE,
Password NVARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(8000),
LastLoginTime TIME,
IsDeleted BIT
)

INSERT INTO Users (Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES ('Mitko', 'pass123456789', null, '2015-12-08', 'true'),
('Jelqzko', 'pass123456789', null, '2015-12-08', 'true'),
('Jivko', 'pass123456789', null, '2011-12-11', 'false'),
('Yordan', 'pass123456789', null, '2014-12-26', 'false'),
('Kostadin', 'pass123456789', null, '2015-12-14', 'true')

------------------------------------
-- 09. Change Primary Key --
------------------------------------
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC070B7B415F

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id_Username
PRIMARY KEY(Id, Username)

------------------------------------
-- 10. Add Check Constraint --
------------------------------------
ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
CHECK(LEN(Password) >=5)

------------------------------------
-- 11. Set Default Value of a Field --
------------------------------------
ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime


------------------------------------
-- 12. Set Unique Field --
------------------------------------
ALTER TABLE Users
DROP CONSTRAINT PK_Users_Id_Username

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_Username_Length
CHECK(LEN(Username) >=3)

------------------------------------
-- 13. Movies Database --
------------------------------------
CREATE TABLE [Directors]([Id] INT PRIMARY KEY IDENTITY NOT NULL, [DirectorName] VARCHAR(30) NOT NULL, [Notes] VARCHAR(MAX))
CREATE TABLE [Genres]([Id] INT PRIMARY KEY IDENTITY NOT NULL, [GenreName] VARCHAR(30) NOT NULL, [Notes] VARCHAR(MAX))
CREATE TABLE [Categories]([Id] INT PRIMARY KEY IDENTITY NOT NULL, [CategoryName] VARCHAR(30) NOT NULL, [Notes] VARCHAR(MAX))
CREATE TABLE [Movies]([Id] INT PRIMARY KEY IDENTITY NOT NULL,
[Title] VARCHAR(30) NOT NULL, 
[DirectorId] INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL, 
[CopyrightYear] SMALLINT NOT NULL, 
[Length] TINYINT NOT NULL, 
[GenreId] INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
[Rating] TINYINT,
[Notes] VARCHAR(MAX))

INSERT INTO [Directors](DirectorName, Notes)
VALUES
('Ivan Ivanov', 'note'),
('Boyan Zlatanov', 'note'),
('Nikola Avramov', 'note'),
('Stefan Petkov', 'note'),
('Teodor Svetoslavov', 'note')
INSERT INTO [Genres](GenreName, Notes)
VALUES
('Horror', 'Scary'),
('Thriller', 'Thrilling'),
('Sci-fi', 'Scientific'),
('Comedy', 'Funny'),
('Drama', 'Sad')
INSERT INTO [Categories](CategoryName, Notes)
VALUES
('Cat1', '1'),
('Cat2', '2'),
('Cat3', '3'),
('Cat4', '4'),
('Cat5', '5')
INSERT INTO [Movies](Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES
('Dances with Wolves', 1, 1990, 120, 5, 5, 8, 'note'),
('Star Wars', 3, 1986, 120, 3, 4, 10, 'note2'),
('Inception', 2, 2005, 130, 1, 4, 8, 'note3'),
('The Conjuring', 4, 2010, 140, 3, 5, 10, 'note4'),
('The Lord of the Rings', 3, 2010, 150, 4, 5, 10, 'note5')

------------------------------------
-- 14. Car Rental Database --
------------------------------------
CREATE TABLE Categories (Id INT PRIMARY KEY IDENTITY NOT NULL,
CategoryName VARCHAR(30) NOT NULL,
DailyRate DECIMAL NOT NULL,
WeeklyRate DECIMAL NOT NULL,
MonthlyRate DECIMAL NOT NULL,
WeekendRate DECIMAL NOT NULL)

CREATE TABLE Cars (Id INT PRIMARY KEY IDENTITY NOT NULL, 
PlateNumber VARCHAR(10) NOT NULL,
Manufacturer VARCHAR(30) NOT NULL,
Model VARCHAR(30) NOT NULL,
CarYear INT NOT NULL,
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id), 
Doors INT NOT NULL,
Picture VARBINARY(MAX), 
Condition VARCHAR(100), 
Available BIT NOT NULL)

CREATE TABLE Employees (Id INT PRIMARY KEY IDENTITY NOT NULL, 
FirstName VARCHAR(20) NOT NULL, 
LastName VARCHAR(20) NOT NULL, 
Title VARCHAR(20) NOT NULL, 
Notes VARCHAR(MAX))

CREATE TABLE Customers (Id INT PRIMARY KEY IDENTITY NOT NULL,
DriverLicenceNumber INT NOT NULL,
FullName VARCHAR(50) NOT NULL, 
Address VARCHAR(50) NOT NULL,
City VARCHAR(50) NOT NULL,
ZIPCode VARCHAR(30), 
Notes VARCHAR(MAX))

CREATE TABLE RentalOrders (Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id),
CarId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id),
TankLevel INT NOT NULL, 
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage INT NOT NULL,
StartDate DATETIME2, 
EndDate DATETIME2,
CHECK (EndDate > StartDate),
TotalDays INT NOT NULL,
RateApplied INT NOT NULL,
TaxRate INT NOT NULL,
OrderStatus VARCHAR(30) NOT NULL,
Notes VARCHAR(MAX) NOT NULL)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
('Category1', 30.15, 60.30, 100.15, 70),
('Category2', 15.15, 45.30, 120.20, 80),
('Category3', 10.10, 30.30, 118.20, 45)

INSERT INTO CARS(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available)
VALUES
('ASDF1', 'Manufacturer1', 'Model1', 1990, 1, 4, 'Good', 1),
('ASDF2', 'Manufacturer2', 'Model2', 1998, 2, 2, 'Bad', 2),
('ASDF3', 'Manufacturer3', 'Model3', 2003, 2, 3, 'Bad', 3)

INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES
('Ivan', 'Ivanov', 'Sir', 'note1'),
('Petar', 'Ivanov', 'Sir', 'note2'),
('Georgi', 'Nikolov', 'Sir', 'note3')

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
VALUES
(134, 'Ivan Ivanov', 'Sofia, ul. Buzludzha 46', 'Sofia', '1463', 'note1'),
(1267, 'Zlatan Petrov', 'Burgas, ul. Nqkakvasi 78', 'Burgas', '3200', 'note2'),
(1499, 'Samira Durana', 'Gabrovo, ul. Voivodina 15', 'Gabrovo', '4500', 'note3')

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 1, 1, 30, 40, 50, 60, '1990-12-22', '2000-12-22', 1000, 30, 40, 'Fulfilled', 'N/A'),
(2, 3, 1, 40, 60, 70, 60, '1995-12-22', '2000-12-22', 1000, 30, 40, 'Fulfilled', 'N/A'),
(3, 3, 1, 40, 60, 70, 60, '1995-12-22', '2000-12-22', 1000, 30, 40, 'Fulfilled', 'N/A')

------------------------------------
-- 15. Hotel Database --
------------------------------------
CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Title VARCHAR(50),
Notes VARCHAR(MAX)
)
 
INSERT INTO Employees
VALUES
('Velizar', 'Velikov', 'Receptionist', 'Nice customer'),
('Ivan', 'Ivanov', 'Concierge', 'Nice one'),
('Elisaveta', 'Bagriana', 'Cleaner', 'Poetesa')
 
CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY NOT NULL,
AccountNumber BIGINT,
FirstName VARCHAR(50),
LastName VARCHAR(50),
PhoneNumber VARCHAR(15),
EmergencyName VARCHAR(150),
EmergencyNumber VARCHAR(15),
Notes VARCHAR(100)
)
 
INSERT INTO Customers
VALUES
(123456789, 'Ginka', 'Shikerova', '359888777888', 'Sistry mi', '7708315342', 'Kinky'),
(123480933, 'Chaika', 'Stavreva', '359888777888', 'Sistry mi', '7708315342', 'Lawer'),
(123454432, 'Mladen', 'Isaev', '359888777888', 'Sistry mi', '7708315342', 'Wants a call girl')
 
CREATE TABLE RoomStatus(
Id INT PRIMARY KEY IDENTITY NOT NULL,
RoomStatus BIT,
Notes VARCHAR(MAX)
)
 
INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES
(1,'Refill the minibar'),
(2,'Check the towels'),
(3,'Move the bed for couple')
 
CREATE TABLE RoomTypes(
RoomType VARCHAR(50) PRIMARY KEY,
Notes VARCHAR(MAX)
)
 
INSERT INTO RoomTypes (RoomType, Notes)
VALUES
('Suite', 'Two beds'),
('Wedding suite', 'One king size bed'),
('Apartment', 'Up to 3 adults and 2 children')
 
CREATE TABLE BedTypes(
BedType VARCHAR(50) PRIMARY KEY,
Notes VARCHAR(MAX)
)
 
INSERT INTO BedTypes
VALUES
('Double', 'One adult and one child'),
('King size', 'Two adults'),
('Couch', 'One child')
 
CREATE TABLE Rooms (
RoomNumber INT PRIMARY KEY IDENTITY NOT NULL,
RoomType VARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType VARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
Rate DECIMAL(6,2),
RoomStatus NVARCHAR(50),
Notes NVARCHAR(MAX)
)
 
INSERT INTO Rooms (Rate, Notes)
VALUES
(12,'Free'),
(15, 'Free'),
(23, 'Clean it')
 
CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE,
AccountNumber BIGINT,
FirstDateOccupied DATE,
LastDateOccupied DATE,
TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
AmountCharged DECIMAL(14,2),
TaxRate DECIMAL(8, 2),
TaxAmount DECIMAL(8, 2),
PaymentTotal DECIMAL(15, 2),
Notes VARCHAR(MAX)
)
 
INSERT INTO Payments (EmployeeId, PaymentDate, AmountCharged)
VALUES
(1, '12/12/2018', 2000.40),
(2, '12/12/2018', 1500.40),
(3, '12/12/2018', 1000.40)
 
CREATE TABLE Occupancies(
Id  INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE,
AccountNumber BIGINT,
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied DECIMAL(6,2),
PhoneCharge DECIMAL(6,2),
Notes VARCHAR(MAX)
)
 
INSERT INTO Occupancies (EmployeeId, RateApplied, Notes) VALUES
(1, 55.55, 'value1'),
(2, 15.55, 'value2'),
(3, 35.55, 'value3')

------------------------------------
-- 16. Create SoftUni Database --
------------------------------------
CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL)

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(100) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(50),
LastName NVARCHAR(50) NOT NULL,
JobTitle NVARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
HireDate DATE NOT NULL,
Salary DECIMAL(10,2) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id))

------------------------------------
-- 17. Backup Database --
------------------------------------
BACKUP DATABASE SoftUni
TO DISK = 'D:\ExamplePath\softuni-backup.bak';

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni FROM DISK = 'D:\ExamplePath\softuni-backup.bak'

------------------------------------
-- 18. Basic Insert --
------------------------------------
INSERT INTO Towns([Name])
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments([Name])
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES 
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 
(SELECT TOP 1 Id FROM Departments WHERE Name = 'Software Development'),
'02/01/2013', '3500.00'),

('Petar', 'Petrov', 'Petrov', 'Senior Engineer',
(SELECT TOP 1 Id FROM Departments WHERE Name = 'Engineering'),
'03/02/2004', '4000.00'),

('Maria', 'Petrova', 'Ivanova', 'Intern',
(SELECT TOP 1 Id FROM Departments WHERE Name = 'Quality Assurance'),
'08/28/2016', '525.25'),

('Georgi', 'Teziev', 'Ivanov', 'CEO',
(SELECT TOP 1 Id FROM Departments WHERE Name = 'Sales'),
'12/09/2007', '3000.00'),

('Peter', 'Pan', 'Pan', 'Intern', 
(SELECT TOP 1 Id FROM Departments WHERE Name = 'Marketing'),
'08/28/2016', '599.88')

------------------------------------
-- 19. Basic Select All Fields --
------------------------------------
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

------------------------------------
-- 20. Basic Select All Fields and Order Them --
------------------------------------
SELECT * FROM Towns ORDER BY Name
SELECT * FROM Departments ORDER BY Name
SELECT * FROM Employees ORDER BY Salary DESC

------------------------------------
-- 21. Basic Select Some Fields --
------------------------------------
SELECT Name FROM Towns ORDER BY Name
SELECT Name FROM Departments ORDER BY Name
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC

------------------------------------
-- 22. Increase Employees Salary --
------------------------------------
UPDATE Employees SET Salary = 1.10 * Salary
SELECT Salary FROM Employees

------------------------------------
-- 23. Decrease Tax Rate --
------------------------------------
UPDATE Payments SET TaxRate = 0.97 * TaxRate
SELECT TaxRate FROM Payments

------------------------------------
-- 24. Delete All Records --
------------------------------------
DELETE FROM Occupancies