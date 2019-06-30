using System.Collections.Generic;
using System.Linq;
using Baseball.Models;

namespace Baseball.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string username);
        void AddUser(User user);
        List<User> GetUsers();
    }

    public class UserRepository : IUserRepository
    {
        private readonly BaseballContext _db;

        public UserRepository(BaseballContext db)
        {
            _db = db;
        }

        public User GetUser(string username)
        {
            return _db.Users.SingleOrDefault(user => user.Username == username);
        }

        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return _db.Users.ToList();
        }
    }
}
