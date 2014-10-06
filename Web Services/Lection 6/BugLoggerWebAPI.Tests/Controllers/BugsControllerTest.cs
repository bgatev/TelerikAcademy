namespace BugLoggerWebAPI.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BugLoggerWebAPI;
    using BugLoggerWebAPI.Controllers;
    using System.Net.Http.Formatting;
    using System.IO;
    using BugLogger.Model;
    using BugLoggerWebAPI.Tests.Mocks;
    using BugLoggerWebAPI.Models;
    using System.Web.Mvc;

    [TestClass]
    public class BugsControllerTestOld
    {
        public void TestSerialization()
        {
            var value = new Bug() { Text = "Alice", LogDate = DateTime.Now};

            var xml = new XmlMediaTypeFormatter();
            string str = Serialize(xml, value);

            var json = new JsonMediaTypeFormatter();
            str = Serialize(json, value);

            // Round trip
            Bug bug2 = Deserialize<Bug>(json, str);
        }

        private string Serialize<T>(MediaTypeFormatter formatter, T value)
        {
            // Create a dummy HTTP Content.
            Stream stream = new MemoryStream();
            var content = new StreamContent(stream);
            /// Serialize the object.
            formatter.WriteToStreamAsync(typeof(T), value, stream, content, null).Wait();
            // Read the serialized string.
            stream.Position = 0;
            return content.ReadAsStringAsync().Result;
        }

        private T Deserialize<T>(MediaTypeFormatter formatter, string str) where T : class
        {
            // Write the serialized string to a memory stream.
            Stream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            // Deserialize to an object of type T
            return formatter.ReadFromStreamAsync(typeof(T), stream, null, null).Result as T;
        }
    }

    [TestClass]
    public class BugsControllerTest
    {
        private BugLoggerRepository<Bug> bugsData;
        private BugsController controller;

        public BugsControllerTest()
            : this(new JustMockBugsRepository())
        {
        }

        public BugsControllerTest(BugsRepositoryMock bugsDataMock)
        {
            this.bugsData = bugsDataMock.BugsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new BugsController(this.bugsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllBugs()
        {
            var allBugs = this.controller.Get();

            Assert.AreEqual(4, allBugs.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingBugShouldThrowArgumentNullExceptionIfBugIsNull()
        {
            var bug = this.controller.Post(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingBugShouldThrowArgumentNullExceptionIfBugTextIsNull()
        {
            var bug = new Bug
            {
                LogDate = DateTime.Now,
                Status_Id = 1
            };

            var result = this.controller.Post(bug);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingBugShouldThrowArgumentNullExceptionIfBugLogDateIsNull()
        {
            var bug = new Bug
            {
                Text = "Problematika",
                Status_Id = 1
            };

            var result = this.controller.Post(bug);
        }

        [TestMethod]
        public void AddingBugShouldReturnAStatusCode()
        {
            var bug = new Bug
            {
                Text = "Problematika",
                LogDate = DateTime.Now,
                Status_Id = 1
            };

            var result = this.controller.Post(bug);

            Assert.AreEqual(true, result.IsSuccessStatusCode);
        }

        [TestMethod]
        public void SearchingCarsShouldReturnListOfCars()
        {
            var allBugs = this.controller.GetBugsByStatus("pending").First();

            Assert.AreEqual(1, allBugs.Status_Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SearchingBugsShouldThrowArgumentNullExceptionIfParameterIsNull()
        {
            this.controller.GetBugsByStatus(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SearchingBugsShouldThrowArgumentNullExceptionIfParameterIsEmpty()
        {
            this.controller.GetBugsByStatus("");
        }
    }
}
