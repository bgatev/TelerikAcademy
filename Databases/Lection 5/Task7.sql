select count(Employees.EmployeeID)
from Employees 
where Employees.ManagerID is not null