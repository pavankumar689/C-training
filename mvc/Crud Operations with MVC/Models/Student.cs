namespace Crud_Operations_with_MVC.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        [Display(Name = "Student Id")]
        [Required(ErrorMessage = "Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be a positive number")]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;
    }
}
