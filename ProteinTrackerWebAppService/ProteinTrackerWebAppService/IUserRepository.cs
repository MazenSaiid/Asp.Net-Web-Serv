using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinTrackerWebAppService
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetUserById(int id);
        ReadOnlyCollection<User> GetAllUsers();
        void Save(User updatedUser);
    }
}
