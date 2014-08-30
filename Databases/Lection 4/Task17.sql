SELECT        TOP (5) EmployeeID, FirstName, LastName, MiddleName, Salary
FROM            Employees
WHERE        (Salary > 50000)
ORDER BY Salary DESC