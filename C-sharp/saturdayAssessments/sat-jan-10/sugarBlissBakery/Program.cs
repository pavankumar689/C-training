﻿using System;

public class Chocolate
{
    public string? Flavour { get; set; }
    public int Quantity { get; set; }
    public int PricePerUnit { get; set; }
    public double TotalPrice { get; set; }
    public double DiscountedPrice { get; set; }

    public bool ValidateChocolateFlavour()
    {
        if (Flavour == "Dark" || Flavour == "Milk" || Flavour == "White")
        {
            return true;
        }
        return false;
    }
}

public class Program
{
    public static Chocolate CalculateDiscountedPrice(Chocolate chocolate)
    {
        chocolate.TotalPrice = chocolate.Quantity * chocolate.PricePerUnit;

        double discount = 0;

        if (chocolate.Flavour == "Dark")
        {
            discount = 18;
        }
        else if (chocolate.Flavour == "Milk")
        {
            discount = 12;
        }
        else if (chocolate.Flavour == "White")
        {
            discount = 6;
        }

        chocolate.DiscountedPrice =
            chocolate.TotalPrice - (chocolate.TotalPrice * discount / 100);

        return chocolate;
    }

    public static void Main()
    {
        Chocolate chocolate = new Chocolate();

        Console.WriteLine("Enter the flavour: ");
        chocolate.Flavour = Console.ReadLine();

        if (!chocolate.ValidateChocolateFlavour())
        {
            Console.WriteLine("Invalid flavour");
            return;
        }
        Console.WriteLine("Enter the quantity: ");
        chocolate.Quantity = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the price per unit: ");
        chocolate.PricePerUnit = Convert.ToInt32(Console.ReadLine());

        chocolate = CalculateDiscountedPrice(chocolate);
        Console.WriteLine("\nComplete Chocolate Details: ");
        Console.WriteLine("Flavour : " + chocolate.Flavour);
        Console.WriteLine("Quantity : " + chocolate.Quantity);
        Console.WriteLine("Price Per Unit : " + chocolate.PricePerUnit);
        Console.WriteLine("Total Price : " + chocolate.TotalPrice);
        Console.WriteLine("Discounted Price : " + chocolate.DiscountedPrice+"\n");
    }
}