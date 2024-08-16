using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace String_searcher
{
    public class Words_ending_with
    {
        public static string Words_end_letter(string text)
        {
            string pattern = @"\b\w*я\b";
            MatchCollection matches = Regex.Matches(text, pattern);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Слова оканчивающиеся на букву 'я':");
            foreach (Match match in matches)
            {
                sb.AppendLine(match.Value);
            }
            return sb.ToString().Trim().Replace("\r\n", "\n");
        }
    }
}
