using System;
using System.Text;

public class Program
{
    public string CleanseAndInvert(string input)
    {
        // Rule 1: null or length < 6
        if (string.IsNullOrEmpty(input) || input.Length < 6)
        {
            return string.Empty;
        }

        // Rule 2: must contain only alphabets (no space, digit, special char)
        foreach (char ch in input)
        {
            if (!char.IsLetter(ch))
            {
                return string.Empty;
            }
        }

        // Convert to lowercase
        input = input.ToLower();

        // Remove characters with even ASCII values
        StringBuilder filtered = new StringBuilder();
        foreach (char ch in input)
        {
            if ((int)ch % 2 != 0)
            {
                filtered.Append(ch);
            }
        }

        // Reverse the string
        char[] reversed = filtered.ToString().ToCharArray();
        Array.Reverse(reversed);

        // Convert even index characters to uppercase
        for (int i = 0; i < reversed.Length; i++)
        {
            if (i % 2 == 0)
            {
                reversed[i] = char.ToUpper(reversed[i]);
            }
        }

        return new string(reversed);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();

        Program program = new Program();
        string result = program.CleanseAndInvert(input);

        if (string.IsNullOrEmpty(result))
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine("The generated key is - " + result);
        }
    }
}
