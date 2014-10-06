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
    
    public class StudentsController : ApiController
    {
        private StudentSystemRepository<Student> studentRepo;

        public StudentsController()
        {
            this.studentRepo = new StudentSystemRepository<Student>();
        }

        // GET api/students
        public IQueryable<Student> Get()
        {
            return studentRepo.GetAll();
        }

        // GET api/students/5
        public Student Get(int id)
        {
            return studentRepo.Get(id);
        }

        // POST api/students
        public HttpResponseMessage Post(Student student)
        {
            studentRepo.Add(student);

            return Request.CreateResponse(HttpStatusCode.Created, student);
        }

        // PUT api/students/5
        public IHttpActionResult Put(int id, Student student)
        {
            studentRepo.Update(id, student);

            return Ok(student);
        }

        // DELETE api/students/5
        public IHttpActionResult Delete(int id)
        {
            var student = studentRepo.Delete(id);

            return Ok(student);
        }
    }
}
