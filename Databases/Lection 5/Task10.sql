select Towns.Name as Town, Departments.Name as Department, count(Employees.EmployeeID) as Employeers
from Employees inner join Departments on Employees.DepartmentID = Departments.DepartmentID
			   inner join Addresses on Employees.AddressID = Addresses.AddressID
			   inner join Towns on Addresses.TownID = Towns.TownID
group by Towns.Name, Departments.Name
order by Towns.Name