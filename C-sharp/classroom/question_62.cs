using System;
using System.Linq;

class ComputingAverage
{
    public static double? ComputeAverage(double?[] values)
    {
        if (values == null || values.Length == 0)
            return null;

        var nonNullValues = values.Where(v => v.HasValue).Select(v => v.Value);

        if (!nonNullValues.Any())
            return null;

        double avg = nonNullValues.Average();

        return Math.Round(avg, 2, MidpointRounding.AwayFromZero);
    }

    public static void Main()
    {
        double?[] numbers = { 6, 8, null, 10, 12, null, 14 };

        var result = ComputeAverage(numbers);

        Console.WriteLine(result == null ? "null" : result.ToString());
    }
}
