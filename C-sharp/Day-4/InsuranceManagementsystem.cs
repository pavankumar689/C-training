sealed class UserAuthentication
{
    public void authenticate()
    {
        Console.WriteLine("Authentication successful");
    }
}

abstract class InsurencyPolicy
{
    public int PolicyNumber{get;init;}
    private int premium;
    public int Premium
    {
        get{return premium;}
        set
        {
            if (value > 0)
            {
                premium=value;
            }
            else
            {
                Console.WriteLine("Enter a valid number");
            }
        }
    }
    public virtual double calculatepremium()
    {
        return Premium;
    }

    public void showPolicy()
    {
        Console.WriteLine("Insurence policy");
    }
    public string? name{get;set;}
}

class LifeInsurance : InsurencyPolicy
{
    public override double calculatepremium()
    {
        return Premium*0.1;
    }
    public new void showPolicy()
    {
        Console.WriteLine("This is new policy");
    }
}

class HealthInsurance : InsurencyPolicy
{
    public sealed override double calculatepremium()
    {
        return Premium*0.15;
    }

}

class Policydirectory
{
    private Dictionary<int,string> policies=new Dictionary<int,string>();

    public string this[int id]
    {
        get{return policies[id];}
        set
        {
            policies[id]=value;
        }
    }
}