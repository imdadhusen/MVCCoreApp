using AutoMapper;
using HisabPro.Constants;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Helper;
using HisabPro.Services.Interfaces;

namespace HisabPro.Services.Implements
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Income> _incomeRepo;
        private readonly IRepository<Expense> _expenseRepo;
        private readonly IMapper _mapper;

        public ReportService(IRepository<Income> incomeRepo, IRepository<Expense> expenseRepo, IMapper mapper)
        {
            _incomeRepo = incomeRepo;
            _expenseRepo = expenseRepo;
            _mapper = mapper;
        }

        public async Task<PageDataRes<ReportRes>> PageData(LoadDataRequest request)
        {
            var dataQuery = applyFilterAndSort(request);
            // Apply Paging
            var pagedData = await PageDataHelper.ApplyPage<ReportRes, ReportRes>(dataQuery.AsQueryable(), request.PageData, _mapper);
            return pagedData;
        }

        public async Task<PageDataRes<ReportRes>> ExportData(ExportReq request)
        {
            var dataQuery = applyFilterAndSort(request);
            // All Page Data
            var pagedData = await PageDataHelper.ApplyAllPage<ReportRes, ReportRes>(dataQuery.AsQueryable(), request.PageData, _mapper);
            return pagedData;
        }

        private IQueryable<ReportRes> applyFilterAndSort(LoadDataRequest request)
        {
            // Fetch Income Data
            var incomes = _incomeRepo.GetPageDataWithChildrenAsync("Account", "Category", "SubCategory")
                .Select(i => new ReportRes
                {
                    Title = i.Title,
                    TransactionOn = i.IncomeOn,
                    Category = i.Category.Name,
                    SubCategory = i.SubCategory != null ? i.SubCategory.Name : null, // Handling null explicitly
                    Amount = i.Amount,
                    Account = i.Account.Name,
                    Type = EnumLocalizationHelper.Get(EnumCategoryType.Income),
                    TypeId = (int)EnumCategoryType.Income,
                    Note = i.Note
                });

            // Fetch Expense Data
            var expenses = _expenseRepo.GetPageDataWithChildrenAsync("Account", "Category", "SubCategory")
                .Select(e => new ReportRes
                {
                    Title = e.Title,
                    TransactionOn = e.ExpenseOn,
                    Category = e.Category.Name,
                    SubCategory = e.SubCategory != null ? e.SubCategory.Name : null, // Handling null explicitly
                    Amount = e.Amount,
                    Account = e.Account.Name,
                    Type = EnumLocalizationHelper.Get(EnumCategoryType.Expense),
                    TypeId = (int)EnumCategoryType.Expense,
                    Note = e.Note
                });

            // Combine Data
            var combinedData = incomes.Concat(expenses);

            // Apply Dynamic Filters
            combinedData = combinedData.ApplyDynamicFilters(request.Filter.Fields);

            // Apply Sorting
            combinedData = PageDataHelper.ApplySort(combinedData, request.PageData);

            return combinedData;
        }
    }
}
