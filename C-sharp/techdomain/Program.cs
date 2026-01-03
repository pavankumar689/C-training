using System.Text.RegularExpressions;
using TechDomain;

namespace TechDomain
{
    public class LogRegex
    {
        // Task 1
        public bool Task1(string t)
        {
            return Regex.IsMatch(t, @"^\[(INFO|WARN|ERROR|DEBUG|CRITICAL)\] \d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}Z");
        }

        // Task 2
        public Match Task2(string t)
        {
            return Regex.Match(t, @"service=(?<service>[a-z]+)(?:.*userId=(?<userId>USR_\d+))?");
        }

        // Task 3
        public bool Task3(string t)
        {
            return Regex.IsMatch(t, @"password[a-zA-Z0-9]+|password='[a-zA-Z0-9]+'", RegexOptions.IgnoreCase);
        }

        // Task 4
        public Match Task4(string t)
        {
            return Regex.Match(t, @"txnId=(?<txnId>TXN\d+).amount=(?<amount>(₹\d{1,3}(,\d{3})(\.\d+)?|\$\d+))");
        }

        // Task 5
        public bool Task5(string t)
        {
            return Regex.IsMatch(t, @"password(?!=\*{4}|=X{5}|=#{4})=[a-zA-Z0-9]+", RegexOptions.IgnoreCase);
        }
    }
}

class Program15
{
    static void Main()
    {
        LogRegex r = new LogRegex();

        Console.WriteLine(r.Task1("[INFO] 2025-03-21T14:22:19Z"));

        var m2 = r.Task2("service=auth userId=USR_1023");
        Console.WriteLine(m2.Groups["service"].Value);
        Console.WriteLine(m2.Groups["userId"].Value);

        Console.WriteLine(r.Task3("passwordTemp123"));

        var m4 = r.Task4("txnId=TXN998877 amount=₹45,000.50");
        Console.WriteLine(m4.Groups["txnId"].Value);
        Console.WriteLine(m4.Groups["amount"].Value);

        Console.WriteLine(r.Task5("password=abc123"));
    }
}