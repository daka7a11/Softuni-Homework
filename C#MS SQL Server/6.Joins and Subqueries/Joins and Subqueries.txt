--Problem 1.Employee Address
SELECT TOP(5)
	e.EmployeeID, 
	e.JobTitle, 
	e.AddressID, 
	a.AddressText
FROM Employees e
JOIN Addresses a
	ON e.AddressID = a.AddressID
ORDER BY e.AddressID

--Problem 2.Addresses with Towns
SELECT TOP 50 
	e.FirstName, e.LastName, t.[Name], a.AddressText
FROM Employees e
JOIN Addresses a ON e.AddressID= a.AddressID
JOIN Towns t ON a.TownID=t.TownID
ORDER BY e.FirstName ASC, e.LastName ASC

--Problem 3.Sales Employee
SELECT 
	e.EmployeeID, e.FirstName, e.LastName, d.[Name]
FROM Employees e
JOIN Departments d ON e.DepartmentID= d.DepartmentID AND d.[Name] = 'Sales'
ORDER BY e.EmployeeID ASC

--Problem 4.Employee Departments
SELECT TOP 5
	e.EmployeeID, e.FirstName, e.Salary, d.[Name]
FROM Employees e
JOIN Departments d ON e.DepartmentID=d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID ASC

--Problem 5.Employees Without Project
SELECT
	e.EmployeeID, e.FirstName, ep.ProjectID, p.[Name]
FROM Employees e
LEFT JOIN EmployeesProjects ep ON e.EmployeeID=ep.EmployeeID
LEFT JOIN Projects p ON ep.ProjectID=p.ProjectID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID ASC

--Problem 6.Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
FROM Employees e
JOIN Departments d ON e.DepartmentID=d.DepartmentID AND d.[Name] IN ('Sales','Finance')
WHERE e.HireDate > '01.01.1999'
ORDER BY e.HireDate ASC

--Problem 7.Employees with Project
SELECT TOP 5
	e.EmployeeID, e.FirstName, p.[Name]
FROM Employees e
JOIN EmployeesProjects ep ON e.EmployeeID=ep.EmployeeID
JOIN Projects p ON ep.ProjectID=p.ProjectID AND p.StartDate > '2002.08.13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID ASC

--Problem 8.Employee 24
SELECT
	e.EmployeeID, e.FirstName, 
	CASE
		WHEN p.StartDate >= '2005.01.01' THEN NULL
		ELSE p.[Name]
	END
FROM Employees e
JOIN EmployeesProjects ep ON e.EmployeeID=ep.EmployeeID
JOIN Projects p ON ep.ProjectID=p.ProjectID
WHERE e.EmployeeID = 24

--Problem 9.Employee Manager
SELECT e.EmployeeID, e.FirstName, e.ManagerID, e2.FirstName AS ManagerName
FROM Employees e
JOIN Employees e2 ON e.ManagerID=e2.EmployeeID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID ASC

--Problem 10.Employee Summary
SELECT TOP 50
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	d.[Name] AS [DepartmentName]
FROM Employees e
JOIN Employees m ON e.ManagerID=m.EmployeeID
JOIN Departments d ON e.DepartmentID=d.DepartmentID
ORDER BY e.EmployeeID

--Problem 11.Min Average Salary
SELECT MIN(AvgSalary) AS MinAverageSalary
FROM(
	SELECT AVG(Salary) AS AvgSalary
	FROM Employees
	GROUP BY DepartmentID ) AS AvgDepsSalaries

--Problem 12.Highest Peaks in Bulgaria
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries c
JOIN MountainsCountries mc ON c.CountryCode=mc.CountryCode
JOIN Mountains m ON mc.MountainId=m.Id
JOIN Peaks p ON m.Id=p.MountainId
WHERE c.CountryCode='BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--Problem 13.Count Mountain Ranges
SELECT *
FROM (
	SELECT c.CountryCode, COUNT(m.Id) AS [Count]
	FROM Countries c
	JOIN MountainsCountries mc ON c.CountryCode=mc.CountryCode
	JOIN Mountains m ON mc.MountainId=m.Id
	GROUP BY c.CountryCode) AS GroupedMountains
WHERE CountryCode IN('US','RU','BG')

--Problem 14.Countries with Rivers
SELECT TOP 5 
	c.CountryName, r.RiverName
FROM Countries c
LEFT JOIN CountriesRivers cr ON c.CountryCode=cr.CountryCode
LEFT JOIN Rivers r ON cr.RiverId=r.Id
WHERE c.ContinentCode='AF'
ORDER BY c.CountryName ASC

--Problem 15.*Continents and Currencies
SELECT
	t.ContinentCode, t.CurrencyCode, t.[Count]
FROM(
	SELECT 
		c.ContinentCode, 
		c.CurrencyCode,
		COUNT(c.CurrencyCode) AS [Count],
		DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [rank]
	FROM Countries c 
	GROUP BY c.ContinentCode, c.CurrencyCode) AS t
WHERE [rank] = 1 AND t.[Count] > 1
ORDER BY t.ContinentCode

--Problem 16.Countries without any Mountains
SELECT COUNT(c.CountryCode)
FROM Countries c
LEFT JOIN MountainsCountries mc ON c.CountryCode=mc.CountryCode
LEFT JOIN Mountains m ON mc.MountainId=m.Id
WHERE m.Id IS NULL

--Problem 17.Highest Peak and Longest River by Country
SELECT TOP 5
	c2.CountryName,
	MAX(p.Elevation) AS [HighestPeakElevation],
	MAX(r.[Length]) AS [LongestRiverLength]
FROM
	Countries c2
LEFT JOIN MountainsCountries mc ON c2.CountryCode=mc.CountryCode
LEFT JOIN Mountains m ON mc.MountainId=m.Id
LEFT JOIN Peaks p ON m.Id=p.MountainId
LEFT JOIN CountriesRivers cr ON c2.CountryCode=cr.CountryCode
LEFT JOIN Rivers r ON cr.RiverId=r.Id
GROUP BY c2.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c2.CountryName

--