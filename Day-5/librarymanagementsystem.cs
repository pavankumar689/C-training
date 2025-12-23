using System;

public enum UserRole
{
    Admin, Librarian, Member
}

public enum ItemStatus
{
    Available, Borrowed, Reserved, Lost
}

interface IRservable
{
    void reservingItem();
}

interface INotifiable
{
    void AcceptMessage(UserRole role);
}

abstract class LibraryItem
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int ItemId { get; set; }

    public abstract void DisplayDetails();
    public abstract void LateFee();
}

namespace LibrarySystem
{
    namespace Items
    {
        class Book : LibraryItem, IRservable, INotifiable
        {
            public override void DisplayDetails()
            {
                Console.WriteLine($"{Title}:{Author}:{ItemId}");
            }

            public override void LateFee()
            {
                Console.WriteLine(3);
            }

            public void reservingItem()
            {
                Console.WriteLine("Reservation Success");
            }

        
            public void AcceptMessage(UserRole role)
            {
                if (role == UserRole.Admin)
                    Console.WriteLine("ADMIN ALERT: System-level notification");
                else if (role == UserRole.Member)
                    Console.WriteLine("MEMBER UPDATE: Borrowing status updated");
            }
        }

        class Magazine : LibraryItem
        {
            public override void DisplayDetails()
            {
                Console.WriteLine($"{Title}:{Author}:{ItemId}");
            }

            public override void LateFee()
            {
                Console.WriteLine(3 * 0.5);
            }
        }
    }

    namespace Users
    {
        public class Member
        {
            public string? Name { get; set; }
            public UserRole Role { get; set; }
        }
    }
}

partial class LibraryAnalytics
{
    public static int items;
}

partial class LibraryAnalytics
{
    public static void DisplayAnalytics()
    {
        Console.WriteLine(items);
    }
}
