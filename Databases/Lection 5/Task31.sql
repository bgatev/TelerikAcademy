BEGIN TRAN
	SELECT * INTO #TempEmployeesProjects 
	FROM EmployeesProjects;

	DROP TABLE EmployeesProjects;

GO

BEGIN TRAN
	SELECT * INTO EmployeesProjects
	FROM #TempEmployeesProjects;

	DROP TABLE #TempEmployeesProjects
GO