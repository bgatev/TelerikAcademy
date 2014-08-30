SELECT Employees.EmployeeID, Employees.FirstName, Employees.LastName, Employees.MiddleName, Addresses.AddressText as Address, Towns.Name as Town
FROM Employees inner join Addresses on Employees.AddressID = Addresses.AddressID
			   inner join Towns on Addresses.TownID = Towns.TownID