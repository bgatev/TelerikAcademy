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

    public class HomeworksController : ApiController
    {
        private StudentSystemRepository<Homework> homeworkRepo;

        public HomeworksController()
        {
            this.homeworkRepo = new StudentSystemRepository<Homework>();
        }

        // GET api/homeworks
        public IQueryable<Homework> Get()
        {
            return homeworkRepo.GetAll();
        }

        // GET api/homeworks/5
        public Homework Get(int id)
        {
            return homeworkRepo.Get(id);
        }

        // POST api/homeworks
        public HttpResponseMessage Post(Homework homework)
        {
            homeworkRepo.Add(homework);

            return Request.CreateResponse(HttpStatusCode.Created, homework);
        }

        // PUT api/homeworks/5
        public IHttpActionResult Put(int id, Homework homework)
        {
            homeworkRepo.Update(id, homework);

            return Ok(homework);
        }

        // DELETE api/homeworks/5
        public IHttpActionResult Delete(int id)
        {
            var homework = homeworkRepo.Delete(id);

            return Ok(homework);
        }
    }
}
