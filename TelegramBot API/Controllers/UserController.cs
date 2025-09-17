using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TelegramBot_API.Data_Transfer_Objects.UserDtos;
using Models.UserModels;
using Services.UserServices;
using ServicesLayer.Services.ResponseType;
using Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelegramBot_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices) { _userServices = userServices; }

        // GET: api/<UsersController>
        //[HttpPost("[action]")]
        //[AllowAnonymous]
        //public async Task<string> Login([FromBody] LoginDto)
        //{

        //    return "";


        //}

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id)
        {
            var User = await _userServices.Get(id);
            
            if(User.Data == null)
            {
                return NotFound();
            }

            return Ok(User.Data);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Users>> GetAll()
        {
            var response = await _userServices.GetAll();
            return response;
        }

        // POST api/<UsersController>
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            var user = new Users
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                Id = userDto.Id,
                Password = userDto.Password,
                RoleId = userDto.RoleId,
            };
            var result = await _userServices.Create(user);
            if (result.Success == true)
            {
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ServiceResponse<Users>> Update(int id, [FromBody] Users userDto)
        {
            var resp = await _userServices.Update(id,userDto);

            return resp;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ServiceResponse<Users>> Delete(int id)
        {
            var resp = await _userServices.Delete(id);
            return resp;

        }
    }
}
