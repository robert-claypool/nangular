using System.Collections.Generic;
using NAngular.DataAccess.Repositories.Interfaces;
using NAngular.Domain.Models;
using NAngular.Services.Interfaces;
using Unity.Attributes;

namespace NAngular.Services
{
    public class UserService : IUserService
    {
        [Dependency] public IUserRepository UserRepository { get; set; }

        public List<User> GetAllApplicationUsers()
        {
            return UserRepository.GetAllApplicationUsers();
        }

        public List<Role> GetAllRoles()
        {
            return UserRepository.GetAllRoles();
        }

        public User GetUserDetails(string email)
        {
            return UserRepository.GetUserDetails(email);
        }

        public User GetUserDetails(int userId)
        {
            return UserRepository.GetUserDetails(userId);
        }

        public int InsertUpdatetUser(User user)
        {
            return UserRepository.InsertUpdatetUser(user);
        }
    }
}
