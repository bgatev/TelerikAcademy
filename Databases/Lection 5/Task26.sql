SELECT MIN(Employees.FirstName + ' ' + Employees.LastName) as FullName,  Departments.DepartmentID, Departments.Name as Department, 
	   Employees.JobTitle, MIN(Salary) as 'Min Salary'
FROM Employees INNER JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
GROUP BY Departments.DepartmentID, Departments.Name, Employees.JobTitle
ORDER BY Departments.DepartmentID