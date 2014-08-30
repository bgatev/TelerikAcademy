SELECT Employees.EmployeeID, Employees.FirstName, Employees.LastName
FROM Employees inner join Employees empl ON Employees.EmployeeID = empl.ManagerID
GROUP BY Employees.EmployeeID, Employees.FirstName, Employees.LastName
HAVING COUNT(empl.ManagerID) = 5