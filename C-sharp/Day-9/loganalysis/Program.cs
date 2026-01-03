using System.Text.RegularExpressions;
using LogProcessing;

namespace LogProcessing
{
    public class LogParser
    {
        private readonly string validLineRegexPattern = @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
        private readonly string splitLineRegexPattern = @"<\{3}>|<={4}>|<\^\>";
        private readonly string quotedPasswordRegexPattern = "\"[^\"]password[^\"]\"";
        private readonly string endOfLineRegexPattern = @"end-of-line\d+";
        private readonly string weakPasswordRegexPattern = @"password[a-zA-Z0-9]+";

        public bool IsValidLine(string t)
        {
            return Regex.IsMatch(t, validLineRegexPattern);
        }

        public string[] SplitLogLine(string t)
        {
            return Regex.Split(t, splitLineRegexPattern);
        }

        public int CountQuotedPasswords(string t)
        {
            return Regex.Matches(t, quotedPasswordRegexPattern, RegexOptions.IgnoreCase).Count;
        }

        public string RemoveEndOfLineText(string t)
        {
            return Regex.Replace(t, endOfLineRegexPattern, "");
        }

        public string[] ListLinesWithPasswords(string[] t)
        {
            string[] r = new string[t.Length];

            for (int i = 0; i < t.Length; i++)
            {
                Match m = Regex.Match(t[i], weakPasswordRegexPattern, RegexOptions.IgnoreCase);

                if (m.Success)
                    r[i] = m.Value + ": " + t[i];
                else
                    r[i] = "--------: " + t[i];
            }

            return r;
        }
    }
}

class Program11
{
    static void Main()
    {
        LogParser p = new LogParser();

        Console.WriteLine(p.IsValidLine("[INF] Test"));

        string[] a = p.SplitLogLine("a<*>b<====>c");
        foreach (string x in a)
            Console.WriteLine(x);

        Console.WriteLine(p.CountQuotedPasswords("\"password1\" \"passWORD2\""));

        Console.WriteLine(p.RemoveEndOfLineText("error end-of-line9"));

        string[] l =
        {
            "User password123 failed",
            "System running"
        };

        string[] o = p.ListLinesWithPasswords(l);
        foreach (string x in o)
            Console.WriteLine(x);
    }
}