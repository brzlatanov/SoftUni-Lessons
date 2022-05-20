-----------------------------------------------
-- 1. Number of Users for Email Provider --
-----------------------------------------------
SELECT SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider], 
COUNT(Email) AS [Number Of Users]
FROM Users 
GROUP BY SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))
ORDER BY COUNT(Email) DESC, [Email Provider] ASC

-----------------------------
-- 02. All Users in Games --
-----------------------------
SELECT g.Name AS [Game], gt.Name AS [Game Type], u.Username, ug.Level, ug.Cash, c.Name AS [Character] FROM Users AS u
JOIN UsersGames AS ug ON u.Id = ug.UserId
JOIN Characters AS c ON ug.CharacterId = c.Id
JOIN Games AS g ON ug.GameId = g.Id
JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
ORDER BY ug.Level DESC, u.Username, g.Name

------------------------------------------
-- 03. Users in Games with Their Items --
------------------------------------------
SELECT u.Username,
g.Name AS [Game], 
COUNT(i.Id) AS [Items Count],
SUM(i.Price) AS [Items Price]
FROM Users AS u
JOIN UsersGames AS ug ON u.Id = ug.UserId
JOIN Games AS g ON ug.GameId = g.Id
JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
JOIN Items AS i ON ugi.ItemId = i.Id
GROUP BY u.Username, g.Name
HAVING COUNT(i.Id) >= 10
ORDER BY COUNT(i.Id) DESC, SUM(i.Price) DESC, u.Username

--------------------------------------------------------
-- 05. All Items with Greater than Average Statistics --
--------------------------------------------------------
SELECT i.Name,
i.Price, 
i.MinLevel,
s.Strength,
s.Defence,
s.Speed,
s.Luck,
s.Mind
FROM Items AS i 
JOIN [Statistics] AS s 
ON i.StatisticId = s.Id
WHERE Mind > (SELECT AVG(Mind) FROM [Statistics]) 
AND Luck > (SELECT AVG(Luck) FROM [Statistics]) 
AND Speed > (SELECT AVG(Speed) FROM [Statistics]) 
ORDER BY i.Name

--------------------------------------------------------
-- 06. Display All Items about Forbidden Game Type --
--------------------------------------------------------
SELECT i.Name AS [Item],
i.Price,
i.MinLevel, 
gt.Name AS [Forbidden Game Type]
FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS gtf ON i.Id = gtf.ItemId
LEFT JOIN GameTypes AS gt ON gtf.GameTypeId = gt.Id
ORDER BY [Forbidden Game Type] DESC, 
Item

------------------------------
-- 08. Peaks and Mountains --
------------------------------
SELECT p.PeakName,
m.MountainRange AS [Mountain],
p.Elevation FROM Peaks AS p
JOIN Mountains AS m ON 
p.MountainId = m.Id
ORDER BY p.Elevation DESC,
p.PeakName 

---------------------------------------------------------
-- 09. Peaks with Mountain, Country and Continent --
---------------------------------------------------------
SELECT p.PeakName,
m.MountainRange AS [Mountain],
c.CountryName,
co.ContinentName
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId = m.Id
JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
JOIN Countries AS c ON mc.CountryCode = c.CountryCode
JOIN Continents AS co ON c.ContinentCode = co.ContinentCode
ORDER BY p.PeakName, 
c.CountryName

-----------------------------
-- 10. Rivers by Country --
-----------------------------
SELECT CountryName,
ContinentName,
ISNULL(COUNT(RiverName), 0) AS RiversCount,
ISNULL(SUM(Length), 0) AS TotalLength
FROM
(SELECT c.CountryName,
co.ContinentName,
r.RiverName,
r.Length
FROM Countries AS c
JOIN Continents AS co ON c.ContinentCode = co.ContinentCode
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id) AS CountryContinentRiverLengthSubquery
GROUP BY CountryName, ContinentName
ORDER BY RiversCount DESC,
TotalLength DESC, 
CountryName

-----------------------------------------
-- 11. Count of Countries by Currency --
-----------------------------------------
SELECT cu.CurrencyCode,
cu.Description,
COUNT(c.CountryName) AS NumberOfCountries
FROM Currencies AS cu LEFT JOIN Countries AS c
ON cu.CurrencyCode = c.CurrencyCode
GROUP BY cu.CurrencyCode,
cu.Description
ORDER BY COUNT(c.CountryName) DESC,
cu.Description

-------------------------------------------
-- 12. Population and Area by Continent --
-------------------------------------------
SELECT co.ContinentName,
SUM(c.AreaInSqKm) AS CountriesArea,
SUM(CAST(c.Population AS bigint)) AS CountriesPopulation
FROM Continents AS co
LEFT JOIN Countries AS c 
ON co.ContinentCode = c.ContinentCode
GROUP BY co.ContinentName
ORDER BY CountriesPopulation DESC

--------------------------------
-- 13. Monasteries by Country --
--------------------------------
CREATE TABLE Monasteries(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), CountryCode CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode))

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN
(SELECT c.CountryCode
FROM Countries AS c
JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
GROUP BY c.CountryCode
HAVING COUNT(cr.RiverId) > 3)

SELECT m.Name,
c.CountryName 
FROM Monasteries AS m 
JOIN Countries AS c 
ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.Name 

--------------------------------------------------
-- 14. Monasteries by Continents and Countries --
--------------------------------------------------
UPDATE Countries
SET CountryName = 'Burma' WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania'))
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Myanmar'))

SELECT co.ContinentName,
c.CountryName, 
COUNT(m.Id) AS [MonasteriesCount]
FROM Continents AS co 
JOIN Countries AS c ON co.ContinentCode = c.ContinentCode
LEFT JOIN Monasteries AS m ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
GROUP BY co.ContinentName,
c.CountryName
ORDER BY MonasteriesCount DESC, 
CountryName

