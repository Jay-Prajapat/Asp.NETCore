using Practical17.Models;

namespace Practical17.Interface
{
    public interface IStudent
    {
        Student GetStudentById(int id);
        List<Student> GetAllStudents();
        void DeleteStudent(int id);
        void EditStudent(Student student);
        void AddStudent(Student student);
    }
}
