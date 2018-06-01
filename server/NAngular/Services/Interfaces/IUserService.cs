using NAngular.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAngular.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllApplicationUsers();

        User GetUserDetails(string Email);

        User GetUserDetails(int UserId);

        int InsertUpdatetUser(User user);

        List<Role> GetAllRoles();
    }
}
