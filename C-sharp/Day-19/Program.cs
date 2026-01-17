public interface IFilm
{
    string Title { get; set; }
    string Director { get; set; }
    int Year { get; set; }
}

public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilm(string query);
    int GetTotalFilmCount();
}
public class Film : IFilm
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
}
public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> _films;

    public FilmLibrary()
    {
        _films = new List<IFilm>();
    }

    public void AddFilm(IFilm film)
    {
        _films.Add(film);
    }

    public void RemoveFilm(string title)
    {
        var filmToRemove = _films.FirstOrDefault(f => f.Title == title);

        if (filmToRemove != null)
        {
            _films.Remove(filmToRemove);
        }
        else
        {
            Console.WriteLine("Film with this title is not present");
        }
    }

    public List<IFilm> GetFilms()
    {
        return _films;
    }

    public List<IFilm> SearchFilm(string query)
    {
        return _films
            .Where(f => f.Title.Contains(query, StringComparison.OrdinalIgnoreCase)
                     || f.Director.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public int GetTotalFilmCount()
    {
        return _films.Count;
    }
}
class Program
{
    static void Main()
    {
        IFilmLibrary library = new FilmLibrary();

        library.AddFilm(new Film
        {
            Title = "Inception",
            Director = "Christopher Nolan",
            Year = 2010
        });

        library.AddFilm(new Film
        {
            Title = "Interstellar",
            Director = "Christopher Nolan",
            Year = 2014
        });

        Console.WriteLine("All Films:");
        foreach (var film in library.GetFilms())
        {
            Console.WriteLine($"{film.Title} - {film.Director} - {film.Year}");
        }

        Console.WriteLine("\nSearch Results (Nolan):");
        var results = library.SearchFilm("Nolan");
        foreach (var film in results)
        {
            Console.WriteLine(film.Title);
        }

        library.RemoveFilm("Inception");

        Console.WriteLine($"\nTotal Films: {library.GetTotalFilmCount()}");
    }
}
