using AutoMapper;
using NetTask8.BusinessLogic.DataTransferObjects.Approval;
using NetTask8.BusinessLogic.DataTransferObjects.Employee;
using NetTask8.BusinessLogic.DataTransferObjects.File;
using NetTask8.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.BusinessLogic.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreatedFileDto, FileField>();
            CreateMap<FileField, DetailedFileDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.Name));
            CreateMap<ApprovalDto, Approval>().ReverseMap();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
