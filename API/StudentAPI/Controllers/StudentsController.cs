using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLL;
using BOL;

namespace StudentAPI.Controllers
{
    [RoutePrefix("api/students")]
    [Route("GetStudents")]
    public class StudentsController : ApiController
    {
        private StudentBS objdb;
        public StudentsController()
        {
            objdb = new StudentBS();
        }
        [Route("GetStudents")]
        public IEnumerable<Student> GetStudents()
        {
            return objdb.GetAllStudents();
        }
        [ResponseType(typeof(Student))]
        [Route("GetStudentById/{id}")]
        public IHttpActionResult GetStudentById(int id)
        {
            Student student = objdb.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [ResponseType(typeof(Student))]
        [Route("GetStudentByContact/{contact}")]
        public IHttpActionResult GetStudentByContact(string contact)
        {
            Student student = objdb.GetStudentByContact(contact);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [ResponseType(typeof(Student))]
        [Route("GetStudentByRoll/{id}")]
        public IHttpActionResult GetStudentByRoll(int roll)
        {
            Student student = objdb.GetStudentByRoll(roll);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        // PUT api/CRUD/5  
        [ResponseType(typeof(Student))]
        //[Route("api/PutStudent/{id}")]
        public IHttpActionResult PutStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (student==null)
            {
                return BadRequest();
            }            
            if(objdb.Update(student))
                {
                    return Ok(student);
                }
            else
            {
                NotFound();
            }
            return Ok();
            
        }
        // POST api/CRUD  
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(objdb.Insert(student))
            {
                return Ok();
            }
            return BadRequest();
            
        }
        // DELETE api/CRUD/5  
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {           
            if (objdb.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }        
    }
}
