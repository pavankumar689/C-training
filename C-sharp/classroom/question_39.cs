using System;

class FeetToCentimeters
{
    static double ConvertFeetToCentimeters(int feet)
    {
        double centimeters = feet * 30.48;

    
        return Math.Round(centimeters, 2, MidpointRounding.AwayFromZero);
    }

    static void Main(string[] args)
    {
        Console.Write("Enter feet: ");
        int feet = Convert.ToInt32(Console.ReadLine());

        double result = ConvertFeetToCentimeters(feet);

        Console.WriteLine("Centimeters: " + result);
    }
}
