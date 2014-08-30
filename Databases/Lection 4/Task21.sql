SELECT Employees.EmployeeID, Employees.FirstName, Employees.LastName, Employees.MiddleName, empl.FirstName + ' ' + empl.LastName as Manager, 
	   Addresses.AddressText as Address, Towns.Name as Town
FROM Employees inner join Employees empl on Employees.ManagerID = empl.EmployeeID
			   inner join Addresses on Employees.AddressID = Addresses.AddressID
			   inner join Towns on Addresses.TownID = Towns.TownID
order by Employees.EmployeeID