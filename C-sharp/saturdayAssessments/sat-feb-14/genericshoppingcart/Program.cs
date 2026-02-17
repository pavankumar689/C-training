using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public override bool Equals(object obj)
    {
        return obj is Product p && p.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

public class ShoppingCart<T> where T : Product
{
    private Dictionary<T, int> _cartItems = new();

    public void AddToCart(T product, int quantity)
    {
        if (_cartItems.ContainsKey(product))
            _cartItems[product] += quantity;
        else
            _cartItems[product] = quantity;
    }

    public double CalculateTotal(Func<T, double, double> discountCalculator = null)
    {
        double total = 0;

        foreach (var item in _cartItems)
        {
            double price = item.Key.Price * item.Value;

            if (discountCalculator != null)
                price = discountCalculator(item.Key, price);

            total += price;
        }

        return total;
    }

    public List<T> GetTopExpensiveItems(int n)
    {
        return _cartItems.Keys
                         .OrderByDescending(p => p.Price)
                         .Take(n)
                         .ToList();
    }
}
