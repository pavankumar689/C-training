class Credit
{
    public static void Net_salary_credit_calculation()
    {
        Console.Write("Enter your gross salary: ");
        int amount=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Net salary credited: {amount*0.9}");
    }

    public static void Fixed_deposit_maturity_calculation()
    {
        Console.Write("Enter the principle amount: ");
        int principle_amount=Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the rate of Interest: ");
        int interest_rate=Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the time period in months: ");
        int time_period=Convert.ToInt32(Console.ReadLine());
        double interest=principle_amount*interest_rate*(time_period/12)*0.01;
        Console.WriteLine($"Fixed Deposit maturity amount {principle_amount+interest}");
    }

    public static void credit_card_reward_evaluation_points()
    {
        Console.Write("Enter the total credit card amount spent: ");
        int amount=Convert.ToInt32(Console.ReadLine());
        int total_reward_points=amount/100;
        Console.WriteLine($"Reward points earned: {total_reward_points}");
    }

    public static void Employee_bonus_eligibility_check()
    {
        Console.Write("Enter your annual salary: ");
        int salary=Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the years of service: ");
        int service=Convert.ToInt32(Console.ReadLine());
        if(salary>=500000&& service >= 3)
        {
            Console.WriteLine("Employee is eligible for bonus.");
        }
        else
        {
            Console.WriteLine("Employee is not eligible for bonus. It is either because of you salary is less than 500000 or years of service is less than 3");
        }
    }
}