class Constructor
{
    int Age;
    public Constructor(int age)
    {
        Age =age;
    }
}

class ChildConstructor : Constructor
{
    String Name;
    double Balance;
    double Roi;
    public ChildConstructor(int age,String name,double balance,double roi):base(age)
    {
        Name=name;
        Balance=balance;
        Roi=roi;
    }
}

class Product
{
    public string? Name;

    public Product() { }

    public int Price{get;set;}

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
}

class EmployeeDirectory
{
    private Dictionary<int, string> employees = new Dictionary<int, string>();

    public string this[int id]
    {
        get { return employees[id]; }
        set { employees[id] = value; }
    }

    public string this[string name]
    {
        get
        {
            return employees.FirstOrDefault(e => e.Value == name).Value;
        }
    }
}