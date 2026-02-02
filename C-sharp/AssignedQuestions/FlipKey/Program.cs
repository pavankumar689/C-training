
using System;
using System.Linq;

class CleanseAndInverst
{
    public string calculate(string str)
    {
        if (string.IsNullOrEmpty(str) || str.Length < 6)
        {
            Console.WriteLine("Invalid Input");
            return string.Empty;
        }

        if (str.Any(ch => !char.IsLetter(ch)))
        {
            Console.WriteLine("Invalid Input");
            return string.Empty;
        }

        string lower = str.ToLower();
        string res = "";

        foreach (char ch in lower)
        {
            if ((int)ch % 2 != 0)
            {
                res += ch;
            }
        }

        res = new string(res.Reverse().ToArray());

        string ans = "";
        for (int i = 0; i < res.Length; i++)
        {
            if (i % 2 == 0)
                ans += char.ToUpper(res[i]);
            else
                ans += res[i];
        }

        return ans;
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the word:");
        string str = Console.ReadLine();

        CleanseAndInverst ci = new CleanseAndInverst();
        string result = ci.calculate(str);

        Console.WriteLine(result);
    }
}