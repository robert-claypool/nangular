using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAngular.Domain.Models;

namespace NAngular.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllApplicationUsers();

        User GetUserDetails(string Email);

        User GetUserDetails(int UserId);

        int InsertUpdatetUser(User user);

        List<Role> GetAllRoles();
    }
}
