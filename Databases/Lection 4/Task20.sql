SELECT Employees.EmployeeID, Employees.FirstName, Employees.LastName, Employees.MiddleName, empl.FirstName + ' ' + empl.LastName as Manager
FROM Employees inner join Employees empl on Employees.ManagerID = empl.EmployeeID
order by Employees.EmployeeID