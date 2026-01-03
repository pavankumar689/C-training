class Exceptionhandling
{
    public static void Main(string[] args)
    {
        //try
        //{
        //    int x = 10;
        //    int y = 2;
        //    Console.WriteLine(x / y);
        //}
        //catch
        //{
        //    Console.WriteLine("cannot divide by zero");
        //}
        try
        {
            File.ReadAllText("data.txt");
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message+ex.StackTrace+ex.InnerException+ex.GetType()+ex.Source);
        }
    }
}
