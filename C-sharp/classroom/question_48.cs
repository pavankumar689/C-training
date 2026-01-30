using System;

class ObjectArraySum
{
    static int SumIntegers(object[] values)
    {
        int sum = 0;

        foreach (object v in values)
        {
            if (v is int x)
                sum += x;
        }

        return sum;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        object[] values = new object[n];

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int num))
                values[i] = num;
            else if (bool.TryParse(input, out bool b))
                values[i] = b;
            else if (input == "null")
                values[i] = null;
            else
                values[i] = input;
        }

        Console.WriteLine(SumIntegers(values));
    }
}
