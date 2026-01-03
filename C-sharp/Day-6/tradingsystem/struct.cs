struct PriceSnapshot
{
    public string StockSymbol;
    public double Price;
}

abstract class Trade2
{
    public int TradeId;
    public string? StockSymbol;
    public int Quantity;
    public abstract double calculatetrade();
    public override string ToString()
    {
        return $"TradeId:{TradeId}\nStockSymbol:{StockSymbol}\nQuantity:{Quantity}";
    }
}

class EquityTrade2:Trade2
{
    public double? MarketPrice=null;
    public override double calculatetrade()
    {
        double trade=MarketPrice??4000;
        return trade;
    }
}

class TradeRepository<T> where T:Trade2
{
    List<Trade2> Trades=new List<Trade2>();
    public static int Tradecounter=0;
    public void AddTrade(T trade)
    {   
        Trades.Add(trade);
        ++Tradecounter;
        TradeAnalytics.increament();
    }
    public void ShowDetails()
    {
        foreach(Trade2 i in Trades)
        {
            Console.WriteLine($"TradeId:{i.TradeId}\nStockSymbol:{i.StockSymbol}\nQuantity:{i.Quantity}");
            Console.WriteLine("\n");
        }
    }
}

static class TradeAnalytics
{
    public static int totalTrades;

    public static void increament()
    {
        ++totalTrades;
    }
    public static void DisplayAnalytics()
    {
        Console.WriteLine(totalTrades);
    }
}

static class Extendedmethods
{
    public static double brokaragecalculation(this double amount)
    {
        return amount*0.05;
    }
    public static double CalculateGST(this double amount)
    {
        return amount*0.08;
    }
}

