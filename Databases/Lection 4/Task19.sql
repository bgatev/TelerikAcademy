SELECT Employees.EmployeeID, Employees.FirstName, Employees.LastName, Employees.MiddleName, Addresses.AddressText as Address, Towns.Name as Town
FROM Employees, Addresses, Towns  
WHERE Employees.AddressID = Addresses.AddressID and Addresses.TownID = Towns.TownID