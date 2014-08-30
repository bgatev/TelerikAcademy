SELECT empl.FirstName + ' ' + empl.LastName AS FullName, empl.Salary, Departments.Name as Department
FROM Employees empl INNER JOIN Departments ON empl.DepartmentID = Departments.DepartmentID
WHERE Salary = 
	(SELECT MIN(Salary) 
	 FROM Employees
	 WHERE Employees.DepartmentID = empl.DepartmentID)
ORDER BY Departments.Name