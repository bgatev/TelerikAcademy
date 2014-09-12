SELECT (Employees.FirstName + ' ' + Employees.LastName) as FullName, YearSalary
FROM Employees
where Employees.YearSalary > 100000 and Employees.YearSalary < 500000
order by Employees.YearSalary