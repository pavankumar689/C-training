using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Aadhaar Number is required")]
        [RegularExpression(@"^[2-9]{1}[0-9]{3}\s[0-9]{4}\s[0-9]{4}$", ErrorMessage = "Invalid Aadhaar format (XXXX XXXX XXXX)")]
        public string Aadhaar { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Joining Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(10000, 1000000, ErrorMessage = "Salary must be between 10k and 10L")]
        public decimal Salary { get; set; }

        public byte[]? Photo { get; set; }
    }
}