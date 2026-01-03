class Menu
{   
    public static void Debit1()
    {   
        bool running=true;
        while (running)
        {   
            Console.WriteLine();
            Console.WriteLine("Select Your choice\n");
            Console.WriteLine("1.ATM Withdrawal Limit Validation");
            Console.WriteLine("2.EMI Burden Evaluation");
            Console.WriteLine("3.Transaction-Based Daily Spending Calculator");
            Console.WriteLine("4.Minimum Balance Compliance Check");
            Console.WriteLine("5.Exit");
            Console.Write("Enter the choice: ");
            int choice=Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
            case 1:
                Debit.Atm_withdrawal_limit_validation();
                break;
            case 2:
                Debit.Emi_burden_evaluation();
                break;
            case 3:
                Debit.Transaction_based_daily_spending_calculator();
                break;
            case 4:
                Debit.Minimum_balance_check_compliance();
                break;
            case 5:
                running=false;
                break;
            }
        }
    }

    public static void Credit1()
    {
        
        bool running=true;
        while (running)
        {   
            Console.WriteLine();
            Console.WriteLine("Select Your choice\n");
            Console.WriteLine("1.Net Salary Credit Calculation");
            Console.WriteLine("2.Fixed Deposit Maturity Calculation");
            Console.WriteLine("3.Credit Card Reward Points Evaluation");
            Console.WriteLine("4.Employee Bonus Eligibility Check");
            Console.WriteLine("5.Exit");
            Console.Write("Enter the choice: ");
            int choice=Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
            case 1:
                Credit.Net_salary_credit_calculation();
                break;
            case 2:
                Credit.Fixed_deposit_maturity_calculation();
                break;
            case 3:
                Credit.credit_card_reward_evaluation_points();
                break;
            case 4:
                Credit.Employee_bonus_eligibility_check();
                break;
            case 5:
                running=false;
                break;
            }
        }
        
    }
    // public static void Main(String[] args)
    // {
    //     bool running=true;
    //     while (running)
    //     {   
    //         Console.WriteLine();
    //         Console.WriteLine("Menu\n");
    //         Console.WriteLine("1.Debit");
    //         Console.WriteLine("2.Credit");
    //         Console.WriteLine("3.Exit");
    //         Console.Write("Enter your choice: ");
    //         int choice=Convert.ToInt32(Console.ReadLine());
    //         switch (choice)
    //         {
    //             case 1:
    //                 Debit1();
    //                 break;
    //             case 2:
    //                 Credit1();
    //                 break;
    //             case 3:
    //                 running=false;
    //                 break;
    //         }
    //     }
    // }
}