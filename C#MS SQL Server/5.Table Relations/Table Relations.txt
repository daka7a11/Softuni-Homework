--Problem 1.One-To-One Relationship
CREATE TABLE Persons(
PersonID INT NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
Salary DECIMAL(18,2) NOT NULL,
PassportID INT NOT NULL
)

CREATE TABLE Passports(
PassportID INT NOT NULL,
PassportNumber NVARCHAR(50) NOT NULL
)

INSERT INTO Persons(PersonID,FirstName,Salary,PassportID)
VALUES
(1,'Roberto',43300.00,102),
(2,'Tom',56100.00,103),
(3,'Yana',60200.00,101)

INSERT INTO Passports(PassportID,PassportNumber)
VALUES
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')

ALTER TABLE Persons
ADD CONSTRAINT PK_PersonID
PRIMARY KEY (PersonID)

ALTER TABLE Passports
ADD CONSTRAINT PK_PassportID
PRIMARY KEY (PassportID)

ALTER TABLE Persons
ADD CONSTRAINT FK_PassportID
FOREIGN KEY (PassportID)
REFERENCES Passports(PassportID)

--Problem 2.One-To-Many Relationship
CREATE TABLE Models(
ModelID INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50) NOT NULL,
ManufacturerID INT NOT NULL
)

CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50) NOT NULL,
EstablishedOn DATE NOT NULL
)

ALTER TABLE Models
ADD CONSTRAINT FK_ManufacturerID
FOREIGN KEY (ManufacturerID)
REFERENCES Manufacturers(ManufacturerID)

--Problem 3.Many-To-Many Relationship
CREATE TABLE Students(
StudentID INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
ExamID INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams(
StudentID INT NOT NULL,
ExamID INT NOT NULL,
)

ALTER TABLE StudentsExams
ADD CONSTRAINT C_PK_StudentID_ExamID
PRIMARY KEY (StudentID, ExamID)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_StudentID
FOREIGN KEY (StudentID)
REFERENCES Students(StudentID)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_ExamID
FOREIGN KEY (ExamID)
REFERENCES Exams(ExamID)

INSERT INTO Students(StudentID,[Name])
VALUES(1,'Mila'),(2,'Toni'),(3,'Ron')

INSERT INTO Exams(ExamID,[Name])
VALUES(101,'SpringMVC'),(102,'Neo4j'),(103,'Oracle 11g')

INSERT INTO StudentsExams(StudentID,ExamID)
VALUES
(1,101), (1,102),
(2,101), (3,103),
(2,102), (2,103)

--Problem 4.Self-Referencing 
CREATE TABLE Teachers(
TeacherID INT NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
ManagerID INT
)

INSERT INTO Teachers(TeacherID,[Name],ManagerID)
VALUES
(101,'John',NULL),
(102,'Maya',106),
(103,'Silvia',106),
(104,'Ted',105),
(105,'Mark',101),
(106,'Greta',101)

ALTER TABLE Teachers
ADD CONSTRAINT PK_TeacherID
PRIMARY KEY (TeacherID)

ALTER TABLE Teachers
ADD CONSTRAINT FK_ManagerID_TeacherID
FOREIGN KEY (ManagerID)
REFERENCES Teachers(TeacherID)

--Problem 5.Online Store Database
CREATE TABLE Cities(
CityID INT PRIMARY KEY,
[Name] NVARCHAR(50)
)

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY ,
[Name] NVARCHAR(50),
Birthday DATE,
CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
OrderID INT PRIMARY KEY,
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
ItemTypeID INT PRIMARY KEY,
[Name] NVARCHAR(50)
)

CREATE TABLE Items(
ItemID INT PRIMARY KEY,
[Name] NVARCHAR(50),
ItemTypeID INT FOREIGN KEY REFERENCES Items(ItemID)
)

CREATE TABLE OrderItems(
OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL,
ItemID INT FOREIGN KEY REFERENCES Items(ItemID) NOT NULL
PRIMARY KEY (OrderID, ItemID)
)

--Problem 6.University Database
CREATE DATABASE University

CREATE TABLE Subjects(
SubjectID INT PRIMARY KEY,
SubjectName NVARCHAR(50)
)

CREATE TABLE Majors(
MajorID INT PRIMARY KEY,
[Name] NVARCHAR(50)
)

CREATE TABLE Students(
StudentID INT PRIMARY KEY,
StudentNumber NVARCHAR(50),
StudentName NVARCHAR(50),
MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
PaymentID INT PRIMARY KEY,
PaymentDate DATETIME,
PaymentAmount DECIMAL(18,2),
StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Agenda(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)
PRIMARY KEY (StudentID,SubjectID)
)

--Problem 9.*Peaks in Rila
SELECT MountainRange, PeakName, Elevation
FROM Mountains m
JOIN Peaks p
ON m.Id = p.MountainId
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC