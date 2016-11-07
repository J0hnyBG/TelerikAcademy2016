----------------------2----------------------

SELECT
	d.Name AS [DepartmentName]
	,COUNT(e.Id) AS [EmployeesInDepartment]
FROM Departments d
INNER JOIN Employees e
	ON e.DepartmentId = d.Id
GROUP BY d.Name
ORDER BY COUNT(e.Id) DESC