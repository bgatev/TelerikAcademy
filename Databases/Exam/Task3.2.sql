select Departments.Name, COUNT(*) as [Employees]
from  Employees inner join Departments on Employees.DepartmentID = Departments.Id
group by Departments.Name
order by [Employees] Desc