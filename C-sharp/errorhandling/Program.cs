using System;
using System.IO;
class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {
        
    }
}

// class BankAccount
// {
//     public decimal Balance { get; private set; } = 5000;

//     public void Withdraw(decimal amount)
//     {
//         if (amount <= 0)
//             throw new ArgumentException("Withdrawal amount must be greater than zero");

//         if (amount > Balance)
//             throw new InsufficientBalanceException("Insufficient balance for withdrawal");

//         Balance -= amount;
//     }
// }

class errorhandling
{
    public static void Main(string[] args)
    {
    //     try
    //     {
    //         Console.Write("Enter withdrawal amount: ");

    //         if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
    //             throw new FormatException("Invalid number format");

            
    //         int serviceCharge = 100;
    //         // int divisionCheck = serviceCharge / 0; // Uncomment to test DivideByZeroException

    //         // File access example
    //         //string data = File.ReadAllText("account.txt");

    //         // Business logic
    //         BankAccount account = new BankAccount();
    //         account.Withdraw(amount);

    //         Console.WriteLine("Withdrawal Successful.");
    //         Console.WriteLine("Remaining Balance: " + account.Balance);
    //     }
    //     catch (FormatException ex)
    //     {
    //         LogException(ex);
    //         Console.WriteLine("Invalid input format.");
    //     }
    //     catch (DivideByZeroException ex)
    //     {
    //         LogException(ex);
    //         Console.WriteLine("Arithmetic error occurred.");
    //     }
    //     catch (FileNotFoundException ex)
    //     {
    //         LogException(ex);
    //         Console.WriteLine("Required file not found.");
    //     }
    //     catch (InsufficientBalanceException ex)
    //     {
    //         LogException(ex);
    //         Console.WriteLine(ex.Message);
    //     }
    //     catch (Exception ex)
    //     {
    //         LogException(ex);
    //         Console.WriteLine("An unexpected error occurred.");
    //     }
    //     finally
    //     {
    //         Console.WriteLine("Transaction Attempt Completed.");
    //     }
    // }

    // static void LogException(Exception ex)
    // {
    //     File.AppendAllText(
    //         "error.log",
    //         DateTime.Now + " | " + ex.GetType().Name + " | " + ex.Message + Environment.NewLine
    //     );
    // }
    //     FileStream file = null;
    // try
    // {
    //     file = new FileStream("data.txt", FileMode.Open);
    //     // Perform file operations
    //     int data = file.ReadByte();
    //     Console.WriteLine(data);
    // }
    // catch (FileNotFoundException ex)
    // {
    //     Console.WriteLine("File not found: " + ex.Message);
    // }
    // finally
    // {
    //     if (file != null)
    //     {
    //         file.Close(); // Ensures file is always closed
    //         Console.WriteLine("File stream closed in finally block.");
    //     }
    // }
        // try
        // {
        //     // Simulate database operation
        //     throw new SqlException("Connection failed");
        // }
        // catch (SqlException ex)
        // {
        //     // Wrap low-level exception into higher-level exception
        //     throw new Exception("Database operation failed in Service Layer", ex);
        // }
        // 
            Console.Write("Enter initial balance: ");
            decimal initialBalance = decimal.Parse(Console.ReadLine());

            BankAccount account = new BankAccount(initialBalance);

            // Withdraw amount
            Console.Write("Enter withdrawal amount: ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());

            account.Withdraw(withdrawAmount);

            Console.WriteLine($"Withdrawal successful!");
            Console.WriteLine($"Remaining balance: {account.Balance:C}");
    }
}


public class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative", nameof(initialBalance));

        Balance = initialBalance;
    }

    public void Withdraw(decimal amount)
    {
        // Validate numeric range
        if (amount <= 0)
            throw new ArgumentException(
                "Withdrawal amount must be greater than zero",
                nameof(amount));

        // Enforce business rule
        if (amount > Balance)
            throw new InsufficientBalanceException(
                $"Cannot withdraw {amount:C}. Available balance: {Balance:C}");

        Balance -= amount;
    }
}
