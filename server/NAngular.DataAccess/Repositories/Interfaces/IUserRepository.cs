using System.Collections.Generic;
using NAngular.Domain.Models;

namespace NAngular.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllApplicationUsers();

        User GetUserDetails(string email);

        User GetUserDetails(int userId);

        int InsertUpdatetUser(User user);

        List<Role> GetAllRoles();
    }
}
