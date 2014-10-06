namespace BugLoggerWebAPI.Tests.Integration
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;
    using System.Collections.Generic;
    using System.Net;
    using BugLogger.Model;
    using BugLoggerWebAPI.Models;

    [TestClass]
    public class StudentControllerIntTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void GetAll_WhenOneBug_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockRepository = Mock.Create<BugLoggerRepository<Bug>>();
            var allBugs = new List<Bug>();
            allBugs.Add(new Bug(){ Text = "Test Bug" });

            //Mock.Arrange(() => mockRepository.All())
            // .Returns(() => models.AsQueryable());
            var server = new InMemoryHttpServer<Bug>("http://localhost/", mockRepository);
            var response = server.CreateGetRequest("api/bugs");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
    }
}
