select count(Employees.EmployeeID)
from Employees inner join Departments on Employees.DepartmentID = Departments.DepartmentID
where Departments.Name = 'Sales'