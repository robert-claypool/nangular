using System.Collections.Generic;
using NAngular.Domain.Models;

namespace NAngular.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllApplicationUsers();

        User GetUserDetails(string email);

        User GetUserDetails(int userId);

        int InsertUpdatetUser(User user);

        List<Role> GetAllRoles();
    }
}
