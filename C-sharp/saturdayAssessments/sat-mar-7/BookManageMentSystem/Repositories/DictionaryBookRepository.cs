using BookManageMentSystem.Models;
namespace BookManageMentSystem.Repositories
{
    public class DictionaryBookRepository : IBookRepository
    {
        private Dictionary<int, Book> books = new Dictionary<int, Book>();

        public DictionaryBookRepository()
        {
            books.Add(1, new Book { BookId = 1, Name = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 15.99 });
            books.Add(2, new Book { BookId = 2, Name = "To Kill a Mockingbird", Author = "Harper Lee", Price = 18.50 });
            books.Add(3, new Book { BookId = 3, Name = "1984", Author = "George Orwell", Price = 14.99 });
            books.Add(4, new Book { BookId = 4, Name = "Pride and Prejudice", Author = "Jane Austen", Price = 12.99 });
            books.Add(5, new Book { BookId = 5, Name = "The Catcher in the Rye", Author = "J.D. Salinger", Price = 16.75 });
            books.Add(6, new Book { BookId = 6, Name = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", Price = 22.99 });
            books.Add(7, new Book { BookId = 7, Name = "The Hobbit", Author = "J.R.R. Tolkien", Price = 19.99 });
            books.Add(8, new Book { BookId = 8, Name = "The Lord of the Rings", Author = "J.R.R. Tolkien", Price = 35.99 });
        }

        public List<Book> GetAllBooks()
        {
            return books.Values.ToList();
        }

        public void AddBook(Book book)
        {
            books[book.BookId] = book;
        }

        public List<Book> GetBooksByPrice(double price)
        {
            return books.Values.Where(b => b.Price <= price).ToList();
        }

        public Book? GetBookByName(string name)
        {
            return books.Values.FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
