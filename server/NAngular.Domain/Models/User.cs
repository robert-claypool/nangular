namespace NAngular.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        //public Role Role { get; set; }
    }
}
