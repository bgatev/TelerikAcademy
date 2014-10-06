namespace BugLoggerWebAPI.Tests.Integration
{
    using BugLogger.Data;
    using BugLogger.Model;
    using BugLoggerWebAPI.Controllers;
    using BugLoggerWebAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http.Dependencies;

    public class TestPlacesDependencyResolver<T> : IDependencyResolver
    {
        private BugLoggerDbContext bugsContext = new BugLoggerDbContext();
        private BugLoggerRepository<Bug> bugsRepo = new BugLoggerRepository<Bug>();

        public BugLoggerRepository<Bug> BugsRepo
        {
            get
            {
                return this.bugsRepo;
            }
            set
            {
                this.bugsRepo = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(BugsController)) return new BugsController();
            else return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}
