using BookManageMentSystem.Data;
using BookManageMentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManageMentSystem.Repositories
{
    public class DatabaseBookRepository : IBookRepository
    {
        private readonly BookDbContext _context;

        public DatabaseBookRepository(BookDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public List<Book> GetBooksByPrice(double price)
        {
            return _context.Books.Where(b => b.Price <= price).ToList();
        }

        public Book? GetBookByName(string name)
        {
            return _context.Books.FirstOrDefault(b => b.Name.ToLower() == name.ToLower());
        }
    }
}
