using AutoMapper;
using Practical_18.Interface;
using Practical_18.Models;
using Practical_18.ViewModels;

namespace Practical_18.Service
{
    public class StudentService : IStudent
    {
        private readonly StudentDBContext _context;
        private readonly IMapper mapper;

        public StudentService(StudentDBContext context,IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public List<StudentViewModel> AddStudent(StudentViewModel student)
        {
            var result = mapper.Map<StudentViewModel, Student>(student);
            _context.Students.Add(result); 
            _context.SaveChanges();
            var studentList = _context.Students.ToList();
            var studentViewModelList = mapper.Map<List<Student>, List<StudentViewModel>>(studentList);
            return studentViewModelList;
        }

        public List<StudentViewModel> DeleteStudent(int id)
        {
            Student student =  _context.Students.Single(s => s.Id == id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            var studentList = _context.Students.ToList();
            var studentViewModelList = mapper.Map<List<Student>, List<StudentViewModel>>(studentList);

            return studentViewModelList;
        }

        public List<StudentViewModel> EditStudent(StudentViewModel student)
        {
            var result = mapper.Map<StudentViewModel, Student>(student);

            Student updateStudent = _context.Students.Single(s => s.Id == student.Id);  
            updateStudent.Name = student.Name;
            updateStudent.Standard =student.Standard;
            updateStudent.MobileNumber = student.MobileNumber;
            _context.SaveChanges();
            var studentList = _context.Students.ToList();

            var studentViewModelList = mapper.Map<List<Student>, List<StudentViewModel>>(studentList);

            return studentViewModelList;
        }

        public List<StudentViewModel> GetAllStudent()
        {
            var studentList = _context.Students.ToList();

            var studentViewModelList = mapper.Map<List<Student>, List<StudentViewModel>>(studentList);

            return studentViewModelList;
        }

        public StudentViewModel GetStudentById(int id)
        {
            Student student = _context.Students.Single(s => s.Id==id);
            var studentViewModelList = mapper.Map<Student, StudentViewModel>(student);

            return studentViewModelList;
        }
    }
}
