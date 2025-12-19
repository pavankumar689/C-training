//problem statement

// Design a Finance Control System that performs the following tasks:
// Loan Eligibility Check
// Income Tax Calculation
// Transaction Entry System
// Exit Program
// The system should run continuously until the user chooses to exit.


// Finance Rules Used
// Loan Eligibility Rules
// Age must be 21 years or above
// Monthly income must be ₹30,000 or more

// Income Tax Rules
// Annual Income
// Tax Rate
// ≤ ₹2,50,000
// 0%
// ₹2,50,001 – ₹5,00,000
// 5%
// ₹5,00,001 – ₹10,00,000
// 20%
// Above ₹10,00,000
// 30%


// Transaction Rules
// User can enter 5 transactions
// Negative amount is invalid
// Invalid transactions should be skipped
// Menu Design (Using switch-case)
// 1. Check Loan Eligibility
// 2. Calculate Tax
// 3. Enter Transactions
// 4. Exit

class Banking_Financialservices_insurance
{   
    static int balance=0;
    public static void check_load_eligibility(){
        Console.Write("Please Enter your age: ");
        int age=Convert.ToInt32(Console.ReadLine());
        Console.Write("Please Enter your Monthly income in Rupees: ");
        int Income=Convert.ToInt32(Console.ReadLine());
        if(age>=21 && Income >= 30000)
        {
            Console.WriteLine("Congratulations you are eligible for applying loan.");
        }else if(age < 21 && Income < 30000)
        {
            Console.WriteLine("Your Income and age are less than the required. So Not eliglible.");
        }
        else if (age < 21)
        {
            Console.WriteLine("Your age is less than 21. Not eligible for applying loan.");
        }else if (Income < 30000)
        {
            Console.WriteLine("Your Income is less than 30000. Not eligible for applying loan.");
        }
        Console.WriteLine();
    }

    public static void calculate_tax()
    {
        Console.Write("Enter your annual Income in Rupees: ");
        int amount=Convert.ToInt32(Console.ReadLine());
        if (amount <= 250000)
        {
            Console.WriteLine("No need to pay any tax.");
        }else if( amount>250000 && amount <= 500000)
        {
            Console.WriteLine($"You need to pay tax of {amount*0.05} Rupees");
        }else if(amount>500000 && amount <= 1000000)
        {
            Console.WriteLine($"You need to pay tax of {amount*0.2} Rupees");
        }
        else
        {
            Console.WriteLine($"You need to pay tax of {amount*0.3} Rupees");
        }
        Console.WriteLine(" ");
    }

    public static void Deposit()
    {
        Console.Write("Enter the amount you want to deposit: ");
        int amount=Convert.ToInt32(Console.ReadLine());
        if (amount < 0)
        {
            Console.WriteLine("Please enter the valid deposit amount");
        }
        else
        {
            balance+=amount;
            Console.WriteLine($"Amount deposited successfully. your current balance is {balance}.");
        }

    }

    public static void Withdraw()
    {
        Console.Write("Enter the amount you want to withdraw: ");
        int amount=Convert.ToInt32(Console.ReadLine());
        if (amount > balance)
        {
            Console.WriteLine($"Insufficient balance. Your current balance is {balance}.");
        }
        else
        {   
            balance-=amount;
            Console.WriteLine("Withdrawal successful");
        }

    }

    public static void Check_balance()
    {
        Console.WriteLine($"Your account balance is {balance}.");
    }
    public static void Enter_transactions()
    {
        Console.WriteLine("Select The choice");
        Console.WriteLine("1.Deposit");
        Console.WriteLine("2.Withdraw");
        Console.WriteLine("3.Check Balance");
        Console.Write("Enter you choice: ");
        int choice=Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
            case 1:
                Deposit();
                break;
            case 2:
                Withdraw();
                break;
            case 3:
                Check_balance();
                break;
        }
    }
    // public static void Main(String[] args)
    // {   
    //     bool program=true;
    //     while (program)
    //     {
    //         Console.WriteLine("Menu");
    //         Console.WriteLine();
    //         Console.WriteLine("1. Check Loan Eligibility");
    //         Console.WriteLine("2. Calculate Tax");
    //         Console.WriteLine("3. Enter Transactions");
    //         Console.WriteLine("4. Exit");
    //         Console.Write("Enter your choice: ");
    //         int Entered_choice=Convert.ToInt32(Console.ReadLine());

    //         switch (Entered_choice)
    //         {
    //             case 1:
    //                 check_load_eligibility();
    //                 break;
    //             case 2:
    //                 calculate_tax();
    //                 break;
    //             case 3:
    //                 Enter_transactions();
    //                 break;
    //             case 4:
    //                 program=false;
    //                 break;
    //         }
    //     }
    //}
}