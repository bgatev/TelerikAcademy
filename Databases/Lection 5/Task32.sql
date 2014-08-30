SELECT * INTO #TempEmployeesProjects 
FROM EmployeesProjects;

DROP TABLE EmployeesProjects;

SELECT * INTO EmployeesProjects
FROM #TempEmployeesProjects;

DROP TABLE #TempEmployeesProjects