select Employees.FirstName, Employees.LastName, Employees.HireDate, Departments.Name
from Employees inner join Departments on Employees.DepartmentID = Departments.DepartmentID
where (Departments.Name = 'Sales' or Departments.Name = 'Finance') and 
	  (Employees.HireDate > CONVERT(DATETIME, '1995-12-31 00:00:00', 102) and Employees.HireDate < CONVERT(DATETIME, '2005-01-01 00:00:00', 102))
