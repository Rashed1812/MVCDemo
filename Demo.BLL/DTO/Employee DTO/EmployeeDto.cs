using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared;

namespace Demo.BLL.DTO.Employee_DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; }
        public string? Department { get; set; }
    }
}
