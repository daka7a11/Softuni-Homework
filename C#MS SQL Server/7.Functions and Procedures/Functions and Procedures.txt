--1.Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS 
SELECT e.FirstName, e.LastName
FROM Employees AS e
WHERE e.Salary > 35000

--2.Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@salary DECIMAL(18,4))
AS
SELECT e.FirstName, e.LastName
FROM Employees AS e
WHERE e.Salary >= @salary

--3.Town Names Starting With
CREATE PROC usp_GetTownsStartingWith (@string NVARCHAR(20))
AS
SELECT t.[Name]
FROM Towns AS t
WHERE t.[Name] LIKE @string+'%'

--4.Employees from Town
CREATE PROC usp_GetEmployeesFromTown (@townName NVARCHAR(20))
AS
SELECT e.FirstName, e.LastName
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID=a.AddressID
JOIN Towns AS t ON a.TownID=t.TownID
WHERE t.[Name] = @townName

--5.Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
DECLARE @salaryLevel NVARCHAR(10)
	IF (@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF(@salary BETWEEN 30000 AND 50000)
	BEGIN
		SET @salaryLevel = 'Average'
	END
	ELSE
	BEGIN
		SET @salaryLevel = 'High'
	END
	RETURN @salaryLevel
END

--6.Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel NVARCHAR(10))
AS
SELECT e.FirstName, e.LastName
FROM Employees AS e
WHERE @salaryLevel = dbo.ufn_GetSalaryLevel(e.Salary)

--7.Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX)) 
RETURNS BIT
AS
BEGIN
DECLARE @isWordComprised BIT
DECLARE @wordCount INT = 1
DECLARE @char CHAR(1)
DECLARE @countToExit INT = LEN(@word)
	WHILE(@wordCount < LEN(@word) + 1)
	BEGIN
	DECLARE @setCount INT = 1
		WHILE(@setCount < LEN(@setOfLetters) + 1)
		BEGIN
			SET @char = SUBSTRING(@word, @wordCount, 1)
				IF(@char = SUBSTRING(@setOfLetters, @setCount, 1))
				BEGIN 
					SET @wordCount += 1
					BREAK
				END
			SET @setCount += 1
		END
		SET @countToExit -= 1
		IF(@countToExit < -1)
		BEGIN
			BREAK
		END
	END
	IF(@wordCount = LEN(@word) + 1)
	BEGIN
		SET @isWordComprised = 1
	END
	ELSE
	BEGIN
		SET @isWordComprised = 0
	END
	RETURN @isWordComprised
END


--8.*Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
		SELECT EmployeeID
		FROM Employees
		WHERE DepartmentID = @departmentId
	)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
		SELECT EmployeeID
		FROM Employees
		WHERE DepartmentID = @departmentId
	)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId
END

--9.Find Full Name
CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT a.FirstName + ' ' + a.LastName AS [Full Name]
	FROM AccountHolders AS a
END

--10.People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@number DECIMAL(18,4))
AS
BEGIN
	SELECT a.FirstName AS [First Name], a.LastName AS [Last Name]
	FROM AccountHolders AS a
	JOIN Accounts AS ac ON a.Id=ac.AccountHolderId
	GROUP BY a.FirstName, a.LastName
	HAVING SUM(ac.Balance) > @number
	ORDER BY a.FirstName, a.LastName
END

--11.Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4), @yearlyInterestRate FLOAT, @years INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	RETURN @sum*(POWER((1+@yearlyInterestRate),@years))
END

--12.Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount (@accountId INT, @interestRate FLOAT)
AS
SELECT 
	ah.Id AS [Account Id],
	ah.FirstName AS [First Name],
	ah.LastName AS [Last Name],
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance,@interestRate,5) AS [Balance in 5 years]
FROM AccountHolders AS ah
JOIN Accounts AS a ON ah.Id=a.Id
WHERE ah.Id = @accountId

--13.*Scalar Function: Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS @output TABLE(SumCash DECIMAL(18,4))
AS
BEGIN
	INSERT INTO @output SELECT (
		SELECT SUM(lastTable.Cash)
		FROM(
			SELECT *
			FROM(
				SELECT ug.UserId,ug.Cash,[Name], g.Id, ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS RowNumber
				FROM Games AS g
				JOIN UsersGames AS ug ON g.Id=ug.GameId
				WHERE g.[Name] = @gameName) AS gt
			WHERE gt.RowNumber % 2 <> 0) AS lastTable)
	RETURN;
END