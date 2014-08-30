select Employees.FirstName, Employees.LastName, Employees.Salary
from Employees
where Employees.Salary < (select min(empl.Salary) * 1.1
						 from Employees empl)