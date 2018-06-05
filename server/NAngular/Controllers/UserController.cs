using System.Collections.Generic;
using System.Web.Http;
using NAngular.Domain.Models;
using NAngular.Services.Interfaces;
using Unity.Attributes;

namespace NAngular.Controllers
{
    public class UserController : ApiController
    {
        [Dependency] public IUserService UserService { get; set; }


        /// <summary>
        ///     This method provides list of application users and their roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/User/GetAllApplicationUsers")]
        public List<User> GetAllApplicationUsers()
        {
            return UserService.GetAllApplicationUsers();
        }

        /// <summary>
        ///     This method provides user details by giving email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/User/GetUserDetails")]
        public User GetUserDetails(string email)
        {
            return UserService.GetUserDetails(email);
        }

        /// <summary>
        ///     This method provides user details by giving userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/User/GetUserDetails")]
        public User GetUserDetails(int userId)
        {
            return UserService.GetUserDetails(userId);
        }

        /// <summary>
        ///     This method can insert or update user detail
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/User/InsertUpdateUser")]
        public int InsertUpdateUser(User user)
        {
            return UserService.InsertUpdatetUser(user);
        }

        /// <summary>
        ///     This method provides all the application roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/User/GetAllRoles")]
        public List<Role> GetAllRoles()
        {
            return UserService.GetAllRoles();
        }
    }
}
