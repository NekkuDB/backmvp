using UserApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User? GetById(int id) // Nota el "?" indicando que puede ser nulo
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void Add(User user)
        {
            user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
        }

        public void Update(User user)
        {
            var existingUser = GetById(user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Key = user.Key;
                existingUser.Is2FAEnabled = user.Is2FAEnabled;
                existingUser.Counter = user.Counter;
            }
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        public User? GetByUsername(string username) // Nota el "?" indicando que puede ser nulo
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }
    }
}
