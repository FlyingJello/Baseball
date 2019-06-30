using System.Collections.Generic;
using System.Linq;
using Baseball.Models;
using Baseball.Repositories;

namespace Baseball.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User Create(User user, string password);
        List<User> GetAllUsers();
        User GetUserByUsername(string username);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = _userRepository.GetUser(username);

            if (user == null)
            {
                return null;
            }

            return VerifyPassword(user, password);
        }

        public User Create(User user, string password)
        {
            var existingUser = _userRepository.GetUser(user.Username);

            if (existingUser != null)
            {
                return null;
            }

            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _userRepository.AddUser(user);

            return user;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetUsers();
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUser(username);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private User VerifyPassword(User user, string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                if (computedHash.Where((t, i) => t != user.PasswordHash[i]).Any())
                {
                    return null;
                }
            }

            return user;
        }
    }
}
