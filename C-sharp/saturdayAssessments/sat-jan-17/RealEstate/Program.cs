using System;
using System.Collections.Generic;

class RealEstateListing
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Location { get; set; }

    public RealEstateListing(int id, string title, string description, int price, string location)
    {
        ID = id;
        Title = title;
        Description = description;
        Price = price;
        Location = location;
    }
}

class RealEstateApp
{
    private List<RealEstateListing> listings = new List<RealEstateListing>();

    public void AddListing(RealEstateListing listing)
    {
        listings.Add(listing);
    }

    public void RemoveListing(int listingID)
    {
        for (int i = 0; i < listings.Count; i++)
        {
            if (listings[i].ID == listingID)
            {
                listings.RemoveAt(i);
                break;
            }
        }
    }

    public void UpdateListing(RealEstateListing listing)
    {
        for (int i = 0; i < listings.Count; i++)
        {
            if (listings[i].ID == listing.ID)
            {
                listings[i] = listing;
                break;
            }
        }
    }

    public List<RealEstateListing> GetListings()
    {
        return listings;
    }

    public List<RealEstateListing> GetListingsByLocation(string location)
    {
        List<RealEstateListing> result = new List<RealEstateListing>();

        foreach (var listing in listings)
        {
            if (listing.Location == location)
            {
                result.Add(listing);
            }
        }

        return result;
    }

    public List<RealEstateListing> GetListingsByPriceRange(int minPrice, int maxPrice)
    {
        List<RealEstateListing> result = new List<RealEstateListing>();

        foreach (var listing in listings)
        {
            if (listing.Price >= minPrice && listing.Price <= maxPrice)
            {
                result.Add(listing);
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        RealEstateApp app = new RealEstateApp();

        app.AddListing(new RealEstateListing(1, "Villa", "Luxury villa", 5000000, "Bangalore"));
        app.AddListing(new RealEstateListing(2, "Apartment", "2BHK flat", 3000000, "Bangalore"));
        app.AddListing(new RealEstateListing(3, "Plot", "Open land", 2000000, "Chennai"));

        var bangaloreListings = app.GetListingsByLocation("Bangalore");

        foreach (var l in bangaloreListings)
        {
            Console.WriteLine(l.Title);
        }

        var priceRange = app.GetListingsByPriceRange(2500000, 5500000);

        foreach (var l in priceRange)
        {
            Console.WriteLine(l.Title);
        }

        app.RemoveListing(2);

        Console.WriteLine(app.GetListings().Count);
    }
}