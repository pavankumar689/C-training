class Project
{
    public static void Main(String[] args)
    {   
        //task1
        PriceSnapshot p=new PriceSnapshot{StockSymbol="NFX",Price=1000000};
        Console.WriteLine(p.StockSymbol);
        Console.WriteLine(p.Price);

        //task3
        EquityTrade2 et=new EquityTrade2();
        Console.WriteLine(et.calculatetrade());
        EquityTrade2 et2=new EquityTrade2{MarketPrice=5000};
        Console.WriteLine(et2.calculatetrade());

        //task4
        TradeRepository<EquityTrade2> t=new TradeRepository<EquityTrade2>();
        EquityTrade2 e1=new EquityTrade2{TradeId=11,StockSymbol="Tcs",Quantity=50};
        EquityTrade2 e2=new EquityTrade2{TradeId=12,StockSymbol="Amz",Quantity=60};
        t.AddTrade(e1);
        t.AddTrade(e2);
        t.ShowDetails();

        //task5
        TradeAnalytics.DisplayAnalytics();

        //task6
        double money=1000;
        Console.WriteLine(money.brokaragecalculation());
        Console.WriteLine(money.CalculateGST());   
    }
}