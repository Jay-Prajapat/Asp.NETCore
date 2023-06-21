using Microsoft.EntityFrameworkCore;
using Practical17.Interface;
using Practical17.Models;

namespace Practical17.Repository
{
    public class UsersRepo : IUser
    {
        private readonly StudentDBContext _users;
        public UsersRepo(StudentDBContext users)
        {
            _users = users;
        }

        public List<User> GetAllUsers()
        {
            return _users.Users.Include(r => r.Roles).ToList();
        }

        
    }
}
