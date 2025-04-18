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
        Task<PageDataRes<UserRes>> ExportData(ExportReq request);
        Task<ResponseDTO<UserRes>> SaveAsync(SaveUserReq req, string activationLink, bool useFallback = false);
        Task<ResponseDTO<bool>> DeleteAsync(int id);

        Task<ResponseDTO<UserRes?>> ActivateUser(string email, string token);
        Task<ResponseDTO<bool>> ChangePassword(SetPasswordReq request);
    }
}
