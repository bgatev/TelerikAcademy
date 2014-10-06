namespace BugLoggerWebAPI.Tests.Mocks
{
    using System.Linq;
    using Telerik.JustMock;

    using BugLogger.Model;
    using BugLoggerWebAPI.Models;

    public class JustMockBugsRepository : BugsRepositoryMock
    {
        protected override void ArrangeBugsRepositoryMock()
        {
            this.BugsData = Mock.Create<BugLoggerRepository<Bug>>();
            Mock.Arrange(() => this.BugsData.Add(Arg.IsAny<Bug>())).DoNothing();
            Mock.Arrange(() => this.BugsData.GetAll()).ReturnsCollection(this.FakeBugsCollection);
            Mock.Arrange(() => this.BugsData.Get(Arg.AnyInt)).Returns(this.FakeBugsCollection.First());
            Mock.Arrange(() => this.BugsData.Get(-1)).Throws(new System.ArgumentOutOfRangeException("Invalid ID"));
            Mock.Arrange(() => this.BugsData.Update(Arg.AnyInt, Arg.IsAny<Bug>())).DoNothing();
            Mock.Arrange(() => this.BugsData.Delete(Arg.AnyInt)).Returns(this.FakeBugsCollection.First());
            Mock.Arrange(() => this.BugsData.Delete(-1)).Throws(new System.ArgumentOutOfRangeException("Invalid ID"));
            Mock.Arrange(() => this.BugsData.Delete(Arg.IsAny<Bug>())).Returns(this.FakeBugsCollection.Last());
        }
    }

}
