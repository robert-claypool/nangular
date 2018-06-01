using NAngular.Domain.Models;
using NAngular.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity.Attributes;

namespace NAngular.Controllers
{
    public class UserController : ApiController
    {
        [Dependency]
        public IUserService UserService { get; set; }

        public List<User> objrate = new List<User>();

        /// <summary>
        /// This method provides list of application users and their roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/User/GetAllApplicationUsers")]        
        public List<User> GetAllApplicationUsers()
        {
            return UserService.GetAllApplicationUsers();
        }

        /// <summary>
        /// This method provides user details by giving email
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/User/GetUserDetails")]
        public User GetUserDetails(string Email)
        {
            return UserService.GetUserDetails(Email);
        }

        /// <summary>
        /// This method provides user details by giving userid
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/User/GetUserDetails")]
        public User GetUserDetails(int UserId)
        {
            return UserService.GetUserDetails(UserId);
        }

        /// <summary>
        /// This method can insert or update user detail
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
        /// This method provides all the application roles
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
