using DigitalWallet.Core;

namespace DigitalWalletApp
{
    class Program
    {
        // public static void Main(string[] args)
        // {
        //     Console.WriteLine(WalletInfo.GetAppName());
        // }

        static void Main(string[] args)
        {
            WalletData wallet = new WalletData();

            wallet.UserId = 101;
            wallet.UserName = "Amit";
            wallet.Balance = 5000.50m;
            wallet.IsActive = true;

            wallet.RecentTransactions = new decimal[3];
            wallet.RecentTransactions[0] = 500;
            wallet.RecentTransactions[1] = 1200;
            wallet.RecentTransactions[2] = 300;

            Console.WriteLine("User Name: " + wallet.UserName);
            Console.WriteLine("Balance: " + wallet.Balance);
            Console.WriteLine("Wallet Active: " + wallet.IsActive);

            Console.WriteLine("Recent Transactions:");
            for (int i = 0; i < wallet.RecentTransactions.Length; i++)
            {
                Console.WriteLine(wallet.RecentTransactions[i]);
            }
        }
    }
}

