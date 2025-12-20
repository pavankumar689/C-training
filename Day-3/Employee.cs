class Employee
{
    public String? Name;
    public double Salary;

    public void DisplayDetails()
    {
        Console.WriteLine($"{Name} earns {Salary}");
    }
}