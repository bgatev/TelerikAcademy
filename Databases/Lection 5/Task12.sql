select Employees.FirstName, Employees.LastName, isnull(empl.FirstName + empl.LastName, '(no manager)') as Manager
from Employees left join Employees empl on Employees.ManagerID = empl.EmployeeID
