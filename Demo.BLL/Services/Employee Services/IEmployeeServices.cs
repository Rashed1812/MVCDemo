using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.DTO.Employee_DTO;

namespace Demo.BLL.Services.Employee_Services
{
    public interface IEmployeeServices
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking); 
        int AddEmployee(CreatedEmployeeDto employeeDto);
        bool DeleteEmployee(int id);
        EmployeeDetailsDto? GetEmployeeById(int id);
        int UpdateEmployee(UpdateEmployeeDto employeeDto);
    }
}
