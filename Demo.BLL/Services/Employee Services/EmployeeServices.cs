using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BLL.DTO.Employee_DTO;
using Demo.BLL.Factories;
using Demo.DAL.Data.Repositries.Interfaces;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.BLL.Services.Employee_Services
{
    public class EmployeeServices(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeServices
    {


        public IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking = false)
        {
            var employees = _employeeRepository.GetAll(WithTracking);
            //return employees.Select(e => e.ToEmployeeDto());
            var employeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeesDto;
        }
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return employee is null ? null : _mapper.Map<Employee,EmployeeDetailsDto>(employee);
        }
        public int AddEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto,Employee>(employeeDto);
            return _employeeRepository.Add(employee);
        }

        public int UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            //var employee = _mapper.Map<UpdateEmployeeDto,Employee>(employeeDto);
            return _employeeRepository.Update(_mapper.Map<UpdateEmployeeDto, Employee>(employeeDto));
        }
        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is null)
            {
                return false;
            }
            else
            {
               int result =  _employeeRepository.Delete(employee);
                return result > 0 ? true:false;
            }
        }
    }
}
