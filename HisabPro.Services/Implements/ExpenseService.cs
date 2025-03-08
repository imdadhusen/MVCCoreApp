using AutoMapper;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Helper;

namespace HisabPro.Services.Implements
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepository<Expense> _expenseRepo;
        private readonly IMapper _mapper;
        private readonly ISharedViewLocalizer _localizer;

        public ExpenseService(IRepository<Expense> expenseRepo, IMapper mapper, ISharedViewLocalizer localizer)
        {
            _expenseRepo = expenseRepo;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<SaveExpenseReq> GetByIdAsync(int id)
        {
            var account = await _expenseRepo.GetByIdAsync(id);
            var map = _mapper.Map<SaveExpenseReq>(account);
            return map;
        }

        public async Task<ResponseDTO<List<ExpenseRes>>> GetAll()
        {
            var expense = await _expenseRepo.GetAllWithChildrenAsync("Account", "Category", "SubCategory"); //"Creator", "Modifier"
            var map = _mapper.Map<List<ExpenseRes>>(expense);
            return new ResponseDTO<List<ExpenseRes>>(System.Net.HttpStatusCode.OK, _localizer.Get(ResourceKey.LabelApiDataRetrived), map);
        }

        public async Task<PageDataRes<ExpenseRes>> PageData(LoadDataRequest request)
        {
            var dataQuery = applyFilterAndSort(request);
            var pagedData = await PageDataHelper.ApplyPage<Expense, ExpenseRes>(dataQuery, request.PageData, _mapper);
            return pagedData;
        }
        public async Task<PageDataRes<ExpenseRes>> ExportData(ExportReq request)
        {
            var dataQuery = applyFilterAndSort(request);
            // All Page Data
            var pagedData = await PageDataHelper.ApplyAllPage<Expense, ExpenseRes>(dataQuery.AsQueryable(), request.PageData, _mapper);
            return pagedData;
        }

        public async Task<ResponseDTO<DataImportRes>> AddRangeAsync(IEnumerable<SaveExpenseReq> expenses)
        {
            var map = _mapper.Map<List<Expense>>(expenses);
            var result = await _expenseRepo.AddRangeAsync(map);
            return new ResponseDTO<DataImportRes>(System.Net.HttpStatusCode.OK, _localizer.Get(ResourceKey.LabelApiDataImportSuccess), new DataImportRes { TotalRecords = result });
        }

        public async Task<ResponseDTO<ExpenseRes>> SaveAsync(SaveExpenseReq req)
        {
            var map = _mapper.Map<Expense>(req);
            var result = await _expenseRepo.SaveAsync(map);
            var response = _mapper.Map<ExpenseRes>(result);
            return new ResponseDTO<ExpenseRes>(System.Net.HttpStatusCode.OK, _localizer.Get(ResourceKey.LabelApiSave), response);
        }

        public async Task<ResponseDTO<bool>> DeleteAsync(int id)
        {
            var result = await _expenseRepo.DeleteAsync(id);
            return new ResponseDTO<bool>(System.Net.HttpStatusCode.OK, _localizer.Get(ResourceKey.LabelApiDelete), result);
        }

        private IQueryable<Expense> applyFilterAndSort(LoadDataRequest request)
        {
            var data = _expenseRepo.GetPageDataWithChildrenAsync("Account", "Category", "SubCategory");
            data = data.ApplyDynamicFilters(request.Filter.Fields);

            data = PageDataHelper.ApplySort(data, request.PageData);
            return data;
        }
    }
}
