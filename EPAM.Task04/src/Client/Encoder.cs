using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Client
{
    public static class Encoder
    {
        private static readonly Dictionary<string, string> engRusDictionary = new Dictionary<string, string>
        {
           {@"\bI\b", "Ай" }, {"I've", "Ай'в" }, {"Sh", "Ш"}, {"sh", "ш" }, {"Ch", "Ч" }, {"ch", "ч" }, {"tion", "шн" },
           {"sion", "шн" }, {"cial", "шл" }, {"Th", "Т" }, {"th", "т" }, { "A", "А" }, { "B", "Б" }, { "C", "Ц" },
           { "D", "Д" }, { "E", "Э" }, { "F", "Ф" }, { "G", "Г" }, { "H", "Х" }, { "I", "И" }, { "J", "Ж" },
           { "K", "К" }, { "L", "Л" }, { "M", "М" }, { "N", "Н" }, { "O", "О" }, { "P", "П" }, { "Q", "К" }, { "R", "Р" },
           { "S", "С" }, { "T", "Т" }, { "U", "У" }, { "V", "В" }, { "W", "У" }, { "X", "Кс" }, { "Y", "И" }, { "Z", "З" },
           { "a", "а" }, { "b", "б" }, { "c", "ц" }, { "d", "д" }, { "e", "э" }, { "f", "ф" }, { "g", "г" }, { "h", "х" },
           { "i", "и" }, { "j", "ж" }, { "k", "к" }, { "l", "л" }, { "m", "м" }, { "n", "н" }, { "o", "о" }, { "p", "п" },
           { "q", "к" }, { "r", "р" }, { "s", "с" }, { "t", "т" }, { "u", "у" }, { "v", "в" }, { "w", "у" }, { "x", "кс" },
           { "y", "и" }, { "z", "з" },
        };
        private static readonly Dictionary<string, string> rusEngDictionary = new Dictionary<string, string>
        {
           { "А", "A" }, { "Б", "B" }, { "В", "V" }, { "Г", "G" }, { "Д", "D" }, { "Е", "Ye" }, { "Ж", "J" }, { "З", "Z" },
           { "И", "I" }, { "К", "K" }, { "Л", "L" }, { "М", "M" }, { "Н", "N" }, { "О", "O" }, { "П", "P" }, { "Р", "R" },
           { "С", "S" }, { "Т", "T" }, { "У", "U" }, { "Ф", "F" }, { "Х", "H" }, { "Ц", "C" }, { "Ч", "Ch" }, { "Ш", "Sh" },
           { "Щ", "Shch" }, { "ы", "y" }, { "Э", "E" }, { "Ю", "Yu" }, { "Я", "Ya" }, { "а", "a" }, { "б", "b" }, { "в", "v" },
           { "г", "g" }, { "д", "d" }, { "е", "ye" }, { "ж", "j" }, { "з", "z" }, { "и", "i" }, { "к", "k" }, { "л", "l" },
           { "м", "m" }, { "н", "n" }, { "о", "o" }, { "п", "p" }, { "р", "r" }, { "с", "s" }, { "т", "t" }, { "у", "u" },
           { "ф", "f" }, { "х", "h" }, { "ц", "c" }, { "ч", "ch" }, { "ш", "sh" }, { "щ", "shch" }, { "э", "e" }, { "ю", "yu" },
           { "я", "ya" },
        };

        public static string Encode(string message)
        {
            string encoded = message;
            Regex pattern;

            if (!Regex.IsMatch(encoded, @"\P{IsBasicLatin}"))
            {
                foreach (var pair in engRusDictionary)
                {
                    pattern = new Regex(pair.Key);
                    encoded = pattern.Replace(encoded, pair.Value);
                }
            }
            else if (!Regex.IsMatch(encoded, @"\P{IsCyrillic}"))
            {
                foreach (var pair in rusEngDictionary)
                {
                    pattern = new Regex(pair.Key);
                    encoded = pattern.Replace(encoded, pair.Value);
                }
            }
            return encoded;
        }
    }
}
