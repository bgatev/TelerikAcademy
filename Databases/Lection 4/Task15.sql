SELECT        EmployeeID, FirstName, LastName, MiddleName, ManagerID
FROM            Employees
WHERE        (ManagerID IS NULL)