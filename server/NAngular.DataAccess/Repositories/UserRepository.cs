using System.Collections.Generic;
using System.Linq;
using NAngular.DataAccess.DataMapper;
using NAngular.DataAccess.Repositories.Interfaces;
using NAngular.Domain.Models;
using Unity.Attributes;

namespace NAngular.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        [Dependency] public IDataMapper DataMapper { get; set; }

        public List<User> GetAllApplicationUsers()
        {
            var result = DataMapper
                .ExecuteStoredProcedureReader<User>(Constants.StoredProcedure.User.GetAllApplicationUsers).ToList();
            return result;
        }

        public User GetUserDetails(string email)
        {
            var parameters = new ParameterList();
            parameters.Add(Constants.Parameter.Email, email);

            var result = DataMapper
                .ExecuteStoredProcedureReader<User>(Constants.StoredProcedure.User.GetAllApplicationUsers, parameters)
                .FirstOrDefault();
            return result;
        }

        public User GetUserDetails(int userId)
        {
            var parameters = new ParameterList
            {
                {Constants.Parameter.UserId, userId}
            };

            var result = DataMapper
                .ExecuteStoredProcedureReader<User>(Constants.StoredProcedure.User.GetAllApplicationUsers, parameters)
                .FirstOrDefault();
            return result;
        }

        public int InsertUpdatetUser(User user)
        {
            var parameters = GetUserParameter(user);

            var result =
                DataMapper.ExecuteStoredProcedureNonQuery(Constants.StoredProcedure.User.InsertUpdateUser, parameters);
            return result;
        }

        public List<Role> GetAllRoles()
        {
            var result = DataMapper.ExecuteStoredProcedureReader<Role>(Constants.StoredProcedure.User.GetAllRoles)
                .ToList();
            return result;
        }

        private static ParameterList GetUserParameter(User user)
        {
            var parameters = new ParameterList();
            parameters.Add(Constants.Parameter.UserId, user.UserId);
            parameters.Add(Constants.Parameter.Email, user.Email);
            //parameters.Add(Constants.Parameter.RoleId, user.Role.RoleId);
            parameters.Add(Constants.Parameter.RoleId, user.RoleId);

            return parameters;
        }
    }
}
