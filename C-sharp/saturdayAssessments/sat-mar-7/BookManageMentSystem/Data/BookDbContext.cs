using BookManageMentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManageMentSystem.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Book entity
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.BookId);
                entity.Property(b => b.Name).IsRequired().HasMaxLength(15);
                entity.Property(b => b.Author).IsRequired().HasMaxLength(100);
                entity.Property(b => b.Price).HasColumnType("decimal(18,2)");
            });

            // Seed initial data
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Name = "Great Gatsby", Author = "F. Scott Fitzgerald", Price = 15.99 },
                new Book { BookId = 2, Name = "Mockingbird", Author = "Harper Lee", Price = 18.50 },
                new Book { BookId = 3, Name = "1984", Author = "George Orwell", Price = 14.99 },
                new Book { BookId = 4, Name = "Pride & Prej.", Author = "Jane Austen", Price = 12.99 },
                new Book { BookId = 5, Name = "Catcher", Author = "J.D. Salinger", Price = 16.75 },
                new Book { BookId = 6, Name = "Harry Potter", Author = "J.K. Rowling", Price = 22.99 },
                new Book { BookId = 7, Name = "The Hobbit", Author = "J.R.R. Tolkien", Price = 19.99 },
                new Book { BookId = 8, Name = "LOTR", Author = "J.R.R. Tolkien", Price = 35.99 }
            );
        }
    }
}