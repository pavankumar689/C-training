using System;
using System.Collections.Generic;

public class CreatorStats
{
    public string CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }

    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    public CreatorStats() { }

    public CreatorStats(string name, double[] likes)
    {
        CreatorName = name;
        WeeklyLikes = likes;
    }
}

public class StreamBuzz
{
    // Register creator into EngagementBoard
    public void RegisterCreator(CreatorStats record)
    {
        CreatorStats.EngagementBoard.Add(record);
    }

    // Count weeks where likes >= threshold
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (CreatorStats creator in records)
        {
            int count = 0;

            foreach (double likes in creator.WeeklyLikes)
            {
                if (likes >= likeThreshold)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                result.Add(creator.CreatorName, count);
            }
        }

        return result;
    }

    // Calculate overall average weekly likes
    public double CalculateAverageLikes()
    {
        double total = 0;
        int count = 0;

        foreach (CreatorStats creator in CreatorStats.EngagementBoard)
        {
            foreach (double likes in creator.WeeklyLikes)
            {
                total += likes;
                count++;
            }
        }

        if (count == 0)
            return 0;

        return total / count;
    }

    public static void Main(string[] args)
    {
        StreamBuzz app = new StreamBuzz();
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
                continue;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Creator Name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                    double[] likes = new double[4];

                    for (int i = 0; i < 4; i++)
                    {
                        likes[i] = Convert.ToDouble(Console.ReadLine());
                    }

                    CreatorStats creator = new CreatorStats(name, likes);
                    app.RegisterCreator(creator);
                    Console.WriteLine("Creator registered successfully");
                    break;

                case 2:
                    Console.WriteLine("Enter like threshold:");
                    double threshold = Convert.ToDouble(Console.ReadLine());

                    Dictionary<string, int> topPosts =
                        app.GetTopPostCounts(CreatorStats.EngagementBoard, threshold);

                    if (topPosts.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var entry in topPosts)
                        {
                            Console.WriteLine(entry.Key + " - " + entry.Value);
                        }
                    }
                    break;

                case 3:
                    double average = app.CalculateAverageLikes();
                    Console.WriteLine("Overall average weekly likes: " + average);
                    break;

                case 4:
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    running = false;
                    break;
            }
        }
    }
}
