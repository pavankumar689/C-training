using System;
using System.IO;

class FileLogFilter
{
    static void Main(string[] args)
    {
        string inputFile = "log.txt";
        string outputFile = "error.txt";

        string[] lines = File.ReadAllLines(inputFile);

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (string line in lines)
            {
                if (line.Contains("ERROR"))
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
