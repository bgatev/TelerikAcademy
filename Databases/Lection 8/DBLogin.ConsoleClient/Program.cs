namespace DBLogin.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Data.Linq;

    using System.Transactions;

    using DBLogin.Data;
    public class Program
    {
        public static void AddUser(string username, string password)
        {
            DBLogin dbContext = new DBLogin();

            using (dbContext)
            {
                TransactionScope currentTransaction = new TransactionScope();

                using (currentTransaction)
                {
                    if (dbContext.Groups.Count(g => g.Name == "Admins") == 0)
                    {
                        Group adminsGroup = new Group() { Name = "Admins" };

                        dbContext.Groups.Add(adminsGroup);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        if (dbContext.Users.Count(u => u.Username == username) > 0)
                        {
                            Console.WriteLine("User already exists.");
                            currentTransaction.Dispose();
                            
                            return;
                        }
                    }

                    Group currentgroup = dbContext.Groups.Where(g => g.Name == "Admins").First();

                    User currentUser = new User()
                                        {
                                            Username = username,
                                            Password = password,
                                            GroupID = currentgroup.id
                                        };

                    dbContext.Users.Add(currentUser);
                    dbContext.SaveChanges();
                    currentTransaction.Complete();
                }
            }
        }

        public static void Main()
        {
            AddUser("ivan", "ivanov"); 
        }
    }
}
