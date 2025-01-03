﻿using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.DTO.Model;

namespace HisabPro.Services.Interfaces
{
    public interface IUserService
    {
        Task<SaveUserReq> GetByIdAsync(int id);
        Task<ResponseDTO<List<UserRes>>> GetAll();
        Task<PageDataRes<UserRes>> PageData(LoadDataRequest request);
        Task<ResponseDTO<UserRes>> SaveAsync(SaveUserReq req);
        Task<ResponseDTO<bool>> DeleteAsync(int id);
    }
}
