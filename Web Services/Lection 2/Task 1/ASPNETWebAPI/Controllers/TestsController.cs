namespace ASPNETWebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using ASPNETWebAPI.Models;

    public class TestsController : ApiController
    {
        private StudentSystemRepository<Test> testsRepo;

        public TestsController()
        {
            this.testsRepo = new StudentSystemRepository<Test>();
        }

        // GET api/tests
        public IQueryable<Test> Get()
        {
            return testsRepo.GetAll();
        }

        // GET api/tests/5
        public Test Get(int id)
        {
            return testsRepo.Get(id);
        }

        // POST api/tests
        public HttpResponseMessage Post(Test test)
        {
            testsRepo.Add(test);

            return Request.CreateResponse(HttpStatusCode.Created, test);
        }

        // PUT api/tests/5
        public IHttpActionResult Put(int id, Test test)
        {
            testsRepo.Update(id, test);

            return Ok(test);
        }

        // DELETE api/tests/5
        public IHttpActionResult Delete(int id)
        {
            var test = testsRepo.Delete(id);

            return Ok(test);
        }
    }
}
