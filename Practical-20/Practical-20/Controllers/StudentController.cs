using Microsoft.AspNetCore.Mvc;
using Practical_20.Interfaces;
using Practical_20.Models;

namespace Practical_20.Controllers
{
    public class StudentController : Controller
    {
        public readonly ILogger<StudentController> _logger;
        public IStudentService _studentService { get; set; }
        
        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
        } 

        
        public async Task<IActionResult> GetAllStudents()
        {
            throw new Exception("Global Exception Testing");
            IEnumerable<Student> students =  await _studentService.GetAll();
            return View(students);
        }

        public ActionResult AddStudent()
        {
            return View();     
        }


        [HttpPost]
        public async Task<IActionResult> AddStudent(Student students)
        {
            if (ModelState.IsValid)
            {
                await _studentService.AddStudent(students);
                return RedirectToAction("GetAllStudents");
            }
           return View();
        }
    }
}
