using Practical17.Interface;
using Practical17.Models;
using System.Security.Cryptography.X509Certificates;

namespace Practical17.Repository
{
    public class StudentRepo : IStudent
    {
        private readonly StudentDBContext _context;
        public StudentRepo(StudentDBContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student); 
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            Student student = _context.Students.Single(s => s.StudentId == id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        
        public void EditStudent(Student student)
        {
            Student updateStudent = _context.Students.Single(s => s.StudentId == student.StudentId);
            updateStudent.Name = student.Name;
            updateStudent.Standard = student.Standard;
            updateStudent.Age = student.Age;
            _context.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Single(s => s.StudentId == id);    
        }
    }
}
