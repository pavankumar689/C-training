using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; } = true;
}

public class Catalog<T> where T : Book
{
    private List<T> _items = new();
    private HashSet<string> _isbnSet = new();
    private SortedDictionary<string, List<T>> _genreIndex = new();

    public bool AddItem(T item)
    {
        if (_isbnSet.Contains(item.ISBN))
            return false;

        _isbnSet.Add(item.ISBN);
        _items.Add(item);

        if (!_genreIndex.ContainsKey(item.Genre))
            _genreIndex[item.Genre] = new List<T>();

        _genreIndex[item.Genre].Add(item);

        return true;
    }

    public List<T> this[string genre]
    {
        get
        {
            return _genreIndex.ContainsKey(genre)
                ? _genreIndex[genre]
                : new List<T>();
        }
    }

    public IEnumerable<T> FindBooks(Func<T, bool> predicate)
    {
        return _items.Where(predicate);
    }
}
