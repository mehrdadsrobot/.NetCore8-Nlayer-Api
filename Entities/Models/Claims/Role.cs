
using Models.UserModels;

namespace Models.Claims
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection <UserAction> UserActions { get; set; }
        
    }
}
