SELECT Employees.EmployeeID, Employees.FirstName, Employees.LastName, Employees.MiddleName, Employees.JobTitle, Departments.Name as Department, Employees.HireDate, 
		Employees.Salary, Addresses.AddressText as Address,Towns.Name as Town, Empl.FirstName + ' ' + Empl.LastName AS 'Manager'
FROM Employees inner join Departments on Employees.DepartmentID = Departments.DepartmentID
			   inner join Addresses on Employees.AddressID = Addresses.AddressID
			   inner join Towns on Addresses.TownID = Towns.TownID
			   inner join Employees as Empl on Employees.ManagerID=Empl.EmployeeID		
WHERE (Employees.JobTitle = N'Sales Representative')