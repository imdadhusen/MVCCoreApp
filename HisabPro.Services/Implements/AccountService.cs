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
using HisabPro.Constants.Resources;

namespace HisabPro.Services.Implements
{
    public class AccountService : IAccountService
    {
        private readonly UpdateRepository<Account, AccountRes> _updateRepo;
        private readonly IRepository<Account> _accountRepo;
        private readonly IMapper _mapper;
        private readonly ISharedViewLocalizer _localizer;

        public AccountService(UpdateRepository<Account, AccountRes> updateRepo, IMapper mapper, IRepository<Account> accountRepo, ISharedViewLocalizer localizer)
        {
            _updateRepo = updateRepo;
            _mapper = mapper;
            _accountRepo = accountRepo;
            _localizer = localizer;
        }

        public async Task<SaveAccountReq> GetByIdAsync(int id)
        {
            var account = await _accountRepo.GetByIdAsync(id);
            var map = _mapper.Map<SaveAccountReq>(account);
            return map;
        }

        public async Task<ResponseDTO<List<AccountRes>>> GetAll()
        {
            var accounts = await _accountRepo.GetAllWithChildrenAsync("Creator", "Modifier");
            var map = _mapper.Map<List<AccountRes>>(accounts);
            return new ResponseDTO<List<AccountRes>>(System.Net.HttpStatusCode.OK, _localizer.Get(ResourceKey.LabelApiDataRetrived), map);
        }
        public async Task<PageDataRes<AccountRes>> PageData(LoadDataRequest request)
        {
            var data = _accountRepo.GetPageDataWithChildrenAsync("Creator", "Modifier");
            data = data.ApplyDynamicFilters(request.Filter.Fields);
            data = PageDataHelper.ApplySort(data, request.PageData);
            var pagedData = await PageDataHelper.ApplyPage<Account, AccountRes>(data, request.PageData, _mapper);
            return pagedData;
        }

        public async Task<ResponseDTO<AccountRes>> SaveAsync(SaveAccountReq req)
        {
            var map = _mapper.Map<Account>(req);
            var result = await _updateRepo.SaveAsync(map, req.Name, req.Id);
            return new ResponseDTO<AccountRes>(System.Net.HttpStatusCode.OK, _localizer.Get(ResourceKey.LabelApiSave), result);
        }

        public async Task<ResponseDTO<bool>> DeleteAsync(int id)
        {
            var result = await _accountRepo.DeleteAsync(id);
            if (result)
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.OK, _localizer.Get(ResourceKey.LabelApiDelete), result);
            }
            else
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.BadRequest, _localizer.Get(ResourceKey.LabelApiNotFound), result);
            }
        }

        public async Task<List<IdNameRes>> GetAccountsAsync()
        {
            return await _accountRepo.GetAllAsync(a => new IdNameRes { Id = a.Id.ToString(), Name = a.Name });
        }
    }
}
