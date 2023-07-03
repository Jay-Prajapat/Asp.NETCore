using Microsoft.EntityFrameworkCore;

using Practical_20.Interfaces;
using Practical_20.Models;

namespace Practical_20.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public StudentRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await _dbContext.Students.FindAsync(id);
           
        }
    }
}
