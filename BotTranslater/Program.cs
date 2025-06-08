using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using static Telegram.Bot.TelegramBotClient;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using DeepL;
using static System.Net.Mime.MediaTypeNames;

namespace BotTranslater
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            BotService botService = new BotService();
            await botService.StartAsync();
        }
    }
}
