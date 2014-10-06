namespace BugLoggerWebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using BugLogger.Data;
    using BugLogger.Model;
    using BugLoggerWebAPI.Models;

    public class BugsController : ApiController
    {
        private BugLoggerRepository<Bug> bugsRepo;

        public BugsController()
            : this(new BugLoggerRepository<Bug>())
        {
        }

        public BugsController(BugLoggerRepository<Bug> bugsRepository)
        {
            this.bugsRepo = bugsRepository;
        }

        // POST api/bugs
        public HttpResponseMessage Post(Bug bug)
        {
            if (bug.Status_Id == 0) bug.Status_Id = 1;

            bugsRepo.Add(bug);

            return Request.CreateResponse(HttpStatusCode.Created, bug);
        }

        // GET api/bugs
        public IQueryable<Bug> Get()
        {
            return bugsRepo.GetAll();
        }

        // GET After api/bugs?date=22-06-2014
        [HttpGet]
        public IQueryable<Bug> GetBugsByDate(string date)
        {
            var currentDate = DateTime.Parse(date);

            return bugsRepo.Get(b => b.LogDate > currentDate);
        }

        // GET by Status api/bugs?state=pending
        [HttpGet]
        public IQueryable<Bug> GetBugsByStatus(string state)
        {
            return bugsRepo.Get(b => b.Status.State == state);
        }       

        // PUT api/bugs/5
        public IHttpActionResult Put(int id, Bug newBug)
        {
            Bug bug = bugsRepo.Get(id);
            bug.Status_Id = newBug.Status_Id;

            bugsRepo.Update(id, bug);

            return Ok(bug);
        }
    }
}
