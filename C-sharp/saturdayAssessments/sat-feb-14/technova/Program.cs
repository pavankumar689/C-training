using System;

namespace TechNovaRetailSolutions
{
    public abstract class Product
    {
        public string ProductName { get; set; }="";
        public double Price { get; set; }
    }

    public class Electronics : Product
    {
        public string Brand { get; set; }="";
        public string Model { get; set; }="";
        public int WarrantyPeriod { get; set; }
        public double PowerUsage { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public int RAM { get; set; }
        public int Storage { get; set; }

        public override string ToString()
        {
            return $"Electronics Name: {ProductName}, Price: {Price}, Brand: {Brand}, Model: {Model}, Warranty: {WarrantyPeriod}, Power: {PowerUsage}, MfgDate: {ManufacturingDate.ToShortDateString()}, RAM: {RAM}GB, Storage: {Storage}GB";
        }
    }


    public class Grocery : Product
    {
        public DateTime ExpiryDate { get; set; }
        public double Weight { get; set; }
        public bool IsOrganic { get; set; }
        public double StorageTemperature { get; set; }

        public override string ToString()
        {
            return $"Grocery Name: {ProductName}, Price: {Price}, Expiry: {ExpiryDate.ToShortDateString()}, Weight: {Weight}kg, Organic: {IsOrganic}, Temp: {StorageTemperature}";
        }
    }


    public class Clothing : Product
    {
        public string Size { get; set; }="";
        public string FabricType { get; set; }="";
        public string Gender { get; set; }="";
        public string Color { get; set; }="";

        public override string ToString()
        {
            return $"Clothing Name: {ProductName}, Price: {Price}, Size: {Size}, Fabric: {FabricType}, Gender: {Gender}, Color: {Color}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Electronics laptop = new Electronics()
            {
                ProductName = "Laptop",
                Price = 80000,
                Brand = "Dell",
                Model = "G15",
                WarrantyPeriod = 24,
                PowerUsage = 180,
                ManufacturingDate = DateTime.Now,
                RAM = 16,
                Storage = 512
            };

            Grocery rice = new Grocery()
            {
                ProductName = "Rice",
                Price = 1200,
                ExpiryDate = DateTime.Now.AddMonths(6),
                Weight = 5,
                IsOrganic = true,
                StorageTemperature = 20
            };

            Clothing shirt = new Clothing()
            {
                ProductName = "Shirt",
                Price = 1500,
                Size = "M",
                FabricType = "Cotton",
                Gender = "Men",
                Color = "Blue"
            };

            Console.WriteLine(laptop);
            Console.WriteLine(rice);
            Console.WriteLine(shirt);
        }
    }
}
