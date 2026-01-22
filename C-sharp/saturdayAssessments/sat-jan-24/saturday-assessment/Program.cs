using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        try
        {
            var assembly = Assembly.LoadFrom(
                @"D:\C#_trining\C-sharp\dllfile\bin\Debug\net10.0\dllfile.dll");

            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine($"\nClass: {type.FullName}");

                foreach (var method in type.GetMethods(
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.Static))
                {
                    Console.WriteLine($"  {method.Name}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
