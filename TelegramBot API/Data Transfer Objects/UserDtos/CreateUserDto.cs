namespace TelegramBot_API.Data_Transfer_Objects.UserDtos
{
    public class CreateUserDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
