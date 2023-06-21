using Microsoft.EntityFrameworkCore;

namespace Practical_18.Models
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> option) : base(option)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
