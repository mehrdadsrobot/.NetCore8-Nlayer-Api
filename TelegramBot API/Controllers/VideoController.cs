using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data_Access;
using Models;

namespace TelegramBot_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {

        private readonly TbotDbContext _context;
        public VideoController(TbotDbContext context) { _context = context; }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] Videos video)
        {
            _context.Videos.AddAsync(video);
            _context.SaveChanges();
        }

    }
}
    