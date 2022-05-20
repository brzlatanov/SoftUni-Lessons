--------------
-- 01. DDL --
--------------
CREATE TABLE Sizes(Id INT PRIMARY KEY IDENTITY, 
Length INT NOT NULL,
CHECK(Length BETWEEN 10 AND 25),
RingRange DECIMAL(4,2) NOT NULL,
CHECK(RingRange BETWEEN 1.5 AND 7.5)) 

CREATE TABLE Tastes(Id INT PRIMARY KEY IDENTITY,
TasteType VARCHAR(20) NOT NULL,
TasteStrength VARCHAR(15) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL)

CREATE TABLE Brands(Id INT PRIMARY KEY IDENTITY, 
BrandName VARCHAR(30) UNIQUE NOT NULL,
BrandDescription VARCHAR(MAX) NULL)

CREATE TABLE Cigars(Id INT PRIMARY KEY IDENTITY,
CigarName VARCHAR(80) NOT NULL,
BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
PriceForSingleCigar DECIMAL NOT NULL,
ImageURL NVARCHAR(100) NOT NULL)

CREATE TABLE Addresses(Id INT PRIMARY KEY IDENTITY,
Town VARCHAR(30) NOT NULL,
Country NVARCHAR(30) NOT NULL,
Streat NVARCHAR(100) NOT NULL,
ZIP VARCHAR(20) NOT NULL)

CREATE TABLE Clients(Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email nVARCHAR(30) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL)

CREATE TABLE ClientsCigars(ClientId INT FOREIGN KEY REFERENCES Clients(Id),
CigarId INT FOREIGN KEY REFERENCES Cigars(Id),
PRIMARY KEY(ClientId, CigarId))

-----------------
-- 02. Insert --
-----------------
INSERT INTO Cigars(CigarName,
BrandId,
TastId,
SizeId,
PriceForSingleCigar,
ImageURL)
VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town,
Country,
Streat,
ZIP)
VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

-----------------
-- 03. Update --
-----------------
UPDATE Cigars 
SET PriceForSingleCigar += (PriceForSingleCigar * 0.2)
WHERE TastId = (SELECT Id FROM Tastes WHERE TasteType = 'Spicy')

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

-----------------
-- 04. Delete --
-----------------
DELETE FROM Clients
WHERE AddressId IN (SELECT Id FROM Addresses
WHERE LEFT(Country, 1) = 'C')

DELETE FROM Addresses
WHERE LEFT(Country, 1) = 'C'

---------------------------
-- 05. Cigars by Price --
---------------------------
SELECT CigarName,
PriceForSingleCigar,
ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar ASC,
CigarName DESC

---------------------------
-- 06. Cigars by Taste --
---------------------------
SELECT c.Id,
c.CigarName,
c.PriceForSingleCigar,
t.TasteType,
t.TasteStrength
FROM Cigars AS c
JOIN Tastes AS t ON c.TastId = t.Id
WHERE t.TasteType IN ('Earthy', 'Woody')
ORDER BY c.PriceForSingleCigar DESC

--------------------------------
-- 07. Clients without Cigars --
--------------------------------
SELECT c.Id,
c.FirstName + ' ' + c.LastName AS [ClientName],
Email
FROM Clients AS c
LEFT OUTER JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
WHERE cc.ClientId IS NULL
ORDER BY ClientName

-------------------------
-- 08. First 5 Cigars --
-------------------------
SELECT TOP(5)
c.CigarName,
c.PriceForSingleCigar,
c.ImageURL
FROM Cigars AS c 
JOIN Sizes AS s ON c.SizeId = s.Id
WHERE (s.Length >= 12 AND (c.CigarName LIKE '%ci%' 
OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55)
ORDER BY c.CigarName ASC,
c.PriceForSingleCigar DESC

---------------------------------
-- 09. Clients with ZIP Codes --
---------------------------------
SELECT c.FirstName + ' ' + c.LastName AS [FullName],
a.Country,
a.ZIP,
'$' + CAST(MAX(ci.PriceForSingleCigar) AS VARCHAR(15)) AS [CigarPrice]
FROM Clients AS c
JOIN Addresses AS a ON c.AddressId = a.Id
JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
JOIN Cigars AS ci ON cc.CigarId = ci.Id 
WHERE ISNUMERIC(a.ZIP) = 1
GROUP BY c.FirstName + ' ' + c.LastName,
a.Country,
a.ZIP
ORDER BY FullName ASC

-------------------------
-- 10. Cigars by Size --
-------------------------
SELECT c.LastName,
AVG(s.Length) AS CiagrLength,
CEILING(AVG(s.RingRange)) AS CiagrRingRange
FROM Clients AS c
JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
JOIN Cigars AS ci ON cc.CigarId = ci.Id
JOIN Sizes AS s ON ci.SizeId = s.Id
GROUP BY c.LastName
ORDER BY AVG(s.Length) DESC

------------------------------
-- 11. Client with Cigars --
------------------------------
CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN

DECLARE @cigarCount INT

SELECT @cigarCount = COUNT(*) FROM Clients AS c
JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
WHERE c.FirstName = @name

RETURN @cigarCount

END

----------------------------------------------
-- 12. Search for Cigar with Specific Taste --
----------------------------------------------
CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
SELECT c.CigarName,
'$' + CONVERT(VARCHAR(50), c.PriceForSingleCigar) AS [Price],
t.TasteType,
b.BrandName,
CONVERT(VARCHAR(10), s.Length) + ' cm' AS [CigarLength],
CONVERT(VARCHAR(10), s.RingRange) + ' cm' AS [CigarRingRange]
FROM
Cigars AS c 
JOIN Tastes AS t ON c.TastId = t.Id
JOIN Brands AS b ON c.BrandId = b.Id
JOIN Sizes AS s ON c.SizeId = s.Id
WHERE t.TasteType = @taste
ORDER BY s.Length ASC,
s.RingRange DESC
END