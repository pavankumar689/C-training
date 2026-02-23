using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace MoviesApi.Entities
{
    public class Movies
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Mandatory")]
        [StringLength(40)]
        public required string Name { get; set; }

        [Required]
        [Range(1,100)]
        public decimal Price { get; set; }

        [ValidateNever]
        public Genre? Genre { get; set; }

        public int GenreId { get; set; }

        public DateOnly ReleaseDate { get; set; }

    }
}
