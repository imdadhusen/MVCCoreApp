using AutoMapper;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Interfaces;
using HisabPro.Constants;
using HisabPro.Services.Helper;

namespace HisabPro.Services.Implements
{
    public class AccountService : IAccountService
    {
        private readonly UpdateRepository<Account, AccountResponse> _updateRepo;
        private readonly IRepository<Account> _accountRepo;
        private readonly IMapper _mapper;

        public AccountService(UpdateRepository<Account, AccountResponse> updateRepo, IMapper mapper, IRepository<Account> accountRepo)
        {
            _updateRepo = updateRepo;
            _mapper = mapper;
            _accountRepo = accountRepo;
        }

        public async Task<SaveAccount> GetByIdAsync(int id)
        {
            var account = await _accountRepo.GetByIdAsync(id);
            var map = _mapper.Map<SaveAccount>(account);
            return map;
        }

        public async Task<ResponseDTO<List<AccountResponse>>> GetAll()
        {
            var accounts = await _accountRepo.GetAllWithChildrenAsync("Creator", "Modifier");
            var map = _mapper.Map<List<AccountResponse>>(accounts);
            return new ResponseDTO<List<AccountResponse>>() { Message = AppConst.ApiMessage.DataRetrived, Response = map, StatusCode = System.Net.HttpStatusCode.OK };
        }
        public async Task<PageDataRes<AccountResponse>> PageData(LoadDataRequest request)
        {
            var data = _accountRepo.GetPageDataWithChildrenAsync("Creator", "Modifier");
            data = data.ApplyDynamicFilters(request.Filters);
            data = PageDataHelper.ApplySort(data, request.PageData.SortBy, request.PageData.SortDirection);
            var pagedData = await PageDataHelper.ApplyPage<Account, AccountResponse>(data, request.PageData.PageNumber, request.PageData.PageSize, _mapper);
            return pagedData;
        }

        public async Task<ResponseDTO<AccountResponse>> Save(SaveAccount req)
        {
            var map = _mapper.Map<Account>(req);
            var result = await _updateRepo.SaveAsync(map, req.Name, req.Id);
            return new ResponseDTO<AccountResponse>() { Message = AppConst.ApiMessage.Save, Response = result, StatusCode = System.Net.HttpStatusCode.OK };
        }

        public async Task<ResponseDTO<bool>> DeleteAsync(int id)
        {
            var result = await _accountRepo.DeleteAsync(id);
            if (result)
            {
                return new ResponseDTO<bool>() { Message = AppConst.ApiMessage.Delete, Response = result, StatusCode = System.Net.HttpStatusCode.OK };
            }
            else
            {
                return new ResponseDTO<bool>() { Message = AppConst.ApiMessage.NotFound, Response = result, StatusCode = System.Net.HttpStatusCode.BadRequest };
            }
        }

        public async Task<List<IdNameRes>> GetAccountsAsync()
        {
            return await _accountRepo.GetAllAsync(a => new IdNameRes { Id = a.Id.ToString(), Name = a.Name });
        }
    }
}
