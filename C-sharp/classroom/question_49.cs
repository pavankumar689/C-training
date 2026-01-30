using System;

abstract class Employee
{
    public abstract decimal GetPay();
}

class HourlyEmployee : Employee
{
    decimal rate;
    decimal hours;

    public HourlyEmployee(decimal rate, decimal hours)
    {
        this.rate = rate;
        this.hours = hours;
    }

    public override decimal GetPay()
    {
        return rate * hours;
    }
}

class SalariedEmployee : Employee
{
    decimal salary;

    public SalariedEmployee(decimal salary)
    {
        this.salary = salary;
    }

    public override decimal GetPay()
    {
        return salary;
    }
}

class CommissionEmployee : Employee
{
    decimal commission;
    decimal baseSalary;

    public CommissionEmployee(decimal commission, decimal baseSalary)
    {
        this.commission = commission;
        this.baseSalary = baseSalary;
    }

    public override decimal GetPay()
    {
        return baseSalary + commission;
    }
}

class Payroll
{
    static decimal TotalPayroll(string[] employees)
    {
        decimal total = 0;

        foreach (string e in employees)
        {
            string[] parts = e.Split(' ');
            Employee emp = null;

            if (parts[0] == "H")
                emp = new HourlyEmployee(decimal.Parse(parts[1]), decimal.Parse(parts[2]));
            else if (parts[0] == "S")
                emp = new SalariedEmployee(decimal.Parse(parts[1]));
            else if (parts[0] == "C")
                emp = new CommissionEmployee(decimal.Parse(parts[1]), decimal.Parse(parts[2]));

            if (emp != null)
                total += emp.GetPay();
        }

        return Math.Round(total, 2, MidpointRounding.AwayFromZero);
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] employees = new string[n];

        for (int i = 0; i < n; i++)
            employees[i] = Console.ReadLine();

        Console.WriteLine(TotalPayroll(employees));
    }
}
