using System;
using System.Diagnostics;

class Program
{
    // static void Main()
    // {
        // Process currentProcess = Process.GetCurrentProcess();
        // Console.WriteLine("Current Process ID: " + currentProcess.Id);
        // Console.WriteLine("Process Name: " + currentProcess.ProcessName);
        // Console.WriteLine("Process Start Time: " + currentProcess.StartTime);
    // }
    // static void Main()
    // {
        // Create a new thread
        // Thread worker = new Thread(DoWork);

        // // Start the thread
        // worker.Start();

        // Console.WriteLine("Main thread continues...");

        // // Optional: Wait for worker thread to finish
        // worker.Join();
        // Console.WriteLine("Main thread finished");
        // Process.Start("cmd.exe");
    // }

    // static void DoWork()
    // {
    //     for (int i = 1; i <= 5; i++)
    //     {
    //         Console.WriteLine("Worker thread: " + i);
    //         Thread.Sleep(500); // Simulate work
    //     }
    // }
    // static int counter = 0;
    // static object lockObj = new object();

    static void Main()
    {
        // Thread t1 = new Thread(Increment);
        // Thread t2 = new Thread(Increment);

        // t1.Start();
        // t2.Start();

        // t1.Join();
        // t2.Join();

        // Console.WriteLine("Final Counter Value: " + counter);

        try
        {
        Task t =Task.Run(() => throw new Exception("Task error"));
        t.Wait();
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex. InnerExceptions[0].Message);
        }
    }

    // static void Increment()
    // {
    //     for (int i = 0; i < 100000; i++)
    //     {
    //         lock (lockObj)
    //         {
    //             counter++;
    //         }
    //     }
    // }


}
