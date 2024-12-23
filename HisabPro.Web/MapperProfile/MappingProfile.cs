using AutoMapper;
using HisabPro.Constants;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Web.Helper;

namespace HisabPro.Web.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SaveUserReq, User>().ReverseMap();  // This will map User <-> SaveUser
            CreateMap<User, UserRes>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.Creator.Name))
                .ForMember(dest => dest.UserRoleName, opt => opt.MapFrom(src => EnumHelper.GetEnumText((UserRoleEnum)src.UserRole)))
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => EnumHelper.GetEnumText((UserGenederEnum)src.Gender)));
            
            CreateMap<SaveCategoryReq, Category>().ReverseMap();
            CreateMap<Category, CategoryRes>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.Creator.Name))
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent != null ? src.Parent.Name : null))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => EnumHelper.GetEnumText((EnumCategoryType)src.Type)))
                .ForMember(dest => dest.SubCategories, opt => opt.MapFrom(src => src.SubCategories));

            CreateMap<SaveAccountReq, Account>().ReverseMap();  // This will map Account <-> SaveAccount
            CreateMap<Account, AccountRes>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.Creator.Name));

            CreateMap<SaveIncomeReq, Income>().ReverseMap();
            CreateMap<Income, IncomeRes>()
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.SubCategory, opt => opt.MapFrom(src => src.SubCategory.Name));

            CreateMap<SaveExpenseReq, Expense>().ReverseMap();
            CreateMap<Expense, ExpenseRes>()
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.SubCategory, opt => opt.MapFrom(src => src.SubCategory.Name));

            CreateMap<User, LoginRes>();

            CreateMap<IdNameRes, IdNameAndRefId>();
            CreateMap<SubCategoryRes, IdNameAndRefId>()
                .ForMember(dest => dest.RefId, opt => opt.MapFrom(src => src.CategoryId));

            CreateMap<Category, IdNameAndRefId>()
                 .ForMember(dest => dest.RefId, opt => opt.MapFrom(src => src.ParentId));
        }
    }
}
