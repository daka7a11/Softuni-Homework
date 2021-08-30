--Problem 1.	Create Database
CREATE DATABASE Minions

--Problem 2.	Create Tables
CREATE TABLE Minions
(
Id INT NOT NULL,
[Name] NVARCHAR(50),
Age INT
)

CREATE TABLE Towns
(
Id INT NOT NULL,
[Name] NVARCHAR(50),
)

ALTER TABLE Minions
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Towns
ADD CONSTRAINT PK_TownId PRIMARY KEY (Id)

--Problem 3.	Alter Minions Table
ALTER TABLE Minions
ADD TownId INT 

ALTER TABLE Minions
ADD CONSTRAINT FK_TownId FOREIGN KEY (TownId) REFERENCES Towns(Id)

--Problem 4.	Insert Records in Both Tables
INSERT INTO Towns(Id,[Name]) 
VALUES (1,'Sofia'), (2,'Plovdiv'), (3,'Varna')

INSERT INTO Minions(Id,[Name],Age, TownId)
VALUES (1,'Kevin',22,1), (2,'Bob',15,3), (3,'Steward',NULL,2)

--Problem 5.	Truncate Table Minions
TRUNCATE TABLE Minions

--Problem 6.	Drop All Tables
DROP TABLE Minions

--Problem 7.	Create Table People
CREATE TABLE People
(
Id INT UNIQUE IDENTITY(1,1),
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY,
Height DECIMAL(6,2),
[Weight] DECIMAL(6,2),
Gender CHAR(1) NOT NULL,
Birthdate DATE NOT NULL,
Biography NVARCHAR(max)
)

ALTER TABLE People
ADD PRIMARY KEY (Id)

INSERT INTO People([Name],Picture,Height,[Weight],Gender,Birthdate,Biography)
VALUES('Ivan',NULL,1.80,80,'m','1998-12-08',NULL), ('Ivanka',NULL,1.70,50,'f','1999-10-10',NULL),
('Dragan',NULL,2.00,90,'m','1995-12-08',NULL), ('Roza',NULL,1.50,40,'f','1995-07-28',NULL),
('Stan',NULL,1.20,20,'m','1991-12-08',NULL)

--Problem 8.	Create Table Users
CREATE TABLE Users
(
Id INT UNIQUE IDENTITY(1,1),
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY,
LastLoginTime DATETIME,
IsDeleted BIT
)

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

INSERT INTO Users(Username,[Password],ProfilePicture,LastLoginTime,IsDeleted)
VALUES ('Asart','12345',NULL,NULL,NULL),('Ivan','12345',NULL,'1999-12-08 12:30:00',0),
('Dragan','12345',NULL,NULL,NULL),('Zax','12345',NULL,NULL,NULL),('Qwert','12345',NULL,NULL,NULL)

--Problem 9.	Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK_Id

ALTER TABLE Users
ADD CONSTRAINT PK_Id_Username PRIMARY KEY (Id,Username)

--Problem 10.	Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CHK_Password CHECK (LEN([Password])>=5)

--Problem 11.	Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

--Problem 12.	Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK_Id_Username

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT UQ_Username
UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameLen
CHECK (LEN(Username) >= 3)

--Problem 13.	Movies Database
CREATE DATABASE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY(1,1),
DirectorName NVARCHAR(50) NOT NULL,
Notes TEXT
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY(1,1),
GenreName NVARCHAR(50) NOT NULL,
Notes TEXT
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
CategoryName NVARCHAR(50) NOT NULL,
Notes TEXT
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY(1,1),
Title NVARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear DATE NOT NULL,
[Length] TIME NOT NULL,
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating INT,
Notes TEXT
)

INSERT INTO Directors(DirectorName,Notes)
VALUES('Ivan','Hi'), ('Stoqn',NULL), ('Yordan',NULL), ('Stanislav', NULL), ('John', NULL)

INSERT INTO Genres(GenreName,Notes)
VALUES('Novel','asd'), ('Essays',NULL), ('Tale',NULL), ('Legend',NULL), ('Anthem',NULL)

INSERT INTO Categories(CategoryName,Notes)
VALUES('Action','qwerty'), ('Commedy',NULL), ('Drama',NULL), ('Horror',NULL), ('Fantasy',NULL)

INSERT INTO Movies(Title,DirectorId,CopyrightYear,[Length],GenreId,Rating,Notes) 
VALUES
('Jumanji',1,'2000-12-12','02:35:30',1,NULL,NULL),
('Qwerty',2,'2000-12-12','02:35:30',2,NULL,NULL),
('Asdfg',3,'2000-12-12','02:35:30',3,NULL,NULL),
('Zxcvb',4,'2000-12-12','02:35:30',4,NULL,NULL),
('Uiopjkl',5,'2000-12-12','02:35:30',5,NULL,NULL)

