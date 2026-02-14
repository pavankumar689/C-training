class Shipment
{
    public string ShipmentCode{get;set;}
    public string TransportMode{get;set;}
    public double Weight{get;set;}
    public int StorageDays{get;set;}

}

class ShipmentDetails:Shipment
{
    public bool ValidateShipmentCode(string code)
    {
        if (code.Length != 7)
        {
            return false;
        }
        if (code.Substring(0, 3) != "GC#")
        {
            return false;
        }
        for(int i = 3; i < code.Length; i++)
        {
            if (!char.IsDigit(code[i]))
            {
                return false;
            }
        }
        return true;
    }
    public double CalculateTotalCost(double rateperkg)
    {
        double TotalCost=(Weight*rateperkg)+Math.Sqrt(StorageDays);
        return Math.Round(TotalCost,2);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        ShipmentDetails s=new ShipmentDetails();
        Console.Write("InputID:");
        string inputid=Console.ReadLine();
        if (!s.ValidateShipmentCode(inputid))
        {
            Console.WriteLine("Invalid Shipment Code");
            return;
        }
        s.ShipmentCode=inputid;
        Console.Write("Mode: ");
        string Mode=Console.ReadLine();
        s.TransportMode=Mode;
        double rate=0;
        if (Mode == "Air")
        {
            rate=50;
        }else if (Mode == "Sea")
        {
            rate=15;
        }else if (Mode == "Land")
        {
            rate=25;
        }
        else
        {
            Console.WriteLine("Enter a valid Mode");
            return;
        }
        Console.Write("Weight: ");
        double weight=Convert.ToDouble(Console.ReadLine());
        s.Weight=weight;
        Console.Write("Storage: ");
        int storage=Convert.ToInt32(Console.ReadLine());
        s.StorageDays=storage;
        Console.WriteLine($"Expected Output: The total shipping cost is {s.CalculateTotalCost(rate)}");
    }
}
