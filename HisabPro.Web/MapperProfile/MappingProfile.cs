using AutoMapper;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;

namespace HisabPro.Web.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SaveAccount, Account>().ReverseMap();  // This will map Account <-> SaveAccount
            CreateMap<Account, AccountResponse>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.Creator.Name));

            CreateMap<SaveIncome, Income>().ReverseMap();
            CreateMap<Income, IncomeResponse>()
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account.Name));

            CreateMap<SaveExpense, Expense>().ReverseMap();
            CreateMap<Expense, ExpenseResponse>()
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account.Name))
                .ForMember(dest => dest.ParentCategory, opt => opt.MapFrom(src => src.ParentCategory.Name))
                .ForMember(dest => dest.ChildCategory, opt => opt.MapFrom(src => src.ChildCategory.Name));

            CreateMap<User, LoginRes>();
            CreateMap<ParentCategory, CategoryListRes>();
            CreateMap<ParentCategory, ParentCategoryRes>();
            CreateMap<ChildCategory, ChildCategoryRes>();
        }
    }
}
