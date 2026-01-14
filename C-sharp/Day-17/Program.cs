using System.Threading.Tasks;
using System.IO;
class Program
{
    public static async Task Main(string[] args)
    {
        // Thread thread=new Thread(new ParameterizedThreadStart(PrintMessage));
        // thread.Start("Hello from thread");
        // Thread worker=new Thread(DoWork);
        // worker.Start();
        // Console.WriteLine("Main thread continues...");

        // Parallel.For(0, 5, i =>
        // {
        //     Console.WriteLine($"Processing item {i}");
        // });

        // int[] numbers=new int[10];
        // for(int i = 0; i < numbers.Length; i++)
        // {
        //     numbers[i]=i+1;
        // }
        // int sum=0;
        // Parallel.For(0, numbers.Length, i=>{
        //     sum+=numbers[i];
        // });
        // Console.WriteLine("Sum: "+sum);
        // Parallel.For(0,numbers.Length,()=>0,
        // (i, loopState, localSum) =>
        // {
        //     return localSum+numbers[i];
        // },
        // localSum =>
        // {
        //     Interlocked.Add(ref sum,localSum);
        // }
        // );
        // Console.WriteLine("Sum: "+sum);

        // async Task<int> GetDataAsync()
        // {
        // await Task.Delay(1000);
        // return 42;
        // }
        // int result = await GetDataAsync();
        // Console.WriteLine(result);

        Console.WriteLine("Start reading file...");
        string content= await File.ReadAllTextAsync("data.txt");
        Console.WriteLine("File content:");
        Console.WriteLine(content);
        Console.WriteLine("End of program");

    }
    // static void PrintMessage(object message)
    // {
    //     Console.WriteLine(message);
    // }
    // static void DoWork()
    // {
    //     for(int i = 1; i <= 5; i++)
    //     {
    //         Console.WriteLine("Worker thread: "+i);
    //         Thread.Sleep(3000);
    //     }
    // }
}
