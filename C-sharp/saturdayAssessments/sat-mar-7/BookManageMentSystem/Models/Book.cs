using System.ComponentModel.DataAnnotations;

namespace BookManageMentSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [StringLength(15, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 15 characters")]
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }
}
