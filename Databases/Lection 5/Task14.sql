select Employees.EmployeeID, Employees.FirstName, Employees.LastName, Employees.MiddleName, Employees.JobTitle, 
Convert(varchar(10),Employees.HireDate, 104) + ' ' + Convert(varchar(12),Employees.HireDate, 114) as HireDate, Employees.Salary
from Employees