using StudentService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentService.Controllers
{
    public class StudentController : ApiController
    {
        StudentEntities entities = new StudentEntities();
        //public IEnumerable<StudentInfo> Get()
        //{
        //    return entities.StudentInfoes.ToList();
        //}
        //[HttpGet]
        //public IEnumerable<StudentInfo> AllStudents()
        //{
        //    return entities.StudentInfoes.ToList();
        //}
        [HttpGet]
        public HttpResponseMessage AllStudents(string gender="all")
        {
            switch (gender.ToLower())
            {
                case "all":
                    return Request.CreateResponse(HttpStatusCode.OK, entities.StudentInfoes.ToList());
                case "male":
                    return Request.CreateResponse(HttpStatusCode.OK, entities.StudentInfoes.Where(s => s.Gender.ToLower() == "male").ToList());
                case "female":
                    return Request.CreateResponse(HttpStatusCode.OK, entities.StudentInfoes.Where(s => s.Gender.ToLower() == "female").ToList());
                default:
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Value for gender must be all, male or female. " + gender +" is invalid.");
            }
        }
        //public HttpResponseMessage Get(int id)
        //{
        //    var entity = entities.StudentInfoes.FirstOrDefault(s => s.Id == id);
        //    if (entity != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, entity);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with Id = " + id.ToString() + " not found.");
        //    }
        //}
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var entity = entities.StudentInfoes.FirstOrDefault(s => s.Id == id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with Id = " + id.ToString() + " not found.");
            }
        }
        //public HttpResponseMessage Post([FromBody] StudentInfo studentInfo)
        //{
        //    try
        //    {
        //        entities.StudentInfoes.Add(studentInfo);
        //        entities.SaveChanges();
        //        var message = Request.CreateResponse(HttpStatusCode.Created, studentInfo);
        //        message.Headers.Location = new Uri(Request.RequestUri + studentInfo.Id.ToString());
        //        return message;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}
        [HttpPost]
        public HttpResponseMessage CreateStudent([FromBody] StudentInfo studentInfo)
        {
            try
            {
                entities.StudentInfoes.Add(studentInfo);
                entities.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, studentInfo);
                message.Headers.Location = new Uri(Request.RequestUri + studentInfo.Id.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var entity = entities.StudentInfoes.FirstOrDefault(s => s.Id == id);
                if (entity != null)
                {
                    entities.StudentInfoes.Remove(entity);
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Student with Id = " + id.ToString() + " is deleted successfully.");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with Id = " + id.ToString() + " not found to delete.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Put([FromBody]int id, [FromUri] StudentInfo studentInfo)
        {
            try
            {
                var entity = entities.StudentInfoes.FirstOrDefault(s => s.Id == id);
                if (entity != null)
                {
                    entity.FirstName = studentInfo.FirstName;
                    entity.LastName = studentInfo.LastName;
                    entity.Gender = studentInfo.Gender;
                    entity.Class = studentInfo.Class;
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.OK, studentInfo);
                    message.Headers.Location = new Uri(Request.RequestUri + studentInfo.Id.ToString());
                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with Id = " + id.ToString() + " not found to update.");
                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
