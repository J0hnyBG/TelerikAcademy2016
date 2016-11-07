SELECT
	[Employees].[FirstName] + ' ' + [Employees].[LastName] AS [EmployeeName]
	,[Projects].[Name] AS [ProjectName]
	,[Departments].[Name] AS [DepartmentName]
	,StartDate
	,EndDate
	,(SELECT
			COUNT(*)
		FROM [Reports]
		WHERE [ReportTime] BETWEEN [EmployeesProjects].StartDate AND [EmployeesProjects].EndDate)
	AS [ReportsCount]
FROM [Employees]
LEFT JOIN [Departments]
	ON [Departments].[Id] = [Employees].[DepartmentId]
LEFT JOIN [EmployeesProjects]
	ON [EmployeesProjects].[EmployeeID] = [Employees].[Id]
LEFT JOIN [Projects]
	ON [Projects].[Id] = [EmployeesProjects].ProjectId
ORDER BY [EmployeeID], [ProjectId]