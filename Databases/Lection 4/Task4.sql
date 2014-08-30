select Departments.DepartmentID, Departments.Name, Employees.FirstName, Employees.LastName, Employees.JobTitle, Employees.HireDate, Employees.Salary,
		Towns.Name, Addresses.AddressText
from Departments inner join Employees on Departments.ManagerID = Employees.EmployeeID
				 inner join Addresses on Employees.AddressID = Addresses.AddressID
				 inner join Towns on Addresses.TownID = Towns.TownID
order by Departments.DepartmentID