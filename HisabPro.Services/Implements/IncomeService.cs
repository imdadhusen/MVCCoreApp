using AutoMapper;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Interfaces;
using HisabPro.Constants;
using HisabPro.Services.Helper;

namespace HisabPro.Services.Implements
{
    public class IncomeService : IIncomeService
    {
        private readonly IRepository<Income> _incomeRepo;
        private readonly IMapper _mapper;

        public IncomeService(IMapper mapper, IRepository<Income> incomeRepo)
        {
            _mapper = mapper;
            _incomeRepo = incomeRepo;
        }

        public async Task<SaveIncomeReq> GetByIdAsync(int id)
        {
            var account = await _incomeRepo.GetByIdAsync(id);
            var map = _mapper.Map<SaveIncomeReq>(account);
            return map;
        }

        public async Task<ResponseDTO<List<IncomeRes>>> GetAll()
        {
            var accounts = await _incomeRepo.GetAllWithChildrenAsync("Account", "Category", "SubCategory"); //"Creator", "Modifier"
            var map = _mapper.Map<List<IncomeRes>>(accounts);
            return new ResponseDTO<List<IncomeRes>>(System.Net.HttpStatusCode.OK, AppConst.ApiMessage.DataRetrived, map);
        }
        public async Task<PageDataRes<IncomeRes>> PageData(LoadDataRequest request)
        {
            var data = _incomeRepo.GetPageDataWithChildrenAsync("Account", "Category", "SubCategory");
            data = data.ApplyDynamicFilters(request.Filters);
            data = PageDataHelper.ApplySort(data, request.PageData);
            var pagedData = await PageDataHelper.ApplyPage<Income, IncomeRes>(data, request.PageData, _mapper);
            return pagedData;
        }
        public async Task<ResponseDTO<DataImportRes>> AddRangeAsync(IEnumerable<SaveIncomeReq> incomes)
        {
            var map = _mapper.Map<List<Income>>(incomes);
            var result = await _incomeRepo.AddRangeAsync(map);
            return new ResponseDTO<DataImportRes>(System.Net.HttpStatusCode.OK, AppConst.ApiMessage.DataImportSuccess, new DataImportRes { TotalRecords = result });
        }
        public async Task<ResponseDTO<IncomeRes>> SaveAsync(SaveIncomeReq req)
        {
            var map = _mapper.Map<Income>(req);
            var result = await _incomeRepo.SaveAsync(map);
            var response = _mapper.Map<IncomeRes>(result);
            return new ResponseDTO<IncomeRes>(System.Net.HttpStatusCode.OK, AppConst.ApiMessage.Save, response);
        }

        public async Task<ResponseDTO<bool>> DeleteAsync(int id)
        {
            var result = await _incomeRepo.DeleteAsync(id);
            return new ResponseDTO<bool>(System.Net.HttpStatusCode.OK, AppConst.ApiMessage.Delete, result);
        }
    }
}
