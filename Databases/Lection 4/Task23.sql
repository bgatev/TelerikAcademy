select Employees.FirstName, Employees.LastName, empl.FirstName + ' ' + empl.LastName as Manager
from Employees right join Employees empl on Employees.ManagerID = empl.EmployeeID

select Employees.FirstName, Employees.LastName, empl.FirstName + ' ' + empl.LastName as Manager
from Employees left join Employees empl on Employees.ManagerID = empl.EmployeeID