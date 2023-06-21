using Practical_18.Models;
using Practical_18.Service;
using Practical_18.ViewModels;

namespace Practical_18.Interface
{
    public interface IStudent
    {
        List<StudentViewModel> AddStudent(StudentViewModel student);
        List<StudentViewModel> EditStudent(StudentViewModel student);
        List<StudentViewModel> DeleteStudent(int id);
        List<StudentViewModel> GetAllStudent();
        StudentViewModel GetStudentById(int id);
    }
}
