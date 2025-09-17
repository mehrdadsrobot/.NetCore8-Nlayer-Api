using Models.UserModels;

namespace TelegramBot_API.Data_Transfer_Objects.UserDtos
{
    public class LoginDto : Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
