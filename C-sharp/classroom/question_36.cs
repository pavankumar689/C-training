class Dictionaryq
{
    public static void Main(string[] args)
    {
        Dictionary<int,float> employees=new Dictionary<int, float>();
        employees.Add(1,50000);
        employees.Add(2,100000);
        employees.Add(3,50000);
        Console.WriteLine(employees.Values.Sum());
    }
}