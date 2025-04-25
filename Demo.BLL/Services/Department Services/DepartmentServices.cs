using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.DTO.Department_DTO;
using Demo.BLL.Factories;
using Demo.DAL.Data.Repositries.Interfaces;
using Demo.DAL.Models;

namespace Demo.BLL.Services
{
    //primary Constrctor
    public class DepartmentServices(IUnitOfWork _unitOfWork) : IDepartmentServices
    {
        //Get All 
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            #region Manual Mapping
            //1..Manual Mapping
            //var departmentsToReturn = departments.Select(D => new DepartmentDto()
            //{
            //    Id = D.Id,
            //    Name = D.Name,
            //    Code = D.Code,
            //    Description = D.Description,
            //    DateOfCreation = DateOnly.FromDateTime(D.CreatedOn.Value)
            //});
            //return departmentsToReturn; 
            #endregion

            //2..Using Extinsion Method
            return departments.Select(D => D.ToDepartmentDto());
        }

        //Get By Id
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            #region Manual Mapping
            //if (department == null)
            //{
            //    return null;
            //}
            //else
            //{
            //    var departmentToReturn = new DepartmentDetailsDto()
            //    {
            //        Id = department.Id,
            //        Name = department.Name,
            //        Description = department.Description,
            //        CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value)
            //    };
            //    return departmentToReturn; 
            //}

            //..manual Mapping
            //return department is null ? null : new DepartmentDetailsDto()
            //{
            //    Id = department.Id,
            //    Name = department.Name,
            //    Code = department.Code,
            //    Description = department.Description,
            //    CreatedBy = department.CreatedBy,
            //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value)
            //}; 
            #endregion

            //2..Using Extinsion Method
            return department is null ? null : department.ToDepartmentDetailsDto();
        }

        //Create Department (Add)
        //int Type => It's return int to check how many rows is affected
        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var deparmtent = departmentDto.ToEntity();
            _unitOfWork.DepartmentRepository.Add(deparmtent);
            return _unitOfWork.SaveChanges();
        }

        //Update For Department 
        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            _unitOfWork.DepartmentRepository.Update(department);
            return _unitOfWork.SaveChanges();
        }

        //Delete For Department
        public bool DeleteDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return false;
            }
            else
            {
                 _unitOfWork.DepartmentRepository.Delete(department);
                //return result > 0 ? true : false;
                return _unitOfWork.SaveChanges() > 0 ? true : false;
            }
        }
    }
}
