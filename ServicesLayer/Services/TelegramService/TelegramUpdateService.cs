using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServicesLayer.Services.TelegramService
{
    public class TelegramUpdateService
    {
        private readonly TelegramBotClient _bot;

        public TelegramUpdateService(IConfiguration config)
        {
            _bot = new TelegramBotClient(config["BotToken"]);
        }


        public async Task HandleUpdateAsync(Update update)
        {
            if (update.Message is { Text: var messageText } message)
            {
                await _bot.SendMessage(chatId:message.Chat.Id,
                    text: $"Echo: {messageText}");
            }
        }


    }
}
