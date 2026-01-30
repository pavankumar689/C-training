using System;

class ParsingSum
{
    static int SumParsedIntegers(string[] tokens)
    {
        int sum = 0;

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int value))
                sum += value;
        }

        return sum;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] tokens = new string[n];

        for (int i = 0; i < n; i++)
            tokens[i] = Console.ReadLine();

        Console.WriteLine(SumParsedIntegers(tokens));
    }
}
