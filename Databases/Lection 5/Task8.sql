select count(Employees.EmployeeID)
from Employees 
where Employees.ManagerID is null