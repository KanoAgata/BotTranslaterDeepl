using DeepL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTranslater
{
    internal class Helpers
    {
        public static readonly List<string> _languageCode = new List<string>
        {
            LanguageCode.EnglishAmerican,
            LanguageCode.EnglishBritish,
            LanguageCode.Italian,
            LanguageCode.French,
            LanguageCode.Czech,
            LanguageCode.German,
            LanguageCode.Russian,
            LanguageCode.Ukrainian,
            LanguageCode.Turkish
        };
        public static string GetFullLanguage(string lan) => lan switch
        {
            LanguageCode.EnglishAmerican => "American English",
            LanguageCode.EnglishBritish => "British English",
            LanguageCode.Italian => "Italian",
            LanguageCode.French => "French",
            LanguageCode.Czech => "Czech",
            LanguageCode.German => "German",
            LanguageCode.Russian => "Russian",
            LanguageCode.Ukrainian => "Ukrainian",
            LanguageCode.Turkish => "Turkish",
            _ => lan
        };
    }
}
