using DeepL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotTranslater
{
    internal class InlineButtons
    {
        public static InlineKeyboardMarkup GetMainInline()
        {
            return new InlineKeyboardMarkup(new[]
            {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Translate text", "Translate text"),
                        InlineKeyboardButton.WithCallbackData("Rephrase text", "Rephrase text")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithUrl("Website", "https://www.deepl.com/en/translator")
                    }
            });
        }
        public static InlineKeyboardMarkup GetLanguage()
        {
            return new InlineKeyboardMarkup(new[]
            {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("EnglishAmerican", LanguageCode.EnglishAmerican),
                        InlineKeyboardButton.WithCallbackData("EnglishBritish", LanguageCode.EnglishBritish),
                        InlineKeyboardButton.WithCallbackData("Italian", LanguageCode.Italian)
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("French", LanguageCode.French),
                        InlineKeyboardButton.WithCallbackData("Czech", LanguageCode.Czech),
                        InlineKeyboardButton.WithCallbackData("German", LanguageCode.German)
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Russian", LanguageCode.Russian),
                        InlineKeyboardButton.WithCallbackData("Ukrainian", LanguageCode.Ukrainian),
                        InlineKeyboardButton.WithCallbackData("Turkish", LanguageCode.Turkish)
                    }
            });
        }
    }
}
