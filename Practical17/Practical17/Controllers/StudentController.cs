using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practical17.Interface;
using Practical17.Models;

namespace Practical17.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _students;
        public List<Student> students;
        public StudentController(IStudent student)
        {
            _students = student;
            students = _students.GetAllStudents();
        }
        public IActionResult Index()
        {
            return View(students.ToList());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Student student = _students.GetStudentById(id);
            return View(student);
        }
        [HttpGet]
        [Authorize(Roles ="Admin,User")]
        public IActionResult Edit(int id)
        {
            Student student = _students.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        [Authorize(Roles ="Admin,User")]
        public IActionResult Edit(Student student)
        {
            if(ModelState.IsValid)
            {
                _students.EditStudent(student);
                return RedirectToAction("Index");
            }
            
            return View(student);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _students.DeleteStudent(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _students.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
