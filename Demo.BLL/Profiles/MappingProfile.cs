using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BLL.DTO.Employee_DTO;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared;

namespace Demo.BLL.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Gender , options => options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmployeeType , options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dest=>dest.Department , options=>options.MapFrom(src => src.Department !=null ? src.Department.Name : null));


            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.HiringDate ,options => options.MapFrom(src=> DateOnly.FromDateTime(src.HiringDate)))
                .ForMember(dest => dest.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));

            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(dsc=>dsc.HiringDate , option=> option.MapFrom(src=>src.HiringDate.ToDateTime(TimeOnly.MinValue)));
            
            CreateMap<UpdateEmployeeDto, Employee>()
                .ForMember(dsc => dsc.HiringDate, option => option.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue))); ;


        }
    }
}
