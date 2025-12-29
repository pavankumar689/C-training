using System;

class Program8
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("================== QuickMart Traders ==================");
            Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.\n");
                continue;
            }

            switch (choice)
            {
                case 1:
                    TransactionService.CreateTransaction();
                    break;

                case 2:
                    TransactionService.ViewLastTransaction();
                    break;

                case 3:
                    TransactionService.CalculateProfitLoss();
                    break;

                case 4:
                    running = false;
                    Console.WriteLine("\nThank you. Application closed normally.");
                    break;

                default:
                    Console.WriteLine("Invalid menu option. Please try again.\n");
                    break;
            }
        }
    }
}

