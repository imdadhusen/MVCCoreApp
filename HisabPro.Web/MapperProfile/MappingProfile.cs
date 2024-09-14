using AutoMapper;
using HisabPro.DTO.Model;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;

namespace HisabPro.Web.MapperProfile
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

            CreateMap<User, LoginRes>();

            CreateMap<ParentCategory, CategoryListRes>();
            CreateMap<ParentCategory, ParentCategoryRes>();
            CreateMap<ChildCategory, ChildCategoryRes>();
        }
    }
}
