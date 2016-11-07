USE Company
GO

CREATE PROCEDURE uspCreateCacheTable
AS
	CREATE TABLE Query3CacheTable (
		EmployeeName NVARCHAR(41)
		,ProjectsName NVARCHAR(50)
		,DepartmentName NVARCHAR(50)
		,StartDate DATETIME
		,EndDate DATETIME
		,ReportsCount INT
		,
	);
GO
EXEC uspCreateCacheTable;
GO

CREATE PROCEDURE dbo.uspUpdateCacheTable
AS
	DELETE FROM Query3CacheTable;
	INSERT INTO Query3CacheTable
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
			ORDER BY [EmployeeID], [ProjectId];
GO

EXEC uspUpdateCacheTable;
GO