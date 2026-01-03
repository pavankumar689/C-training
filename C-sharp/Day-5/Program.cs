using Li=LibrarySystem.Items;
interface IPrintable
{
    void Print();
    static int count;
}

class Report : IPrintable
{
    public void Print()
    {
        Console.WriteLine("Printing report");
    }

}

interface ILogger
{
    void Log();
}
interface INotifier
{
    void Log();
}
class FileLogger : ILogger, INotifier
{
    void ILogger.Log()
    {
        Console.WriteLine("Logging to file via ILogger");
    }
    void INotifier.Log()
    {
        Console.WriteLine("Logging to notification via INotifier");
    }
}
class ResourceHandler : IDisposable, INotifier
{
    void IDisposable.Dispose()
    {
        Console.WriteLine("Resource disposed");
    }
    void INotifier.Log()
    {
        Console.WriteLine("Notification sent");
    }
}



class Program3
{
    // static void Main()
    // {
    //     var member = new LibrarySystem.Users.Member
    //     {
    //         Name = "Pavan",
    //         Role = UserRole.Member
    //     };

    //     var admin = new LibrarySystem.Users.Member
    //     {
    //         Name = "Admin",
    //         Role = UserRole.Admin
    //     };

    //     //Task 1
    //     Li.Book book = new Li.Book
    //     {
    //         Title = "C#",
    //         Author = "Microsoft",
    //         ItemId = 101
    //     };

    //     Li.Magazine mag=new Li.Magazine
    //     {
    //         Title="magzine",
    //         Author="Author of Magzine",
    //         ItemId=53
    //     };
    //     book.DisplayDetails();
    //     book.LateFee();
    //     mag.DisplayDetails();
    //     mag.LateFee();

    //     //Task 3
    //     LibraryItem[] l= new LibraryItem[2];
    //     l[0]=book;
    //     l[1]=mag;
    //     foreach(LibraryItem i in l)
    //     {
    //         i.DisplayDetails();
    //     }

    //     //Task 4
    //     IRservable r=new Li.Book();
    //     r.reservingItem();
    //     INotifiable g=new Li.Book();
    //     g.AcceptMessage(admin.Role);

    //     //Task 6
    //     LibraryAnalytics.items=50;
    //     LibraryAnalytics.DisplayAnalytics();

    //     book.AcceptMessage(member.Role);
    //     book.AcceptMessage(admin.Role);
    // }
}

