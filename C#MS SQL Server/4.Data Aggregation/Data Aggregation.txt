--Problem 1.Records’ Count
SELECT COUNT(d.Id) AS [Count]
FROM WizzardDeposits d

--Problem 2.Longest Magic Wand
SELECT MAX(d.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits d

--Problem 3.Longest Magic Wand per Deposit Groups
SELECT d.DepositGroup ,
	MAX(d.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits d
GROUP BY (d.DepositGroup)

--Problem 4.*Smallest Deposit Group per Magic Wand Size
SELECT TOP(2) d.DepositGroup
FROM WizzardDeposits d
GROUP BY (d.DepositGroup)
ORDER BY AVG(d.MagicWandSize)

--Problem 5.Deposits Sum
SELECT d.DepositGroup, SUM(d.DepositAmount)
FROM WizzardDeposits d
GROUP BY (d.DepositGroup)

--Problem 6.Deposits Sum for Ollivander Family
SELECT d.DepositGroup, SUM(d.DepositAmount)
FROM WizzardDeposits d
WHERE d.MagicWandCreator = 'Ollivander family'
GROUP BY d.DepositGroup

--Problem 7.Deposits Filter
SELECT d.DepositGroup, SUM(d.DepositAmount)
FROM WizzardDeposits d
WHERE d.MagicWandCreator = 'Ollivander family'
GROUP BY d.DepositGroup
HAVING SUM(d.DepositAmount) < 150000
ORDER BY SUM(d.DepositAmount) DESC

--Problem 8.Deposit Charge
SELECT d.DepositGroup,
		d.MagicWandCreator,
		MIN(d.DepositCharge) AS MinDepositCharge
FROM WizzardDeposits d
GROUP BY d.DepositGroup, d.MagicWandCreator
ORDER BY d.MagicWandCreator, d.DepositGroup

--Problem 9.Age Groups
SELECT 
	CASE
		WHEN d.Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN d.Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN d.Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN d.Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN d.Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN d.Age BETWEEN 51 AND 60 THEN '[51-60]'
		WHEN d.Age >= 61 THEN '[61+]'
	END AS [AgeGroup],
	COUNT(*) AS WizzardCount
FROM WizzardDeposits d
GROUP BY CASE
		WHEN d.Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN d.Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN d.Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN d.Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN d.Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN d.Age BETWEEN 51 AND 60 THEN '[51-60]'
		WHEN d.Age >= 61 THEN '[61+]'
	END

--Problem 10.First Letter
SELECT LEFT(d.FirstName,1) AS FirstLetter
FROM WizzardDeposits d
WHERE d.DepositGroup = 'Troll Chest'
GROUP BY (LEFT(d.FirstName,1))
ORDER BY LEFT(d.FirstName,1)

--Problem 11.Average Interest 
SELECT d.DepositGroup,
		d.IsDepositExpired,
		AVG(d.DepositInterest)
FROM WizzardDeposits d
WHERE d.DepositStartDate > '01/01/1985'
GROUP BY d.DepositGroup, d.IsDepositExpired
ORDER BY d.DepositGroup DESC, d.IsDepositExpired ASC

--Problem 12.*Rich Wizard, Poor Wizard
SELECT SUM([Difference]) AS [SumDifference]
FROM (
	SELECT 
		d.FirstName AS [Host Wizard],
		d.DepositAmount AS [Host Wizard Deposit],
		LEAD(d.FirstName) OVER(ORDER BY d.Id) AS [Guest Wizard],
		LEAD(d.DepositAmount) OVER(ORDER BY d.Id) AS [Guest Wizard Deposit],
		d.DepositAmount - LEAD(d.DepositAmount) OVER(ORDER BY d.Id) AS [Difference]
	FROM WizzardDeposits d) AS DiffTable

--Problem 13.Departments Total Salaries
SELECT 
	DepartmentId,
	SUM(Salary) AS [TotalSalary]
FROM Employees
GROUP BY DepartmentID

--Problem 14.Employees Minimum Salaries
SELECT 
	DepartmentID,
	MIN(Salary) AS [MinimumSalary]
FROM Employees 
WHERE HireDate > '01/01/2000'
GROUP BY DepartmentID
HAVING DepartmentID IN (2, 5, 7)

--Problem 15.Employees Average Salaries
SELECT * INTO NewEmployeeTable
FROM Employees
WHERE Salary > 30000

DELETE FROM NewEmployeeTable
WHERE ManagerID = 42

UPDATE NewEmployeeTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT 
	DepartmentID,
	AVG(Salary) AS [AverageSalary]
FROM NewEmployeeTable
GROUP BY DepartmentID

--Problem 16.Employees Maximum Salaries
SELECT 
	DepartmentID,
	MAX(Salary) AS [MaxSalary]
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--Problem 17.Employees Count Salaries
SELECT
	COUNT(EmployeeID) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

--Problem 18.*3rd Highest Salary
SELECT 
	DepartmentID,
	Salary AS [ThirdHighestSalary]
FROM(
	SELECT
		DepartmentID,
		Salary,
		DENSE_RANK() OVER(PARTITION BY DepartmentId ORDER BY Salary DESC) AS [Rank]
	FROM Employees
	GROUP BY DepartmentID, Salary) AS EmplTable
WHERE [Rank] = 3

--Problem 19.**Salary Challenge
SELECT TOP(10)
	FirstName, 
	LastName,
	DepartmentID
FROM Employees e1
WHERE e1.Salary > ( SELECT AVG(Salary)
					FROM Employees AS e2
					WHERE e2.DepartmentID = e1.DepartmentID
					GROUP BY DepartmentID )
ORDER BY DepartmentID