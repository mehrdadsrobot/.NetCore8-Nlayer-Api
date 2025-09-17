namespace Models.UserModels
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Users User { get; set; }

        public int UserId { get; set; }
    }
}
