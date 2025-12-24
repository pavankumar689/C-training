struct StockPrice
{
    public string StockSymbol;
    public int Price;
}

class Trade
{
    public int TradeId{get;set;}
    public string? Symbol{get;set;}

    public F PrintData<F>(F data)
    {
        return data;
    }
}

class Portfolio
{
    public string? Name;

    public override bool Equals(object obj)
    {
        Portfolio p = obj as Portfolio;
        return p != null && p.Name == Name;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}

class Trade1 { }

class EquityTrade : Trade1 { }

class Calculator
{
    public T Calculate<T>(T a, T b)
    {
        return (dynamic)a+b;
    }
}
