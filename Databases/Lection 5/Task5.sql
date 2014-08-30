select avg(Employees.Salary)
from Employees inner join Departments on Employees.DepartmentID = Departments.DepartmentID
where Departments.Name = 'Sales'