using System;
using System.Collections.Generic;

public class CreatorStats
{
    public string CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }
}

public class Program
{
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
    }

    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        for (int i = 0; i < records.Count; i++)
        {
            int cnt = 0;
            for (int j = 0; j < records[i].WeeklyLikes.Length; j++)
            {
                if (records[i].WeeklyLikes[j] >= likeThreshold)
                    cnt++;
            }

            if (cnt > 0)
                result.Add(records[i].CreatorName, cnt);
        }

        return result;
    }

    public double CalculateAverageLikes()
    {
        double sum = 0;
        int cnt = 0;

        for (int i = 0; i < EngagementBoard.Count; i++)
        {
            for (int j = 0; j < EngagementBoard[i].WeeklyLikes.Length; j++)
            {
                sum += EngagementBoard[i].WeeklyLikes[j];
                cnt++;
            }
        }

        if (cnt == 0)
            return 0;

        return sum / cnt;
    }

    static void Main()
    {
        Program obj = new Program();
        bool run = true;

        while (run)
        {
            Console.WriteLine("\n1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");
            int ch = int.Parse(Console.ReadLine());

            if (ch == 1)
            {
                CreatorStats cs = new CreatorStats();

                Console.WriteLine("Enter Creator Name:");
                cs.CreatorName = Console.ReadLine();

                cs.WeeklyLikes = new double[4];
                Console.WriteLine("Enter weekly likes (Week 1 to 4):");

                for (int i = 0; i < 4; i++)
                    cs.WeeklyLikes[i] = double.Parse(Console.ReadLine());

                obj.RegisterCreator(cs);
                Console.WriteLine("Creator registered successfully");
            }
            else if (ch == 2)
            {
                Console.WriteLine("Enter like threshold:");
                double th = double.Parse(Console.ReadLine());

                Dictionary<string, int> res = obj.GetTopPostCounts(EngagementBoard, th);

                if (res.Count == 0)
                {
                    Console.WriteLine("No top-performing posts this week");
                }
                else
                {
                    foreach (var x in res)
                        Console.WriteLine(x.Key + " - " + x.Value);
                }
            }
            else if (ch == 3)
            {
                double avg = obj.CalculateAverageLikes();
                Console.WriteLine("Overall average weekly likes: " + avg);
            }
            else if (ch == 4)
            {
                Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                run = false;
            }
        }
    }
}