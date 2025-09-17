using Models.Claims;

namespace Models
{
    public class UserAction
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
