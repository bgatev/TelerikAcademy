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

    public class StudentInfoController : ApiController
    {
        private StudentSystemRepository<StudentInfo> studentInfoRepo;

        public StudentInfoController()
        {
            this.studentInfoRepo = new StudentSystemRepository<StudentInfo>();
        }

        // GET api/studentinfo
        public IQueryable<StudentInfo> Get()
        {
            return studentInfoRepo.GetAll();
        }

        // GET api/studentinfo/5
        public StudentInfo Get(int id)
        {
            return studentInfoRepo.Get(id);
        }

        // POST api/studentinfo
        public HttpResponseMessage Post(StudentInfo studentinfo)
        {
            studentInfoRepo.Add(studentinfo);

            return Request.CreateResponse(HttpStatusCode.Created, studentinfo);
        }

        // PUT api/studentinfo/5
        public IHttpActionResult Put(int id, StudentInfo studentinfo)
        {
            studentInfoRepo.Update(id, studentinfo);

            return Ok(studentinfo);
        }

        // DELETE api/studentinfo/5
        public IHttpActionResult Delete(int id)
        {
            var studentinfo = studentInfoRepo.Delete(id);

            return Ok(studentinfo);
        }
    }
}
