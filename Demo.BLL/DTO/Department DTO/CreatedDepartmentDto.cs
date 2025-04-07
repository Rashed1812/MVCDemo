using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTO.Department_DTO
{
    public class CreatedDepartmentDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        [Display(Name = "Date Of Creation")]
        public DateOnly DateOfCreation { get; set; }
        public string? Description { get; set; }
    }
}
