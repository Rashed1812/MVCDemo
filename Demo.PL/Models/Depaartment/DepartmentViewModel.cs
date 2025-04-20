using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models.Depaartment
{
    public class DepartmentViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        [Display(Name = "Date Of Creation")]
        public DateOnly DateOfCreation { get; set; }
        public string? Description { get; set; }
    }
}
