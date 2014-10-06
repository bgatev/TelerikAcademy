namespace BugLoggerWebAPI.Tests.Mocks
{
    using System;
    using System.Collections.Generic;

    using BugLogger.Model;
    using BugLoggerWebAPI.Models;

    public abstract class BugsRepositoryMock
    {
        public BugsRepositoryMock()
        {
            this.PopulateFakeData();
            this.ArrangeBugsRepositoryMock();
        }

        public BugLoggerRepository<Bug> BugsData { get; protected set; }

        protected ICollection<Bug> FakeBugsCollection { get; private set; }

        private void PopulateFakeData()
        {
            this.FakeBugsCollection = new List<Bug>
            {
                new Bug { Text = "Problem 1", LogDate = DateTime.Now, Status_Id = 1 },
                new Bug { Text = "Problem 2", LogDate = DateTime.Now.AddDays(3), Status_Id = 2 },
                new Bug { Text = "Problem 3", LogDate = DateTime.Now.AddDays(-20), Status_Id = 3 },
                new Bug { Text = "Problem 4", LogDate = DateTime.Now.AddDays(111), Status_Id = 1 }
            };
        }

        protected abstract void ArrangeBugsRepositoryMock();
    }
}
