using Practical_20.Interfaces;
using Practical_20.Models;

namespace Practical_20.Services
{
    public class StudentService : IStudentService
    {
        public IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task AddStudent(Student students)
        {
            var student = new Student
            {
                Email = students.Email,
                StudentName = students.StudentName,
                PhoneNumber = students.PhoneNumber,
            };

            _unitOfWork.StudentRepository.Add(students);
            await _unitOfWork.CommitAsync();
        }


        public async Task<IEnumerable<Student>> GetAll()
            => await _unitOfWork.StudentRepository.GetAll();
    }
}
