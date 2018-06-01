using NAngular.DataAccess.Repositories.Interfaces;
using NAngular.Domain.Models;
using NAngular.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity.Attributes;

namespace NAngular.Services
{
    public class UserService : IUserService
    {
        [Dependency]
        public IUserRepository UserRepository { get; set; }

        public List<User> GetAllApplicationUsers()
        {
            return UserRepository.GetAllApplicationUsers();
        }

        public List<Role> GetAllRoles()
        {
            return UserRepository.GetAllRoles();
        }

        public User GetUserDetails(string Email)
        {
            return UserRepository.GetUserDetails(Email);
        }

        public User GetUserDetails(int UserId)
        {
            return UserRepository.GetUserDetails(UserId);
        }

        public int InsertUpdatetUser(User user)
        {
            return UserRepository.InsertUpdatetUser(user);
        }
    }
}
