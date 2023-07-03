using Practical_20.Models;

namespace Practical_20.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student> GetStudentById(int studentId);
    }
}
