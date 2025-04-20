using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models.Employee
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max Length Should be 50 Charcter")]
        [MinLength(3, ErrorMessage = "Min Length Should be More Than 5 Charcter")]
        public string Name { get; set; }
        [Range(22, 35)]
        public int Age { get; set; }
        [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",
            ErrorMessage = "Address Must be Like 123-Street-City-Country")]
        public string? Address { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
    }
}
