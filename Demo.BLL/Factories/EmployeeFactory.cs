using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.DTO.Department_DTO;
using Demo.BLL.DTO.Employee_DTO;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.BLL.Factories
{
    static public class EmployeeFactory
    {
        public static EmployeeDto ToEmployeeDto(this Employee employee)
        {
            return new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Email = employee.Email,
                Gender = employee.Gender.ToString(),
                EmployeeType = employee.EmployeeType.ToString()
            };
        }
        public static EmployeeDetailsDto ToEmployeeDetailsDto(this Employee employeeDto) 
        {
            return new EmployeeDetailsDto()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                Gender = employeeDto.Gender.ToString(),
                EmployeeType = employeeDto.EmployeeType.ToString(),
                HiringDate = DateOnly.FromDateTime(employeeDto.HiringDate),
                CreatedBy =1,
                CreatedOn= employeeDto.CreatedOn.Value,
                LastModifiedBy = 1,
                LastModifiedOn = employeeDto.LastModifiedOn.Value

            };
        }
        public static Employee ToEntity(this CreatedEmployeeDto employeeDto)
        {
            return new Employee()
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                IsActive = employeeDto.IsActive,
                CreatedBy = employeeDto.CreatedBy,
                LastModifiedBy = employeeDto.LastModifiedBy,
            };
        }
        public static Employee ToEntity(this UpdateEmployeeDto employeeDto)
        {
            return new Employee()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                IsActive = employeeDto.IsActive,
                CreatedBy = employeeDto.CreatedBy,
                LastModifiedBy = employeeDto.LastModifiedBy,
                HiringDate = employeeDto.HiringDate.ToDateTime(TimeOnly.MinValue)
            };
        }
    }
}
