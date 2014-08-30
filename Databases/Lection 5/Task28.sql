SELECT Towns.Name AS Town, COUNT(Towns.Name) AS 'Managers Count'
FROM Employees INNER JOIN 
						 (SELECT empl.ManagerID 
						  FROM Employees empl 
						  WHERE empl.ManagerID IS NOT NULL 
						  GROUP BY empl.ManagerID) 
											 AS AllManagers ON Employees.EmployeeID = AllManagers.ManagerID
		INNER JOIN Addresses ON Employees.AddressID = Addresses.AddressID
		INNER JOIN Towns ON Addresses.TownID = Towns.TownID
GROUP BY Towns.Name