using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BLL.DTO.Employee_DTO;
using Demo.BLL.Factories;
using Demo.BLL.Services.AttachmentServices;
using Demo.DAL.Data.Repositries.Interfaces;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.BLL.Services.Employee_Services
{
    public class EmployeeServices(IUnitOfWork _unitOfWork, IMapper _mapper,
        IAttachmentService _attachmentServices) : IEmployeeServices
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking = false)
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll(WithTracking);
            //return employees.Select(e => e.ToEmployeeDto());
            var employeeDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeeDto;
        }
        public IEnumerable<EmployeeDto> SearchEmployeesByName(string name)
        {
            var employee = _unitOfWork.EmployeeRepository.GetEmployeeByName(name.ToLower());
            var employeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employee);
            return employeesDto;
        }
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            return employee is null ? null : _mapper.Map<Employee,EmployeeDetailsDto>(employee);
        }
        public int AddEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto,Employee>(employeeDto);

            if (employeeDto.Image is not null)
            {
               employee.ImageName = _attachmentServices.Upload(employeeDto.Image, "Images");
            }

            _unitOfWork.EmployeeRepository.Add(employee);
            return _unitOfWork.SaveChanges();
        }

        public int UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            Employee employee = new Employee();
            //var employee = _mapper.Map<UpdateEmployeeDto,Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Update(_mapper.Map<UpdateEmployeeDto, Employee>(employeeDto));
            if (employeeDto.Image is not null)
            {
                employee.ImageName = _attachmentServices.Upload(employeeDto.Image, "Images");
            }
            return _unitOfWork.SaveChanges();
        }
        public bool DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee is null)
            {
                return false;
            }
            else
            {
                _unitOfWork.EmployeeRepository.Delete(employee);
                return _unitOfWork.SaveChanges() > 0 ? true : false;
            }
        }
    }
}
