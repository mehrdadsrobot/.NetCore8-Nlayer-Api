using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.TelegramService;
using Telegram.Bot.Types;

namespace TelegramBot_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramController : ControllerBase
    {
        private readonly TelegramUpdateService _updateService;

        public TelegramController(TelegramUpdateService updateService)
        {
            _updateService = updateService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            await _updateService.HandleUpdateAsync(update);
            return Ok();
        }


    }
}
