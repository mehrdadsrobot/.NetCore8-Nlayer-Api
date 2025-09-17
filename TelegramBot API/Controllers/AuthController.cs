using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TelegramBot_API.Data_Transfer_Objects.UserDtos;
using Services.UserServices;

namespace TelegramBot_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserServices _userServices;

        public AuthController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<string>> SignIn(LoginDto loginDto)
        {
            var token = _userServices.Login(loginDto);
            return Ok(token);
        }

    }
}
