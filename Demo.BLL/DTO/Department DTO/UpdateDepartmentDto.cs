using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTO.Department_DTO
{
    public class UpdateDepartmentDto
    {
        //Add Id To Check If id is In DB or Not
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateOnly DateOfCreation { get; set; }
        public string? Description { get; set; }
    }
}
