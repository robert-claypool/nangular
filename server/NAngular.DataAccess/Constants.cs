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
            public const string UserId = "@UserID";
            public const string Email = "@Email";
            public const string RoleId = "@RoleID";
        }
    }
}
