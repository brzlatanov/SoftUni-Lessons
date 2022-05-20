--------------
-- 01. DDL --
--------------
CREATE TABLE Passengers(Id INT PRIMARY KEY IDENTITY,
FullName VARCHAR(100) UNIQUE NOT NULL,
Email VARCHAR(50) UNIQUE NOT NULL)

CREATE TABLE Pilots(Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30) UNIQUE NOT NULL,
LastName VARCHAR(30) UNIQUE NOT NULL,
Age TINYINT NOT NULL,
CHECK(Age BETWEEN 21 AND 62),
Rating FLOAT NULL,
CHECK(Rating BETWEEN 0.0 AND 10.0))

CREATE TABLE AircraftTypes(Id INT PRIMARY KEY IDENTITY,
TypeName VARCHAR(30) UNIQUE NOT NULL)

CREATE TABLE Aircraft(Id INT PRIMARY KEY IDENTITY,
Manufacturer VARCHAR(25) NOT NULL,
Model VARCHAR(30) NOT NULL,
Year INT NOT NULL,
FlightHours INT NULL,
Condition CHAR(1) NOT NULL,
TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL)

CREATE TABLE PilotsAircraft(AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
PilotId INT FOREIGN KEY REFERENCES Pilots(Id) NOT NULL,
PRIMARY KEY(AircraftId, PilotId))

CREATE TABLE Airports(Id INT PRIMARY KEY IDENTITY,
AirportName VARCHAR(70) UNIQUE NOT NULL,
Country VARCHAR(100) UNIQUE NOT NULL)

CREATE TABLE FlightDestinations(Id INT PRIMARY KEY IDENTITY,
AirportId INT NOT NULL FOREIGN KEY REFERENCES Airports(Id),
Start DATETIME NOT NULL,
AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
TicketPrice DECIMAL (18,2) DEFAULT 15 NOT NULL)

------------------
-- 02. Insert --
------------------
INSERT INTO Passengers(FullName, Email)
SELECT FirstName + ' ' + LastName,
FirstName + LastName + '@gmail.com'
FROM Pilots
WHERE Id BETWEEN 5 AND 15

------------------
-- 03. Update --
------------------
UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN ('C', 'B') 
AND (FlightHours IS NULL OR FlightHours <= 100)
AND Year >= 2013

------------------
-- 04. Delete --
------------------
DELETE FROM Passengers
WHERE LEN(FullName) <= 10

------------------
-- 05. Aircraft --
------------------
SELECT Manufacturer,
Model,
FlightHours,
Condition
FROM Aircraft
ORDER BY FlightHours DESC

------------------------------
-- 06. Pilots and Aircraft --
------------------------------
SELECT FirstName,
LastName, 
Manufacturer,
Model,
FlightHours
FROM Pilots AS p
INNER JOIN PilotsAircraft AS pa ON p.Id = pa.PilotId
JOIN Aircraft AS a ON pa.AircraftId = a.Id
WHERE FlightHours IS NOT NULL 
AND FlightHours <= 304
ORDER BY FlightHours DESC,
FirstName

--------------------------------------
-- 07. Top 20 Flight Destinations --
--------------------------------------
SELECT TOP(20)
fd.Id AS DestinationId,
fd.Start,
p.FullName,
a.AirportName,
fd.TicketPrice
FROM FlightDestinations AS fd
JOIN Airports AS a ON fd.AirportId = a.Id
JOIN Passengers AS p ON fd.PassengerId = p.Id
WHERE DATEPART(DAY, fd.Start) % 2 = 0
ORDER BY fd.TicketPrice DESC,
a.AirportName ASC

----------------------------------------------
-- 08. Number of Flights for Each Aircraft --
----------------------------------------------
SELECT a.Id AS AircraftId,
	a.Manufacturer,
	a.FlightHours,
	COUNT(fd.Id) AS FlightDestinationsCount,
	ROUND(AVG(TicketPrice), 2) AS AvgPrice
	FROM Aircraft AS a
	JOIN FlightDestinations AS fd
	ON a.Id = fd.AircraftId
	GROUP BY a.Id,
	a.Manufacturer,
	a.FlightHours
	HAVING COUNT(fd.Id) >= 2
	ORDER BY COUNT(fd.Id) DESC,
	a.Id ASC

----------------------------
-- 09. Regular Passengers --
----------------------------
SELECT p.FullName,
COUNT(fd.AircraftId) AS CountOfAircraft,
SUM(fd.TicketPrice) AS TotalPayed
FROM Passengers AS p
JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
GROUP BY p.FullName
HAVING COUNT(fd.AircraftId) >= 2 AND CHARINDEX('a', p.FullName) = 2
ORDER BY p.FullName

--------------------------------------------
-- 10. Full Info for Flight Destinations --
--------------------------------------------
SELECT a.AirportName,
fd.Start AS DayTime,
fd.TicketPrice,
p.FullName,
af.Manufacturer,
af.Model
FROM Airports AS a
JOIN FlightDestinations AS fd ON a.Id = fd.AirportId
JOIN Passengers AS p ON fd.PassengerId = p.Id
JOIN Aircraft AS af ON fd.AircraftId = af.Id
WHERE FORMAT(fd.Start,'HH:mm') BETWEEN '06:00' AND '22:00' AND fd.TicketPrice > 2500
ORDER BY af.Model ASC

--------------------------------------------------
-- 11. Find all Destinations by Email Address --
--------------------------------------------------
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN
DECLARE @returnCount INT
SELECT @returnCount = COUNT(p.Id) FROM FlightDestinations AS fd
JOIN Passengers AS p
ON fd.PassengerId = p.Id
WHERE Email = @email
RETURN @returnCount
END

---------------------------------
-- 12. Full Info for Airports --
---------------------------------
CREATE PROCEDURE usp_SearchByAirportName(@airportName VARCHAR(70))
AS
BEGIN
--DECLARE @t TABLE(AirportName VARCHAR(70), FullName VARCHAR(100), LevelOfTickerPrice VARCHAR(6), Manufacturer VARCHAR(25),
--Condition CHAR(1), TypeName VARCHAR(30))
SELECT a.AirportName,
p.FullName,
CASE
WHEN TicketPrice <= 400 THEN 'Low'
WHEN TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
WHEN TicketPrice > 1500 THEN 'High' 
END AS LevelOfTickerPrice,
af.Manufacturer,
af.Condition,
at.TypeName
FROM Airports AS a
JOIN FlightDestinations AS fd ON a.Id = fd.AirportId
JOIN Passengers AS p ON fd.PassengerId = p.Id
JOIN Aircraft AS af ON fd.AircraftId = af.Id
JOIN AircraftTypes AS at ON af.TypeId = at.Id
WHERE a.AirportName = @airportName
ORDER BY af.Manufacturer,
p.FullName
END