--Problem 14.	Car Rental Database
CREATE DATABASE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
CategoryName NVARCHAR(50) NOT NULL,
DailyRate INT,
WeeklyRate INT,
MonthlyRate INT,
WeekendRate INT
)

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY(1,1),
PlateNumber NVARCHAR(30) NOT NULL,
Manufacturer NVARCHAR(30) NOT NULL,
Model NVARCHAR(30)NOT NULL,
CarYear DATE NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Doors INT NOT NULL,
Picture VARBINARY,
Condition NVARCHAR(30),
Available BIT NOT NULL,
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Title VARCHAR(30) NOT NULL,
Notes TEXT
)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY(1,1),
DriverLicenceNumber NVARCHAR(30) NOT NULL,
FullName NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(50) NOT NULL,
City NVARCHAR(50) NOT NULL,
ZIPCode NVARCHAR(20) NOT NULL,
Notes TEXT
)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
CarId INT FOREIGN KEY REFERENCES Cars(Id),
TankLevel INT NOT NULL,
KilometrageStart DECIMAL(10,0) NOT NULL,
KilometrageEnd DECIMAL(10,0) NOT NULL,
TotalKilometrage INT NOT NULL,
StartDate DATETIME NOT NULL,
EndDate DATETIME NOT NULL,
TotalDays INT NOT NULL,
RateApplied INT,
TaxRate INT,
OrderStatus BIT NOT NULL,
Notes TEXT
)

INSERT INTO Categories(CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate)
VALUES ('QWERT',5,10,30,5),
('ASDFG',NULL,NULL,NULL,NULL),
('ZXCVB',NULL,NULL,NULL,NULL)

INSERT INTO Cars(PlateNumber,Manufacturer,Model,CarYear,CategoryId,Doors,Picture,Condition,Available)
VALUES ('QQ1234ZZ','VW','Golf','2000-10-10',1,4,NULL,'Good',1),
('WW1111XX','VW','Golf','2000-10-10',2,4,NULL,'Good',1),
('AA1122ss','VW','Golf','2000-10-10',3,4,NULL,'Good',1)

INSERT INTO Employees(FirstName,LastName,Title,Notes)
VALUES ('Ivan','Ivanov','CEO',NULL), 
('Dragan','Draganov','COO',NULL),
('Stan','Ivanov','CFO',NULL)

INSERT INTO Customers(DriverLicenceNumber,FullName,[Address],City,ZIPCode,Notes)
VALUES ('123456','Ivan Ivanov','A2','Sofia','1020',NULL),
('qwe123','Dranag Ivanov','A10','Varna','1022',NULL),
('678900','Turi Turinov','A2','Burgas','1020',NULL)

INSERT INTO RentalOrders(EmployeeId,CustomerId,CarId,TankLevel,KilometrageStart,KilometrageEnd,TotalKilometrage,
StartDate,EndDate,TotalDays,RateApplied,TaxRate,OrderStatus,Notes)
VALUES(1,1,1,6,10,20,10,'2000-12-10 05: 30: 50','2000-12-10 10: 30: 50',1,8,5,1,NULL),
(2,2,2,2,10,20,10,'2000-12-10 05: 30: 50','2000-12-10 10: 30: 50',1,8,5,1,NULL),
(3,3,3,3,10,20,10,'2000-12-10 05: 30: 50','2000-12-10 10: 30: 50',1,8,5,1,NULL)

--Problem 15.	Hotel Database
CREATE DATABASE Hotel

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(30) NOT NULL,
Notes TEXT
)

CREATE TABLE Customers(
AccountNumber INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
PhoneNumber NVARCHAR(20) NOT NULL,
EmergencyName NVARCHAR(50),
EmergencyNumber NVARCHAR(20),
Notes TEXT
)

CREATE TABLE RoomStatus(
RoomStatus NVARCHAR(20) PRIMARY KEY,
Notes TEXT
)

CREATE TABLE RoomTypes(
RoomType NVARCHAR(20) PRIMARY KEY,
Notes TEXT
)

CREATE TABLE BedTypes(
BedType NVARCHAR(20) PRIMARY KEY,
Notes TEXT
)

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY,
RoomType NVARCHAR(20) FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType),
Rate INT,
RoomStatus NVARCHAR(20) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
Notes TEXT
)

CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATETIME NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL,
TotalDays INT NOT NULL,
AmountCharged DECIMAL(6,2) NOT NULL,
TaxRate INT,
TaxAmount DECIMAL(6,2),
PaymentTotal DECIMAL(6,2) NOT NULL,
Notes TEXT
)

CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATETIME NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied INT,
PhoneCharge DECIMAL(6,2),
Notes TEXT
)

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES('Ivan','Ivanov','CTO',NULL),
('Dragan','Ivanov','CTO',NULL)

INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES('Ivan','Ivanov','0800000000','A','1111',NULL),
('Dragan','Draganov','1122334455','B','2233',NULL)

INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES('Ready',NULL), ('Clean',NULL)

INSERT INTO RoomTypes(RoomType, Notes)
VALUES('Single',NULL), ('Double',NULL)

INSERT INTO BedTypes(BedType, Notes)
VALUES('Daybed',NULL),('Futon',NULL)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES(1,'Single','Daybed',1,'Ready',NULL),(2,'Double','Futon',2,'Clean',NULL)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied,
TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES(1,'2000-12-10 05:30:00',NULL,'2001-10-10','2001-10-12',2,100.50,15,15,130.50,NULL),
(2,'2000-12-10 05:30:00',NULL,'2001-10-10','2001-10-12',2,100.50,15,15,130.50,NULL)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES(1,'2000-12-10 05:30:00',1,1,NULL,NULL,NULL),
(1,'2000-12-10 05:30:00',2,2,10,500.50,NULL)

--Problem 16.	Create SoftUni Database
CREATE DATABASE SoftUni

CREATE TABLE Towns(
Id INT IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
Id INT IDENTITY(1,1) NOT NULL,
AddressText NVARCHAR(MAX) NOT NULL,
TownId INT 
)

CREATE TABLE Departments(
Id INT IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT IDENTITY(1,1) NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
JobTitle NVARCHAR(50) NOT NULL,
DepartmentId INT NOT NULL,
HireDate DATE NOT NULL,
Salary DECIMAL(6,2) NOT NULL,
AddressId INT
)

ALTER TABLE Towns
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id) 

ALTER TABLE Addresses
ADD CONSTRAINT PK_AddressesId
PRIMARY KEY (Id)

ALTER TABLE Addresses
ADD CONSTRAINT FK_TownId
FOREIGN KEY (TownId) REFERENCES Towns(Id)

ALTER TABLE Departments
ADD CONSTRAINT PK_DepartmentsId
PRIMARY KEY (Id)

ALTER TABLE Employees
ADD CONSTRAINT PK_EmployeeId
PRIMARY KEY (Id)

ALTER TABLE Employees
ADD CONSTRAINT FK_EmployeeDepartmentId
FOREIGN KEY (DepartmentId) REFERENCES Employees(Id)

ALTER TABLE Employees
ADD CONSTRAINT FK_EmployeeAddressId
FOREIGN KEY (AddressId) REFERENCES Addresses(Id)

--Problem 17.	Backup Database

--Problem 18.	Basic Insert
INSERT INTO Towns([Name])
VALUES ('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas')

INSERT INTO Departments([Name])
VALUES ('Engineering'), ('Sales'), ('Marketing'), ('Software Development'), ('Quality Assurance')

--Problem 18.	Basic Insert
INSERT INTO Employees(FirstName,MiddleName,LastName,JobTitle,DepartmentId,HireDate,Salary)
VALUES('Ivan','Ivanov','Ivanov','.NET Developer',4,'2013-02-01',3500.00),
('Petar','Petrov','Petrov','Senior Engineer',1,'2004-03-02',4000.00),
('Maria','Petrova','Ivanova','Intern',5,'2016-08-28',525.25),
('Georgi','Teziev','Ivanov','CEO',2,'2007-12-09',3000.00),
('Peter','Pan','Pan','Intern',3,'2016-08-28',599.88)

--Problem 19.	Basic Select All Fields
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--Problem 20.	Basic Select All Fields and Order Them
SELECT * FROM Towns ORDER BY [Name] ASC
SELECT * FROM Departments ORDER BY [Name] ASC
SELECT * FROM Employees ORDER BY Salary DESC

--Problem 21.	Basic Select Some Fields
SELECT [Name] FROM Towns ORDER BY [Name] ASC

SELECT [Name] FROM Departments ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary 
FROM Employees 
ORDER BY Salary DESC

--Problem 22.	Increase Employees Salary
UPDATE Employees
SET Salary += 0.10 * Salary
SELECT Salary FROM Employees

--Problem 23.	Decrease Tax Rate
UPDATE Payments
SET TaxRate -= 0.3 * TaxRate
SELECT TaxRate FROM Payments

--Problem 24.	Delete All Records
TRUNCATE TABLE Occupancies