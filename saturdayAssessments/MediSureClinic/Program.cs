using System;

class Medisure
{
    public static void Main(string[] args)
    {
        bool running = true;

        
        while (running)
        {
            Console.WriteLine("================== MediSure Clinic Billing ==================");
            Console.WriteLine("1. Create New Bill (Enter Patient Details)");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
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
                    PatientBill.CreateBill();
                    break;

                case 2:
                    PatientBill.ViewLastBill();
                    break;

                case 3:
                    PatientBill.ClearLastBill();
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
