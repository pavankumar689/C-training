using BookManageMentSystem.Models;
namespace BookManageMentSystem.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        void AddBook(Book book);
        List<Book> GetBooksByPrice(double price);
        Book? GetBookByName(string name);
    }
}
