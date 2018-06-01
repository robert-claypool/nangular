using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAngular.DataAccess
{
    public static class Constants
    {
        public static class StoredProcedure
        {
            public static class User
            {
                public const string GetAllApplicationUsers = "[dbo].[User_GetApplicationUsers]";
                public const string InsertUpdateUser = "[dbo].[User_InsertUpdateUser]";
                public const string GetAllRoles = "[dbo].[Role_GetAllRoles]";

            }
        }

        public static class Parameter
        {
            public const string UserID = "@UserID";
            public const string Email = "@Email";
            public const string RoleID = "@RoleID";
        }

    }
}
