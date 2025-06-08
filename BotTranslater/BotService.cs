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

namespace BotTranslater
{
    internal class BotService
    {
        private readonly TelegramBotClient botClient = new TelegramBotClient("YOUR_TELEGRAM_KEY");
        private readonly CancellationTokenSource ctsToken = new CancellationTokenSource();
        private readonly ReceiverOptions _options = new ReceiverOptions
        {
            AllowedUpdates = new[] { UpdateType.Message, UpdateType.CallbackQuery },
            DropPendingUpdates = true
        };
        public async Task StartAsync()
        {
            botClient.StartReceiving(Handlers.UpdateHandler, Handlers.ErrorHandler, _options, ctsToken.Token);
            var botInformation = await botClient.GetMe();
            Console.WriteLine($"Bot: [{botInformation.FirstName}] started working...");

            Console.ReadKey();
            await Task.Delay(3000);
            ctsToken.Cancel();
        }
    }
}
