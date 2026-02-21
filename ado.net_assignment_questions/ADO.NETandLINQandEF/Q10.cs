using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int Salary { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee { Id=1, Name="Arun", Department="IT", Salary=60000 },
            new Employee { Id=2, Name="Meera", Department="HR", Salary=45000 },
            new Employee { Id=3, Name="John", Department="IT", Salary=75000 }
        };

        Dictionary<string, List<Employee>> result =
            employees
            .Where(e => e.Salary > 50000)
            .GroupBy(e => e.Department)
            .ToDictionary(g => g.Key, g => g.ToList());

        foreach (var dept in result)
        {
            Console.Write(dept.Key + " -> ");
            foreach (var emp in dept.Value)
            {
                Console.Write(emp.Name + " ");
            }
            Console.WriteLine();
        }
    }
}