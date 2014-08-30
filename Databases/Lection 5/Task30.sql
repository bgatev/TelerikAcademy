ALTER TABLE dbo.Employees DROP CONSTRAINT FK_Employees_Addresses_Cascade;
ALTER TABLE dbo.Employees
ADD CONSTRAINT FK_Employees_Addresses_Cascade
FOREIGN KEY (AddressID) REFERENCES dbo.Addresses(AddressID) ON DELETE CASCADE;

ALTER TABLE dbo.Employees DROP CONSTRAINT FK_Employees_Departments_Cascade;
ALTER TABLE dbo.Employees
ADD CONSTRAINT FK_Employees_Departments_Cascade
FOREIGN KEY (DepartmentID) REFERENCES dbo.Departments(DepartmentID) ON DELETE CASCADE;

ALTER TABLE dbo.EmployeesProjects DROP CONSTRAINT FK_EmployeesProjects_Employees;
ALTER TABLE dbo.EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Employees_Cascade
FOREIGN KEY (EmployeeID) REFERENCES dbo.Employees(EmployeeID) ON DELETE CASCADE;

BEGIN TRAN DeleteEmployee
DELETE FROM Employees WHERE DepartmentId IN (SELECT DepartmentId FROM Departments WHERE Name = 'Sales');

ROLLBACK TRAN