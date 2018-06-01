using NAngular.DataAccess.Repositories.Interfaces;
using NAngular.Domain.Models;
using NAngular.DataAccess.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace NAngular.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        [Dependency]
        public IDataMapper DataMapper { get; set; }

        public List<User> GetAllApplicationUsers()
        {
            var result = DataMapper.ExecuteStoredProcedureReader<User>(Constants.StoredProcedure.User.GetAllApplicationUsers).ToList();
            return result;
        }

        public User GetUserDetails(string Email)
        {
            ParameterList parameters = new ParameterList();
            parameters.Add(Constants.Parameter.Email, Email);

            var result = DataMapper.ExecuteStoredProcedureReader<User>(Constants.StoredProcedure.User.GetAllApplicationUsers).FirstOrDefault();
            return result;
        }

        public User GetUserDetails(int UserId)
        {
            ParameterList parameters = new ParameterList
            {
                { Constants.Parameter.UserID, UserId }
            };

            var result = DataMapper.ExecuteStoredProcedureReader<User>(Constants.StoredProcedure.User.GetAllApplicationUsers).FirstOrDefault();
            return result;
        }

        public int InsertUpdatetUser(User user)
        {
            ParameterList parameters = GetUserParameter(user);

            var result = DataMapper.ExecuteStoredProcedureNonQuery(Constants.StoredProcedure.User.InsertUpdateUser, parameters);
            return result;
        }

        private static ParameterList GetUserParameter(User user)
        {
            ParameterList parameters = new ParameterList();
            parameters.Add(Constants.Parameter.UserID, user.UserId);
            parameters.Add(Constants.Parameter.Email, user.Email);
            parameters.Add(Constants.Parameter.RoleID, user.RoleId);

            return parameters;
        }

        public List<Role> GetAllRoles()
        {
            var result = DataMapper.ExecuteStoredProcedureReader<Role>(Constants.StoredProcedure.User.GetAllRoles).ToList();
            return result;
        }
    }
}
