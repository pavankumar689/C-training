using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> csvData = new List<string>()
        {
            "Ravi,87",
            "Kumar,98",
            "Arun,92"
        };

        List<string> top3 = csvData
            .Select(x => new
            {
                Name = x.Split(',')[0],
                Marks = int.Parse(x.Split(',')[1])
            })
            .OrderByDescending(s => s.Marks)
            .Take(3)
            .Select(s => s.Name)
            .ToList();

        foreach (var name in top3)
        {
            Console.WriteLine(name);
        }
    }
}