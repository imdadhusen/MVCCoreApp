using AutoMapper;
using HisabPro.DTO;
using HisabPro.Entities;

namespace HisabPro.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EmployeeName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.EmployeeAddress))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department));
            CreateMap<Address, AddressDTO>()
                .ForMember(dest => dest.AddressInfo, opt => opt.MapFrom(src => src.AddressDetail));
            CreateMap<Department, DepartmentDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DepartmentName));
        }
    }
}
