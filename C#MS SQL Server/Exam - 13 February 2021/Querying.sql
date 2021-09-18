--Commits
SELECT c.Id, c.[Message], c.RepositoryId, c.ContributorId
FROM Commits AS c
ORDER BY c.Id, c.[Message], c.RepositoryId, c.ContributorId

--Front-end
SELECT f.Id, f.[Name], f.Size
FROM Files AS f
WHERE f.Size > 1000 AND f.[Name] LIKE '%html%'
ORDER BY f.Size DESC, f.Id, f.[Name]

--Issue Assignment
SELECT i.Id, CONCAT(u.Username, ' : ',i.Title)
FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, u.Id

--Single Files
SELECT p.Id, p.[Name], CONCAT(p.Size, 'KB') AS [Size]
FROM Files AS f
RIGHT JOIN Files AS p ON f.ParentId=p.Id
WHERE f.Id IS NULL
ORDER BY p.Id, p.[Name],p.Size DESC
---------------------------------

--Commits in Repositories
SELECT TOP(5) r.Id, r.[Name], COUNT(c.RepositoryId) AS [Commits]
FROM Repositories AS r
JOIN Commits AS c ON r.Id=c.RepositoryId
LEFT JOIN RepositoriesContributors AS rc
ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.Name
ORDER BY COUNT(c.Id) DESC, r.Id, r.[Name]

--Average Size
SELECT u.Username, AVG(f.Size) AS [Size]
FROM Users AS u
JOIN Commits AS c ON u.Id=c.ContributorId
JOIN Files AS f ON c.Id=f.CommitId
GROUP BY u.Username
ORDER BY Size DESC, u.Username

--All User Commits
CREATE OR ALTER FUNCTION udf_AllUserCommits(@username VARCHAR(50)) 
RETURNS INT
AS
BEGIN
DECLARE @output INT
SET @output = (
	SELECT COUNT(c.Id) AS [Output]
	FROM Users AS u
	JOIN Commits AS c ON u.Id=c.ContributorId
	WHERE u.Username = @username
	GROUP BY u.Username)
	RETURN @output
END

--Search for Files
CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(20))
AS
BEGIN
	SELECT f.Id, f.[Name], CONCAT(f.Size,'KB') AS [Size]
	FROM Files AS f
	WHERE f.[Name] LIKE '%'+@fileExtension
	ORDER BY f.Id, f.[Name], f.Size DESC
	RETURN
END

EXEC usp_SearchForFiles 'txt'