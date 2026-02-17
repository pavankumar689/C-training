using System;
using System.Collections.Generic;

interface IStringParser
{
    List<float> RetrieveFloatValues(string input);
}

interface IFloatRounder
{
    List<float> RoundFloats(List<float> values);
}

class SensorDataProcessor : IStringParser, IFloatRounder
{
    public List<float> RetrieveFloatValues(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        string[] parts = input.Split(',');
        List<float> result = new List<float>();

        foreach (string part in parts)
        {
            string trimmed = part.Trim();

            if (string.IsNullOrEmpty(trimmed) || 
                trimmed.Equals("null", StringComparison.OrdinalIgnoreCase))
                continue;

            if (float.TryParse(trimmed, out float value) &&
                !float.IsNaN(value))
            {
                result.Add(value);
            }
        }

        return result.Count > 0 ? result : null;
    }

    public List<float> RoundFloats(List<float> values)
    {
        if (values == null || values.Count == 0)
            return null;

        List<float> rounded = new List<float>();

        foreach (float value in values)
        {
            rounded.Add((float)Math.Round(value, 2));
        }

        return rounded;
    }
}

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        SensorDataProcessor processor = new SensorDataProcessor();

        List<float> parsed = processor.RetrieveFloatValues(input);
        List<float> finalResult = processor.RoundFloats(parsed);

        if (finalResult == null)
        {
            Console.WriteLine("No valid sensor readings found.");
            return;
        }

        Console.WriteLine("{ " + string.Join(", ", finalResult) + " }");
    }
}
