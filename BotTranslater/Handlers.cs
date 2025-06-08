using DeepL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace BotTranslater
{
    internal class Handlers
    {
        static long chatId = 0;
        static string messageText;
        static int messageId;
        static string FirstName;
        static string LastName;
        static DateTime dateTime = DateTime.Now;

        static Dictionary<long, string> userStates = new Dictionary<long, string>();
        static Dictionary<long, string> language = new Dictionary<long, string>();

        public static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update.Message.Text != null)
            {
                chatId = update.Message.Chat.Id;
                messageText = update.Message.Text;
                messageId = update.Message.MessageId;
                FirstName = update.Message.From.FirstName;
                LastName = update.Message.From.LastName;
                using DeepLClient client = new DeepLClient("YOUR_DEEPL_KEY");

                Console.WriteLine($"User: |{FirstName}| Time: {dateTime}\nText: {messageText}");

                if (messageText == "/start")
                {
                    userStates[chatId] = "default";
                    await botClient.SendMessage(
                                chatId: chatId,
                                text: $"Welcome {FirstName}",
                                cancellationToken: cancellationToken,
                                replyMarkup: InlineButtons.GetMainInline()
                                );
                }
                else if (messageText == "/cancel")
                {
                    userStates[chatId] = "default";
                    await botClient.SendMessage(
                            chatId: chatId,
                            text: "The action was canceled. Return to the main menu",
                            replyMarkup: InlineButtons.GetMainInline(),
                            cancellationToken: cancellationToken
                            );
                    return;
                }

                if (!userStates.ContainsKey(chatId))
                    userStates[chatId] = "default";

                switch (userStates[chatId])
                {
                    case "Translate text":
                        var translations = await client.TranslateTextAsync(messageText, null, language[chatId]);
                        await botClient.SendMessage(
                            chatId: chatId,
                            text: $"- {translations}",
                            cancellationToken: cancellationToken
                            );
                        break;
                    case "Rephrase text":
                        var rephrasedText = await client.RephraseTextAsync(messageText, null, null);
                        await botClient.SendMessage(
                            chatId: chatId,
                            text: $"- {rephrasedText}",
                            cancellationToken: cancellationToken
                            );
                        break;
                }
                return;
            }

            if (update.Type == UpdateType.CallbackQuery)
            {
                string data = update.CallbackQuery.Data;
                await botClient.AnswerCallbackQuery(update.CallbackQuery.Id);

                if (data == "Translate text")
                {
                    userStates[chatId] = data;
                    await botClient.EditMessageText(
                               chatId: update.CallbackQuery.Message.Chat.Id,
                               messageId: update.CallbackQuery.Message.MessageId,
                               text: "Select the language to translate\n\nTo exit, write /cancel",
                               replyMarkup: InlineButtons.GetLanguage()
                               );
                }
                else if (Helpers._languageCode.Contains(data))
                {
                    language[chatId] = data;
                    await botClient.EditMessageText(
                               chatId: chatId,
                               messageId: update.CallbackQuery.Message.MessageId,
                               text: $"Great! Send me the text you want to translate into {Helpers.GetFullLanguage(data)}.\n\nTo exit, write /cancel",
                               replyMarkup: null);
                }

                if (data == "Rephrase text")
                {
                    userStates[chatId] = data;
                    await botClient.EditMessageText(
                               chatId: update.CallbackQuery.Message.Chat.Id,
                               messageId: update.CallbackQuery.Message.MessageId,
                               text: "Great! Send me the text to rephrase\n\nTo exit, write /cancel"
                               );
                }
            }
        }
        public static async Task ErrorHandler(ITelegramBotClient botClient, Exception ex, CancellationToken cancellationToken)
        {
            var exception = ex switch
            {
                ApiRequestException api => $"[{api.ErrorCode}] - [{api.Message}]",
                _ => $"{ex.Message} - Error"
            };
            Console.WriteLine(exception);
            await Task.CompletedTask;
        }
    }
}
