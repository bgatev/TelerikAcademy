SELECT        EmployeeID, FirstName, LastName, MiddleName, Salary
FROM            Employees
WHERE        (Salary > 20000) AND (Salary < 30000)
ORDER BY Salary