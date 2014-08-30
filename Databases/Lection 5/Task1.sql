select Employees.FirstName, Employees.LastName, Employees.Salary
from Employees
where Employees.Salary in 
	(select min(empl.Salary)
	 from Employees empl)