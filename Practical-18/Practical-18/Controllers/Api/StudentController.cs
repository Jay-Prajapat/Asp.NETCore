using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Practical_18.Interface;
using Practical_18.Models;
using Practical_18.ViewModels;

namespace Practical_18.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent students;
        public StudentController(IStudent students)
        {
            this.students = students;
        }
        [HttpGet]
        public ActionResult<List<StudentViewModel>> GetAllStudents()
        {
            var result = students.GetAllStudent();
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<StudentViewModel> GetStudent(int id)
        {
            StudentViewModel student = students.GetStudentById(id);
            return student;
        }

        [HttpDelete("{id}")]
        public ActionResult<List<StudentViewModel>> DeleteStudent(int id)
        {
            var result = students.DeleteStudent(id);
            return result;
        }
        [HttpPost]
        public ActionResult<List<StudentViewModel>> AddStudent(StudentViewModel student)
        {
            var result = students.AddStudent(student);
            return result;
        }
        [HttpPut]
        public ActionResult<List<StudentViewModel>> UpdateStudent(StudentViewModel student)
        {
            var result = students.EditStudent(student);
            return result;
        }
    }
}
