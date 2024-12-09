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

        public async Task<SaveUser> GetByIdAsync(int id)
        {
            var account = await _userRepo.GetByIdAsync(id);
            var map = _mapper.Map<SaveUser>(account);
            return map;
        }

        public async Task<ResponseDTO<List<UserResponse>>> GetAll()
        {
            var users = await _userRepo.GetAllWithChildrenAsync("Creator", "Modifier");
            var map = _mapper.Map<List<UserResponse>>(users);
            return new ResponseDTO<List<UserResponse>>() { Message = AppConst.ApiMessage.DataRetrived, Response = map, StatusCode = System.Net.HttpStatusCode.OK };
        }
        public async Task<PageDataRes<UserResponse>> PageData(LoadDataRequest request)
        {
            var data = _userRepo.GetPageDataWithChildrenAsync("Creator", "Modifier");
            data = data.ApplyDynamicFilters(request.Filters);
            data = PageDataHelper.ApplySort(data, request.PageData);
            var pagedData = await PageDataHelper.ApplyPage<User, UserResponse>(data, request.PageData, _mapper);
            return pagedData;
        }

        public async Task<ResponseDTO<UserResponse>> Save(SaveUser req)
        {
            var map = _mapper.Map<User>(req);
            var result = await _updateRepo.SaveAsync(map, req.Email, req.Id);
            return new ResponseDTO<UserResponse>() { Message = AppConst.ApiMessage.Save, Response = result, StatusCode = System.Net.HttpStatusCode.OK };
        }

        public async Task<ResponseDTO<bool>> DeleteAsync(int id)
        {
            var result = await _userRepo.DeleteAsync(id);
            if (result)
            {
                return new ResponseDTO<bool>() { Message = AppConst.ApiMessage.Delete, Response = result, StatusCode = System.Net.HttpStatusCode.OK };
            }
            else
            {
                return new ResponseDTO<bool>() { Message = AppConst.ApiMessage.NotFound, Response = result, StatusCode = System.Net.HttpStatusCode.BadRequest };
            }
        }

        //public async Task<List<IdNameRes>> GetAccountsAsync()
        //{
        //    return await _accountRepo.GetAllAsync(a => new IdNameRes { Id = a.Id.ToString(), Name = a.Name });
        //}
    }
}
