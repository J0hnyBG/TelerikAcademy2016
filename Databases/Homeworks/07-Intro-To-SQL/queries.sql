-----------------4--------------------
USE TelerikAcademy
SELECT
	d.Name
	,e.FirstName + ' ' + e.LastName AS [ManagerName]
FROM Departments d
INNER JOIN Employees e
	ON d.ManagerID = e.EmployeeID

-----------------5--------------------
USE TelerikAcademy
SELECT
	Name
FROM Departments

-----------------6--------------------
USE TelerikAcademy
SELECT
	e.FirstName
	,e.LastName
	,e.Salary
FROM Employees e

-----------------7--------------------
USE TelerikAcademy
SELECT
	e.FirstName + ' ' + e.LastName AS [FullName]
FROM Employees e

-----------------8--------------------
USE TelerikAcademy
SELECT
	e.FirstName + '.' + e.LastName + '@telerik.com' AS [Full Email Address]
FROM Employees e

-----------------9--------------------
USE TelerikAcademy
SELECT DISTINCT
	e.Salary
FROM Employees e

-----------------10--------------------
USE TelerikAcademy
SELECT
	e.FirstName
	,e.LastName
FROM Employees e
WHERE e.JobTitle = 'Sales Representative'

-----------------11--------------------
USE TelerikAcademy
SELECT
	e.FirstName
	,e.LastName
FROM Employees e
WHERE e.FirstName LIKE 'SA%'

-----------------12--------------------
USE TelerikAcademy
SELECT
	e.FirstName
	,e.LastName
FROM Employees e
WHERE e.LastName LIKE '%ei%'

-----------------13--------------------
USE TelerikAcademy
SELECT
	e.FirstName
	,e.LastName
	,e.Salary
FROM Employees e
WHERE e.Salary BETWEEN 20000 AND 30000

-----------------14--------------------
USE TelerikAcademy
SELECT
	e.FirstName
	,e.LastName
	,e.Salary
FROM Employees e
WHERE e.Salary IN (12500, 14000, 23600, 25000)

-----------------15--------------------
USE TelerikAcademy
SELECT
	e.FirstName
	,e.LastName
	,e.Salary
	,e.ManagerID
FROM Employees e
WHERE e.ManagerID IS NULL

-----------------16--------------------
USE TelerikAcademy
SELECT
	e.FirstName
	,e.LastName
	,e.Salary
	,e.ManagerID
FROM Employees e
WHERE e.Salary > 50000
ORDER BY e.Salary DESC

-----------------17--------------------
USE TelerikAcademy
SELECT TOP 5
	e.FirstName
	,e.LastName
	,e.Salary
	,e.ManagerID
FROM Employees e
ORDER BY e.Salary DESC

-----------------18--------------------
USE TelerikAcademy
SELECT
	e.FirstName + ' ' + e.LastName AS [Full Name]
	,a.AddressText + ', ' + t.Name AS [Full Address]
FROM Employees e
INNER JOIN Addresses a
	ON a.AddressID = e.AddressID
INNER JOIN Towns t
	ON t.TownID = a.TownID

-----------------19--------------------
USE TelerikAcademy
SELECT
	e.FirstName + ' ' + e.LastName AS [Full Name]
	,a.AddressText + ', ' + t.Name AS [Full Address]
FROM	Employees e
		,Addresses a
		,Towns t
WHERE e.AddressID = a.AddressID
AND a.TownID = t.TownID

-----------------20--------------------
USE TelerikAcademy
SELECT
	e.FirstName + ' ' + e.LastName AS [Full Name]
	,m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees e
INNER JOIN Employees m
	ON m.EmployeeID = e.ManagerID

-----------------21--------------------
USE TelerikAcademy
SELECT
	e.FirstName + ' ' + e.LastName AS [Full Name]
	,a.AddressText + ', ' + t.Name AS [Full Address]
	,m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees e
INNER JOIN Employees m
	ON m.EmployeeID = e.ManagerID
INNER JOIN Addresses a
	ON a.AddressID = e.AddressID
INNER JOIN Towns t
	ON t.TownID = a.TownID

-----------------22--------------------
USE TelerikAcademy
SELECT
	t.Name
FROM Towns t
UNION
SELECT
	d.Name
FROM Departments d

-----------------23--------------------
USE TelerikAcademy
SELECT
	e.FirstName + ' ' + e.LastName AS [Full Name]
	,m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees m
RIGHT OUTER JOIN Employees e
	ON m.EmployeeID = e.ManagerID

-----------------23.5--------------------
USE TelerikAcademy
SELECT
	e.FirstName + ' ' + e.LastName AS [Full Name]
	,m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees e
LEFT OUTER JOIN Employees m
	ON m.EmployeeID = e.ManagerID

-----------------24--------------------
USE TelerikAcademy
SELECT
	e.FirstName
	,e.LastName
	,e.HireDate
	,d.Name
FROM Employees e
INNER JOIN Departments d
	ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate BETWEEN '1995-01-01 00:00:00' AND '2004-12-31 00:00:00'
AND e.DepartmentID IN (3, 10)