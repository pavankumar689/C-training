using System;
using System.Text.RegularExpressions;

public class Regexpressions
{
    public static void Main(string[] args)
    {
        // string a = "abc2025bcd2026";
        // Match result = Regex.Match(a, @"\d{4}");
        // Console.WriteLine(result.Value);
        //output:2025


        // string a = "abc2025bcd2026";
        // MatchCollection result = Regex.Matches(a, @"\d{4}");
        // foreach(Match m in result)
        // {
        //     Console.WriteLine(m.Value);
        // }
        //output:2025,2026


        // string sentence="123_123";
        // bool res=Regex.IsMatch(sentence,@"\d");
        // Console.WriteLine(res);
        //output:True


        // string sentence="123_123";
        // Match res=Regex.Match(sentence,@"\d+");
        // Console.WriteLine(res.Value);
        //output :123


        // string sentence="123_123";
        // Match res=Regex.Match(sentence,@"\d*");
        // Console.WriteLine(res.Value);
        //output:123

        // string sentence="Amount_5000";
        // Match res=Regex.Match(sentence,@"\d*");
        // Console.WriteLine(res.Value);
        //output:knothing

        // string sentence="Amount_5000";
        // Match res=Regex.Match(sentence,@"\d+");
        // Console.WriteLine(res.Value);
        //output:5000


        // string sentence="10_20_30";
        // MatchCollection res=Regex.Matches(sentence,@"\d+");
        // foreach(Match m in res)
        // {
        //     Console.WriteLine(m.Value);
        // }
        //output:10,20,30

        // string sentence="10A20B30C";
        // MatchCollection res=Regex.Matches(sentence,@"\D");
        // foreach(Match m in res)
        // {
        //     Console.WriteLine(m.Value);
        // }
        // output:A,B,C

        // string sentence="10A20B30C";
        // Match res=Regex.Match(sentence,@"\D");
        // Console.WriteLine(res.Value);
        //output:A

        // string sentence="10A20B30C";
        // Match res=Regex.Match(sentence,@"\w");
        // Console.WriteLine(res.Value);
        // output:1

        // string sentence="10A20B30C";
        // MatchCollection res=Regex.Matches(sentence,@"\w");
        // foreach(Match m in res)
        // {
        //     Console.WriteLine(m.Value);
        // }
        //output:1,0,A,2,0,B,3,0,C

        // string sentence="10A20B30C!@_abc";
        // MatchCollection res=Regex.Matches(sentence,@"\w");
        // foreach(Match m in res)
        // {
        //     Console.WriteLine(m.Value);
        // }
        // output:1,0,A,2,0,B,3,0,C,_a,b,c

        // string sentence="10A20B30C!@_ \t";
        // MatchCollection res=Regex.Matches(sentence,@"\W");
        // foreach(Match m in res)
        // {
        //     Console.WriteLine(m.Value);
        // }
        //output:!,@,space,tabspace

        
        // string sentence="10A20B30C!@_ ";
        // MatchCollection res=Regex.Matches(sentence,@"\s");
        // foreach(Match m in res)
        // {
        //     Console.WriteLine(m.Value);
        // }
        // output:space

        // string sentence="10A20B30C!@_ ";
        // MatchCollection res=Regex.Matches(sentence,@"\w");
        // foreach(Match m in res)
        // {
        //     Console.WriteLine(m.Value);
        // }
        //output:1,0,A,2,0,B,3,0,C,!,@,_

        // string sentence="10A20B30C!@_,c:\abc\file.txt";
        // MatchCollection res=Regex.Matches(sentence,@"\\.txt");
        // foreach(Match m in res)
        // {
        //     Console.WriteLine(m.Value);
        // }

        // string sentence="10A20B30C!@_,c?:\abc\file.txt?";
        // MatchCollection res=Regex.Matches(sentence,@"\?");
        // foreach(Match m in res)
        // {
        //     Console.WriteLine(m.Value);
        // }
        //output:?,?

        // string sentence="Hello10A20B30C!@_,c:\abc\file.txt?Hello";
        // MatchCollection res=Regex.Matches(sentence,@"^Hello");
        // foreach(Match m in res)
        // {
        //     Console.WriteLine(m.Value);
        // }


        // Match m = Regex.Match("Date: 2025-12-29", @"\d{4}-\d{2}-\d{2}");
        // Console.WriteLine(m);
        

        // string Sentence = "Amount: 5000";
        // string Pattern = @"Amount:\s*(?<value>\d+)";
        // Match m = Regex.Match(Sentence, Pattern);
        // Console.WriteLine(m.Groups["value"].Value);
        // //output:5000

        // string Pattern = @"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})";
        // string Input = "1992/02/23,1990-01-01";

        // MatchCollection ma = Regex.Matches(Input, Pattern);

        // foreach(Match m in ma){
        //     Console.WriteLine(m.Groups["year"].Value);
        //     Console.WriteLine(m.Groups["month"].Value);
        //     Console.WriteLine(m.Groups["date"].Value);
        // }

        // string Sentence = "apple";
        // string Pattern = @"a...e";
        // Match m = Regex.Match(Sentence, Pattern);
        // Match m2 = Regex.Match(Sentence, "a..");
        // Console.WriteLine(m);
        // Console.WriteLine(m2);

        // string Sentence="frappe";
        // Match m = Regex.Match(Sentence, @"a..");
        // Console.Write(m);

        List<string> Emails = new List<string>
        {
            "john.doe@gmail.com",
            "alice_123@yahoo.in",
            "mark.smith@company.com",
            "support-abc@banking.co.in",
            "user.nametag@domain.org",
            "john.doe@gmail",          // Missing domain extension
            "alice@@yahoo.com",        // Double @
            "mark.smith@.com",         // Domain missing name
            "support@banking..com",    // Double dot in domain
            "user name@gmail.com",     // Space not allowed
            "@domain.com",             // Missing username
            "admin@domain",            // No top-level domain
            "info@domain,com",         // Comma instead of dot
            "finance#dept@corp.com",   // Invalid character #
            "plainaddress"             // Missing @ and domain

        };
        foreach(string mail in Emails)
        {
            if (Regex.IsMatch(mail, @"\b[\w.-]+@[\w.-]+\.\w{2,}\b"))
            {
                Console.WriteLine(mail);
            }
        }
    }
}
