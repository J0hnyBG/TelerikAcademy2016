----------------------1----------------------

SELECT
	e.FirstName + ' ' + e.LastName AS [FullName]
	,e.YearlySalary -- Just for easy order by checking

FROM Employees e
WHERE e.YearlySalary BETWEEN 100000 AND 150000
ORDER BY e.YearlySalary


