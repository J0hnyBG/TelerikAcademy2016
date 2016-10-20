------------------1---------------------
USE TelerikAcademy;

SELECT
	FirstName
	,LastName
	,Salary
FROM Employees
WHERE Salary = (SELECT
		MIN(Salary)
	FROM Employees);

------------------2---------------------
USE TelerikAcademy;

DECLARE @MinSalary MONEY;
SELECT
	@MinSalary = MIN(Salary)
FROM Employees;
SELECT
	FirstName
	,LastName
	,Salary
FROM Employees
WHERE Salary BETWEEN @MinSalary AND (@MinSalary * 1.1);

------------------3---------------------
USE TelerikAcademy;

SELECT
	e.FirstName
	,e.LastName
	,e.Salary
	,d.Name
FROM	Employees e
		,Departments d
WHERE Salary IN (SELECT
		MIN(Salary)
	FROM Employees
	WHERE DepartmentID = d.DepartmentID)
ORDER BY d.Name;

------------------4---------------------
USE TelerikAcademy;

SELECT
	AVG(Salary) AS [Average For Department 1]
FROM Employees
WHERE DepartmentID = 1;

------------------5---------------------
USE TelerikAcademy;

SELECT
	AVG(e.Salary) AS [Average Salary]
	,d.Name AS [Department Name]
FROM	Employees e
		,Departments d
WHERE e.DepartmentID = d.DepartmentID
AND d.Name = 'Sales'
GROUP BY d.Name;

------------------6---------------------
USE TelerikAcademy;

SELECT
	COUNT(*) AS [Employee Count]
	,d.Name AS [Department Name]
FROM	Employees e
		,Departments d
WHERE e.DepartmentID = d.DepartmentID
AND d.Name = 'Sales'
GROUP BY d.Name;

------------------7---------------------
USE TelerikAcademy;

SELECT
	COUNT(*) AS [Employees with a manager]
FROM Employees
WHERE ManagerID IS NOT NULL;

------------------8---------------------
USE TelerikAcademy;

SELECT
	COUNT(*) AS [Employees without a manager]
FROM Employees
WHERE ManagerID IS NULL;

------------------9---------------------
USE TelerikAcademy;

SELECT
	AVG(e.Salary) AS [Average Salary]
	,d.Name
FROM	Employees e
		,Departments d
WHERE e.DepartmentID = d.DepartmentID
GROUP BY	e.DepartmentID
			,d.Name;


------------------10---------------------
USE TelerikAcademy;

SELECT
	COUNT(*) AS [Employee Count]
	,d.Name
FROM	Employees e
		,Departments d
WHERE e.DepartmentID = d.DepartmentID
GROUP BY d.Name;

SELECT
	COUNT(*) AS [Employee Count]
	,t.Name
FROM Employees e
JOIN Addresses a
	ON a.AddressID = e.AddressID
JOIN Towns t
	ON t.TownID = a.TownID
WHERE t.TownID = a.TownID
GROUP BY t.Name;

------------------11---------------------
USE TelerikAcademy;

SELECT
	m.FirstName
	,m.LastName
FROM Employees m
WHERE m.employeeid IN (SELECT
		e.ManagerID
	FROM Employees e
	GROUP BY e.ManagerID
	HAVING COUNT(*) = 5);

------------------12---------------------
USE TelerikAcademy;

SELECT
	e.FirstName + ' ' + e.LastName AS [Full name]
	,ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS [Manager]
FROM Employees e
LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.employeeid
ORDER BY Manager;

------------------13---------------------
USE TelerikAcademy;

SELECT
	e.LastName
FROM Employees e
WHERE LEN(e.LastName) = 5;

------------------14---------------------

SELECT
	FORMAT(GETDATE(), 'dd.MM.yyyy HH:MM:ss:fff');

------------------15---------------------
USE TelerikAcademy;

