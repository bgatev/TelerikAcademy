select Departments.Name as Department, avg(Employees.Salary) as 'Average Salary'
from Departments inner join Employees on Departments.DepartmentID = Employees.DepartmentID
group by Departments.Name
