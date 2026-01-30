using System;

class BankTransactionProgram
{
    static int GetFinalBalance(int initialBalance, int[] transactions)
    {
        int balance = initialBalance;

        foreach (int t in transactions)
        {
            if (t >= 0)
            {
                balance += t;
            }
            else
            {
                int withdraw = -t;
                if (balance >= withdraw)
                    balance -= withdraw;
            }
        }

        return balance;
    }

    static void Main(string[] args)
    {
        int initialBalance = Convert.ToInt32(Console.ReadLine());
        int n = Convert.ToInt32(Console.ReadLine());

        int[] transactions = new int[n];
        for (int i = 0; i < n; i++)
            transactions[i] = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(GetFinalBalance(initialBalance, transactions));
    }
}
