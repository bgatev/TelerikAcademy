select q1.FullName, q1.Department, q2.Project, q2.StartDate, q2.EndDate
from 
(select (Employees.FirstName + ' ' + Employees.LastName) as FullName, Departments.Name as Department, Employees.Id
from Employees inner join Departments on Employees.DepartmentID = Departments.Id) q1 left join

(select EmployeesProjects.EmployeeID, Projects.Name as Project, EmployeesProjects.StartDate, EmployeesProjects.EndDate
from Projects inner join EmployeesProjects on Projects.Id = EmployeesProjects.ProjectID) q2 

on q1.Id = q2.EmployeeID
order by q1.Id
			   

