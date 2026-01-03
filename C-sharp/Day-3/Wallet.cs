class Wallet
{
    private double Money;
    public void AddMoney(double amount)
    {
        Money+=amount;
    }
    public double GetBalance()
    {
        return Money;
    }
}