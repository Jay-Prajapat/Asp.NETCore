using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Practical17.Models
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext>options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student() { StudentId = 1, Name = "Jay", Standard = 11, Age = 16 }
            );
            modelBuilder.Entity<Role>().HasData(
               new Role() { RoleId = 1, RoleName = "Admin" }
           );

            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 1, FirstName = "Jay", LastName = "Prajapati", Email = "jay@gmail.com", Password = "Jay@123", MobileNumber = "9858965474", RoleId = 1 }
            );

           
        }
    }
}
