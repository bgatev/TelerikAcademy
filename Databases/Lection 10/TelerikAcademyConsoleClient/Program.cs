namespace TelerikAcademyConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Linq;

    using TelerikAcademyModel;

    public class Program
    {

        public static void Main()
        {
            //Task 1
            GetAllEmployees();

            //Task 2
            GetAllEmployeesLinq();
        }

        private static void GetAllEmployees()
        {
            TelerikAcademy dbContext = new TelerikAcademy();

            using (dbContext)
            {
                
                // Only one Query in SQL Server Profiler
                var allEmployees = dbContext.Employees.Join(dbContext.Departments, empl => empl.DepartmentID, dep => dep.DepartmentID, (empl, dep) => new { empl, dep })
                                                     .Join(dbContext.Addresses, em => em.empl.AddressID, addr => addr.AddressID, (em, addr) => new { em, addr })
                                                     .Join(dbContext.Towns, ad => ad.addr.TownID, t => t.TownID, (ad, t) => new { ad, t })
                                                     .Select(e => new
                                                     {
                                                         FirstName = e.ad.em.empl.FirstName,
                                                         LastName = e.ad.em.empl.LastName,
                                                         Department = e.ad.em.dep.Name,
                                                         Town = e.t.Name
                                                     }).ToList();

                foreach (var employee in allEmployees)
                {
                    Console.WriteLine("{0} {1} {2} {3}", employee.FirstName, employee.LastName, employee.Department, employee.Town);
                }
                Console.WriteLine("-------------------------------------------------------------------------------");

                //SELECT 
                //    [Extent1].[DepartmentID] AS [DepartmentID], 
                //    [Extent1].[FirstName] AS [FirstName], 
                //    [Extent1].[LastName] AS [LastName], 
                //    [Extent2].[Name] AS [Name], 
                //    [Extent4].[Name] AS [Name1]
                //    FROM    [dbo].[Employees] AS [Extent1]
                //    INNER JOIN [dbo].[Departments] AS [Extent2] ON [Extent1].[DepartmentID] = [Extent2].[DepartmentID]
                //    INNER JOIN [dbo].[Addresses] AS [Extent3] ON [Extent1].[AddressID] = [Extent3].[AddressID]
                //    INNER JOIN [dbo].[Towns] AS [Extent4] ON [Extent3].[TownID] = [Extent4].[TownID]

                // Only one Query in SQL Server Profiler
                var allEmployeesInclude = dbContext.Employees.Include("Department").Include("Address.Town");

                foreach (var employee in allEmployeesInclude)
                {
                    Console.WriteLine("{0} {1} {2} {3}", employee.FirstName, employee.LastName, employee.Department.Name, employee.Address.Town.Name);
                }
                Console.WriteLine("-------------------------------------------------------------------------------");

                //SELECT 
                //    [Extent1].[EmployeeID] AS [EmployeeID], 
                //    [Extent1].[FirstName] AS [FirstName], 
                //    [Extent1].[LastName] AS [LastName], 
                //    [Extent1].[MiddleName] AS [MiddleName], 
                //    [Extent1].[JobTitle] AS [JobTitle], 
                //    [Extent1].[DepartmentID] AS [DepartmentID], 
                //    [Extent1].[ManagerID] AS [ManagerID], 
                //    [Extent1].[HireDate] AS [HireDate], 
                //    [Extent1].[Salary] AS [Salary], 
                //    [Extent1].[AddressID] AS [AddressID], 
                //    [Extent2].[DepartmentID] AS [DepartmentID1], 
                //    [Extent2].[Name] AS [Name], 
                //    [Extent2].[ManagerID] AS [ManagerID1], 
                //    [Extent3].[AddressID] AS [AddressID1], 
                //    [Extent3].[AddressText] AS [AddressText], 
                //    [Extent3].[TownID] AS [TownID], 
                //    [Extent4].[TownID] AS [TownID1], 
                //    [Extent4].[Name] AS [Name1]
                //    FROM    [dbo].[Employees] AS [Extent1]
                //    INNER JOIN [dbo].[Departments] AS [Extent2] ON [Extent1].[DepartmentID] = [Extent2].[DepartmentID]
                //    LEFT OUTER JOIN [dbo].[Addresses] AS [Extent3] ON [Extent1].[AddressID] = [Extent3].[AddressID]
                //    LEFT OUTER JOIN [dbo].[Towns] AS [Extent4] ON [Extent3].[TownID] = [Extent4].[TownID]

                
                // A Lot Of Queries in SQL Server Profiler - Please see Task1.sql
                var allEmployeesNotInclude = dbContext.Employees;
                foreach (var employee in allEmployeesNotInclude)
                {
                    Console.WriteLine("{0} {1} {2} {3}", employee.FirstName, employee.LastName, employee.Department.Name, employee.Address.Town.Name);
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
        }

        private static void GetAllEmployeesLinq()
        {
            TelerikAcademy dbContext = new TelerikAcademy();
            
            using (dbContext)
            {
                // A lot of Queries in SQL Server Profiler - Please see Task2.sql
                var allEmployees = dbContext.Employees
                                            .ToList()
                                            .Select(e => e.Address)
                                            .ToList()
                                            .Select(a => a.Town)
                                            .ToList()
                                            .Where(t => t.Name == "Sofia")
                                            .ToList();

                Console.WriteLine(allEmployees.Count());

                // Only one Query in SQL Server Profiler 
                var allEmployeesOptimized = dbContext.Employees
                                                     .Select(e => e.Address)
                                                     .Select(a => a.Town)
                                                     .Where(t => t.Name == "Sofia")
                                                     .ToList();

                Console.WriteLine(allEmployeesOptimized.Count());

                //SELECT 
                //    [Extent3].[TownID] AS [TownID], 
                //    [Extent3].[Name] AS [Name]
                //    FROM   [dbo].[Employees] AS [Extent1]
                //    LEFT OUTER JOIN [dbo].[Addresses] AS [Extent2] ON [Extent1].[AddressID] = [Extent2].[AddressID]
                //    INNER JOIN [dbo].[Towns] AS [Extent3] ON [Extent2].[TownID] = [Extent3].[TownID]
                //    WHERE N'Sofia' = [Extent3].[Name]
            }
        }
    }
}
