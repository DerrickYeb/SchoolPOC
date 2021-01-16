using SchoolAPI.DataAccess.IRepositories;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SchoolAPI.Controllers
{
    
    public class StudentsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetStudents()
        {
            var students = await _unitOfWork.Student.GetAllStudentsAsync(trackChanges: false);
            return Ok(students);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetStudent(Guid id)
        {
            var student = await _unitOfWork.Student.GetStudentAsync(id, trackChanges: false);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IHttpActionResult> CreateStudent([FromBody]Student student)
        {
             _unitOfWork.Student.CreateStudent(student);
            await _unitOfWork.Save();

            return CreatedAtRoute("studentId", new { id = student.Id },student);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteStudent(Guid id)
        {
            var student = await _unitOfWork.Student.GetStudentAsync(id, trackChanges: true);
            if (student == null)
            {
                return NotFound();
            }
            _unitOfWork.Student.DeleteStudent(student);
            await _unitOfWork.Save();

            return StatusCode(HttpStatusCode.NotFound);

        }
    }
}
