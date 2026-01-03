class Debit
{   
    public static void Atm_withdrawal_limit_validation()
    {
        int Todaywithdrawal=40000;
        Console.Write("Enter the withdrawal amount: ");
        int amount=Convert.ToInt32(Console.ReadLine());
        if (amount <= Todaywithdrawal)
        {
            Console.WriteLine("Withdrawal permitted within daily limit.");
        }
        else
        {
            Console.WriteLine("Dialy withdrawal amount exceeded.");
        }
    }

    public static void Emi_burden_evaluation()
    {
        Console.Write("Enter your monthly income: ");
        int income=Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter your monthly EMI amount: ");
        int Emi=Convert.ToInt32(Console.ReadLine());
        if (Emi <= 0.4 * income)
        {
            Console.WriteLine("Emi is financially manageable.");
        }
        else
        {
            Console.WriteLine("EMI exceeds safe income limit.");
        }
    }

    public static void Transaction_based_daily_spending_calculator()
    {
        Console.Write("Enter the number of transactions: ");
        int transactions=Convert.ToInt32(Console.ReadLine());
        int total=0;
        for(int i = 1; i <= transactions; i++)
        {
            Console.Write($"Enter the transation {i}: ");
            int current=Convert.ToInt32(Console.ReadLine());
            if (current < 0)
            {
                Console.WriteLine("Invalid amount.");
                continue;
            }
            total+=current;
        }
        Console.WriteLine($"Total debit amount for the day: {total}.");
    }

    public static void Minimum_balance_check_compliance()
    {
        int minimum_balance_required=2000;
        Console.Write("Enter your Current balance: ");
        int amount=Convert.ToInt32(Console.ReadLine());
        if (amount < minimum_balance_required)
        {
            Console.WriteLine("Minimum balance not maintained. Penalty applicable.");
        }
        else
        {
            Console.WriteLine("Minimum balance requirement satisfied.");
        }
    }
}