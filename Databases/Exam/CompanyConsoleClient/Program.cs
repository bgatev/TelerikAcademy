namespace CompanyConsoleClient
{
    using System;
    using System.Linq;
    using System.Data.Linq;
    using System.Transactions;

    using CompanyData;

    public class Program
    {
        private static Company db;

        /*private static void InsertRecords()
        {
            var random = RandomGenerator.Instance;

            using (db)
            {
                for (int i = 0; i < 101; i++)
                {
                    var currentCardAccount = new CardAccount();

                    currentCardAccount.CardNum = random.GetRandomStringNumber(10);
                    currentCardAccount.CardPin = random.GetRandomStringNumber(4);
                    currentCardAccount.CardCash = random.GetRandomNumber(100, 1000);

                    db.CardAccounts.Add(currentCardAccount);

                    if (i % 10 == 0) db.SaveChanges();
                }
            }    
        }

        private static void WithdrawMoney(CardAccount account, int amount)
        {
            using(db)
            {
                var tranOptions = new TransactionOptions();
                tranOptions.IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead;
                TransactionScope currentTransaction = new TransactionScope(TransactionScopeOption.Required, tranOptions);

                using(currentTransaction)
                {
                    if (IsCardNumberValid(account.CardNum) && IsCardPinValid(account.CardPin) && account.CardCash >= amount)
                    {
                        account.CardCash -= amount;

                        var currentHistory = new TransactionsHistory();
                        currentHistory.CardNumber = account.CardNum;
                        currentHistory.TransactionDate = DateTime.Now;
                        currentHistory.Ammount = account.CardCash;

                        db.TransactionsHistories.Add(currentHistory);
                        db.SaveChanges();
                        currentTransaction.Complete();
                    }
                    else currentTransaction.Dispose();
                }
            }
        }*/

        private static void InsertDepartments()
        {
            var random = RandomGenerator.Instance;

            using (db)
            {
                for (int i = 0; i < 101; i++)
                {
                    var currentDepartment = new Department();

                    currentDepartment.Name = random.GetRandomStringWithRandomLength(10, 50);

                    db.Departments.Add(currentDepartment);

                    if (i % 10 == 0) db.SaveChanges();
                }
            }    
        }

        private static void InsertEmployees()
        {
            var random = RandomGenerator.Instance;

            using (db)
            {
                for (int i = 0; i < 5001; i++)
                {
                    var currentEmployee = new Employee();

                    currentEmployee.FirstName = random.GetRandomStringWithRandomLength(5, 20);
                    currentEmployee.LastName = random.GetRandomStringWithRandomLength(5, 20);
                    if (i < 4750) //95%
                    {
                        currentEmployee.YearSalary = random.GetRandomNumber(50000, 200000);
                        currentEmployee.ManagerID = random.GetRandomNumber(1, 5000);
                    }
                    else
                    {
                        currentEmployee.YearSalary = random.GetRandomNumber(10000, 48000);
                    }

                    currentEmployee.DepartmentID = random.GetRandomNumber(1, 100);
                    
                    db.Employees.Add(currentEmployee);

                    if (i % 100 == 0) db.SaveChanges();
                }
            }
        }

        private static void InsertProjects()
        {
            var random = RandomGenerator.Instance;

            using (db)
            {
                for (int i = 0; i < 1001; i++)
                {
                    var currentProject = new Project();

                    currentProject.Id = i + 1;
                    currentProject.Name = random.GetRandomStringWithRandomLength(5, 50);
                    db.Projects.Add(currentProject);

                    var currentEmployeesProject = new EmployeesProject();
                    currentEmployeesProject.EmployeeID = random.GetRandomNumber(1, 5000);
                    currentEmployeesProject.ProjectID = currentProject.Id;

                    var randomStartDate = new DateTime(random.GetRandomNumber(2000, 2014), 
                                                       random.GetRandomNumber(1, 12),
                                                       random.GetRandomNumber(1, 28));

                    var randomEndDate = new DateTime(random.GetRandomNumber(2015, 2020), 
                                                       random.GetRandomNumber(1, 12),
                                                       random.GetRandomNumber(1, 28));

                    currentEmployeesProject.StartDate = randomStartDate;
                    currentEmployeesProject.EndDate = randomEndDate;

                    db.EmployeesProjects.Add(currentEmployeesProject);

                    if (i % 50 == 0) db.SaveChanges();
                }
            }
        }

        private static void InsertReports()
        {
            var random = RandomGenerator.Instance;

            using (db)
            {
                for (int i = 0; i < 250001; i++)
                {
                    var currentReport = new Report();

                    currentReport.EmployeeID = i % 5000 + 5;

                    var randomDate = new DateTime(random.GetRandomNumber(2010, 2020),
                                                       random.GetRandomNumber(1, 12),
                                                       random.GetRandomNumber(1, 28));
                    currentReport.CreationTime = randomDate;

                    db.Reports.Add(currentReport);

                    if (i % 100 == 0)
                    {
                        Console.Write(".");
                        db.SaveChanges();
                    }
                }
            }
        }
        public static void Main()
        {
            db = new Company();

            //InsertDepartments();
            //InsertEmployees();
            //InsertProjects();
            InsertReports();
        }
    } 
}
