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
    public class UserService : IUserService
    {
        private readonly UpdateRepository<User, UserResponse> _updateRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IMapper _mapper;

        public UserService(UpdateRepository<User, UserResponse> updateRepo, IMapper mapper, IRepository<User> userRepo)
        {
            _updateRepo = updateRepo;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<SaveUserReq> GetByIdAsync(int id)
        {
            var account = await _userRepo.GetByIdAsync(id);
            var map = _mapper.Map<SaveUserReq>(account);
            return map;
        }

        public async Task<ResponseDTO<List<UserResponse>>> GetAll()
        {
            var users = await _userRepo.GetAllWithChildrenAsync("Creator", "Modifier");
            var map = _mapper.Map<List<UserResponse>>(users);
            return new ResponseDTO<List<UserResponse>>(System.Net.HttpStatusCode.OK, AppConst.ApiMessage.DataRetrived, map);
        }
        public async Task<PageDataRes<UserResponse>> PageData(LoadDataRequest request)
        {
            var data = _userRepo.GetPageDataWithChildrenAsync("Creator", "Modifier");
            data = data.ApplyDynamicFilters(request.Filters);
            data = PageDataHelper.ApplySort(data, request.PageData);
            var pagedData = await PageDataHelper.ApplyPage<User, UserResponse>(data, request.PageData, _mapper);
            return pagedData;
        }

        public async Task<ResponseDTO<UserResponse>> SaveAsync(SaveUserReq req)
        {
            var map = _mapper.Map<User>(req);
            var result = await _updateRepo.SaveAsync(map, req.Email, req.Id);
            return new ResponseDTO<UserResponse>(System.Net.HttpStatusCode.OK, AppConst.ApiMessage.Save, result);
        }

        public async Task<ResponseDTO<bool>> DeleteAsync(int id)
        {
            var result = await _userRepo.DeleteAsync(id);
            if (result)
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.OK, AppConst.ApiMessage.Delete, result);
            }
            else
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.BadRequest, AppConst.ApiMessage.NotFound, result);
            }
        }

        //public async Task<List<IdNameRes>> GetAccountsAsync()
        //{
        //    return await _accountRepo.GetAllAsync(a => new IdNameRes { Id = a.Id.ToString(), Name = a.Name });
        //}
    }
}
