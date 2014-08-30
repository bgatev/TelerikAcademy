select Departments.DepartmentID, Departments.Name, Employees.JobTitle, AVG(Employees.Salary) as 'Average Salary'
from Departments inner join Employees on Departments.DepartmentID = Employees.DepartmentID
group by Departments.DepartmentID, Departments.Name, Employees.JobTitle
order by Departments.DepartmentID