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

    public class CoursesController : ApiController
    {
        private StudentSystemRepository<Course> courseRepo;

        public CoursesController()
        {
            this.courseRepo = new StudentSystemRepository<Course>();
        }

        // GET api/courses
        public IQueryable<Course> Get()
        {
            return courseRepo.GetAll();
        }

        // GET api/courses/5
        public Course Get(int id)
        {
            return courseRepo.Get(id);
        }

        // POST api/courses
        public HttpResponseMessage Post(Course course)
        {
            courseRepo.Add(course);

            return Request.CreateResponse(HttpStatusCode.Created, course);
        }

        // PUT api/courses/5
        public IHttpActionResult Put(int id, Course course)
        {
            courseRepo.Update(id, course);

            return Ok(course);
        }

        // DELETE api/courses/5
        public IHttpActionResult Delete(int id)
        {
            var course = courseRepo.Delete(id);

            return Ok(course);
        }
    }
}