CREATE TABLE [dbo].[Users] (
	[UserID] [INT] IDENTITY (1, 1) NOT NULL
	,[Username] [NVARCHAR](50) NOT NULL
	,[Passhash] [NVARCHAR](100) NULL
	,[FullName] [NVARCHAR](100) NOT NULL
	,[LastLogin] [DATETIME] NULL
	,[GroupID] [INT] NULL
	,CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED
	(
	[UserID] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

GO

------------------16---------------------
USE TelerikAcademy;

CREATE VIEW [Logins Today]
AS
SELECT
	*
FROM Users
WHERE LastLogin > DATEDIFF(DAY, 1, GETDATE());
GO
------------------17---------------------
USE TelerikAcademy;

CREATE TABLE Groups (
	ID INT NOT NULL IDENTITY PRIMARY KEY
	,Name NVARCHAR(50) UNIQUE
);
GO
------------------18---------------------
USE TelerikAcademy;

ALTER TABLE Users
ADD GroupID INT;

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
FOREIGN KEY (GroupID)
REFERENCES Groups (ID);

------------------19---------------------
USE TelerikAcademy;

INSERT INTO Groups
	VALUES ('Group1');
INSERT INTO Groups
	VALUES ('Group2');
INSERT INTO Groups
	VALUES ('Group3');
INSERT INTO Groups
	VALUES ('Group4');

INSERT INTO Users
	VALUES ('pesho123', 'KJ*&IOioASD*(@#hdasd7872DAS7896', 'Petar Petrov', GETDATE(), 1);
INSERT INTO Users
	VALUES ('gosho', 'KJ*&IOioASD*(@#hdasd7872DAS7896', 'Gosho Petrov', GETDATE(), 1);
INSERT INTO Users
	VALUES ('tosho', 'KJ*&IOioASD*(@#hdasd7872DAS7896', 'tosho Petrov', GETDATE(), 1);
INSERT INTO Users
	VALUES ('pesho456', 'KJ*&IOioASD*(@#hdasd7872DAS7896', 'Petar Ivanov', GETDATE(), 1);
INSERT INTO Users
	VALUES ('ivan', 'KJ*&IOioASD*(@#hdasd7872DAS7896', 'Ivan Ivanov', GETDATE(), 2);

------------------20---------------------
USE TelerikAcademy;

UPDATE Groups
SET Name = 'Group1000'
WHERE ID = 1;

UPDATE Users
SET GroupID = 3
WHERE Username = 'gosho';

------------------21---------------------
USE TelerikAcademy;

DELETE FROM Groups
WHERE ID = 4;
DELETE FROM Users
WHERE UserID = 4;

------------------22---------------------
USE TelerikAcademy;

INSERT INTO Users (Username, Passhash, FullName)
		SELECT
			LOWER(LEFT(e.FirstName, 1) + e.LastName)
			,LOWER(LEFT(e.FirstName, 1) + e.LastName)
			,e.FirstName + ' ' + e.LastName

		FROM Employees e;
------------------23---------------------
USE TelerikAcademy;

UPDATE Users
SET Passhash = NULL
WHERE CONVERT(DATETIME, LastLogin, 1) < CONVERT(DATETIME, '03/10/10', 1)
OR LastLogin IS NULL;

------------------24---------------------
USE TelerikAcademy;

DELETE FROM Users
WHERE Passhash IS NULL;

------------------25---------------------
USE TelerikAcademy;

SELECT
	AVG(e.Salary) AS [Average salary]
	,e.JobTitle
	,d.Name
FROM	Employees e
		,Departments d
WHERE e.DepartmentID = d.DepartmentID
GROUP BY	e.DepartmentID
			,e.JobTitle
			,d.Name
ORDER BY AVG(e.Salary) ASC;

------------------26---------------------
USE TelerikAcademy;

SELECT
	MIN(e.Salary) AS [MinimumSalary]
	,d.Name AS [DepartmentName]
	,e.JobTitle
	,(SELECT TOP (1)
			em.FirstName + ' ' + em.LastName
		FROM Employees em
		WHERE em.Salary = MIN(e.Salary))
	AS [Full Name]
FROM	Employees e
		,Departments d
WHERE e.DepartmentID = d.DepartmentID
GROUP BY	e.DepartmentID
			,e.JobTitle
			,d.Name
ORDER BY AVG(e.Salary) ASC;

------------------27---------------------
USE TelerikAcademy;

SELECT
	t.Name AS [Most Employees]
FROM Towns t
WHERE t.TownID IN (SELECT TOP (100)
		a.TownID
	FROM Employees e
	JOIN Addresses a
		ON a.AddressID = e.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
	GROUP BY	a.TownID
				,t.Name
	ORDER BY COUNT(*) DESC);

------------------28---------------------
USE TelerikAcademy;

SELECT
	t.Name AS [Town Name]
	,COUNT(*) AS [Managers Count]
FROM	Employees e
		,Addresses a
		,Towns t
WHERE e.employeeid
IN (SELECT
		m.ManagerID
	FROM Employees m)
AND e.AddressID = a.AddressID
AND a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(*) DESC;

------------------29---------------------
USE TelerikAcademy;

CREATE TABLE WorkHours (
	ID INT IDENTITY PRIMARY KEY
	,employeeid INT
	,dates DATETIME
	,task NVARCHAR(200)
	,hoursWorked INT
	,comments NTEXT
);

ALTER TABLE WorkHours
ADD CONSTRAINT FK_WORKHOURS_EMPLOYEES
FOREIGN KEY (employeeid)
REFERENCES Employees (employeeid);

CREATE TABLE WorkHoursLogs (
	ID INT IDENTITY PRIMARY KEY
	,changeTime DATETIME
	,changeType NVARCHAR(50)
);
GO

CREATE TRIGGER ONINSERT
ON TelerikAcademy.dbo.WorkHours
AFTER INSERT
AS
	INSERT INTO TelerikAcademy.dbo.WorkHoursLogs
		VALUES (GETDATE(), 'INSERT');
GO
CREATE TRIGGER ONUPDATE
ON TelerikAcademy.dbo.WorkHours
AFTER UPDATE
AS
	INSERT INTO TelerikAcademy.dbo.WorkHoursLogs
		VALUES (GETDATE(), 'UPDATE');
GO
CREATE TRIGGER ONDELETE
ON TelerikAcademy.dbo.WorkHours
AFTER DELETE
AS
	INSERT INTO TelerikAcademy.dbo.WorkHoursLogs
		VALUES (GETDATE(), 'DELETE');
GO

INSERT INTO WorkHours (dates)
	VALUES (GETDATE());