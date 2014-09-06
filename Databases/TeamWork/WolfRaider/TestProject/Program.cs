using System;
using System.Linq;
using WolfRaider.Common.Models;
using WolfRaider.DatabaseAccess.Connections;
using WolfRaider.DatabaseAccess.SqlServer;

namespace TestProject
{
    public static class Program
    {
        static void Main()
        {
            Employee employee = new Employee(new Guid("BD2E161F-38DB-49DC-A36E-21AE39A52F75"), "Pavel", "Hristov", 36, null);

            //  employee.Age = 21;
            var dao = new EmployeeDaoSqlServer();


            var result = dao.Find(x => !x.ManagerId.HasValue);
            Console.WriteLine(result.Count());

            foreach (var item in result)
            {
                Console.WriteLine(item.EmployeeId + " " + item.FullName );
            }


        }
    }
}
