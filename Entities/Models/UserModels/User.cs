using Models.Claims;

namespace Models.UserModels
{
    public class Users
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Role> Roles { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}
