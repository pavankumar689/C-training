using System;

class TimeConversion
{
    static string ConvertSeconds(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        return minutes + ":" + seconds.ToString("D2");
    }

    static void Main(string[] args)
    {
        int totalSeconds = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(ConvertSeconds(totalSeconds));
    }
}
