using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ProteinTrackerWebAppService
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> users = new List<User>();
        private static int nextId = 0;
        public void Add(User user)
        {
            user.Id = nextId;
            nextId++;
            users.Add(user);
        }

        public ReadOnlyCollection<User> GetAllUsers()
        {
            return users.AsReadOnly();
        }

        public User GetUserById(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return null;
            return user;
        }

        public void Save(User updatedUser)
        {
            var originalUser = users.SingleOrDefault(u => u.Id == updatedUser.Id);
            if (originalUser == null)
                return;
            originalUser.Name = updatedUser.Name;
            originalUser.Total = updatedUser.Total;
            originalUser.Goal = updatedUser.Goal;
        }
    }
}