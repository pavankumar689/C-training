using System;

class CircleArea
{
    static double CalculateArea(double radius)
    {
        double area = Math.PI * radius * radius;

        return Math.Round(area, 2, MidpointRounding.AwayFromZero);
    }

    static void Main(string[] args)
    {
        Console.Write("Enter radius: ");
        double radius = Convert.ToDouble(Console.ReadLine());

        double result = CalculateArea(radius);

        Console.WriteLine("Area of circle: " + result);
    }
}
