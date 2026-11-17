using PatientManagementSystem.Models;
using System.Collections.Generic;

namespace PatientManagementSystem.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new List<User>();

        private int nextId = 1;

        public User GetByUsername(string username)
        {
            return users.Find(u => u.Username == username);
        }

        public User GetByMobile(string mobile)
        {
            return users.Find(u => u.Mobile == mobile);
        }

        public bool Add(User user)
        {
            if (GetByUsername(user.Username) != null)
                return false;

            if (GetByMobile(user.Mobile) != null)
                return false;

            user.Id = nextId++;

            users.Add(user);

            return true;
        }

        public bool UpdatePassword(string mobile, string passwordHash)
        {
            User user = GetByMobile(mobile);

            if (user == null)
                return false;

            user.PasswordHash = passwordHash;

            return true;
        }
    }
}