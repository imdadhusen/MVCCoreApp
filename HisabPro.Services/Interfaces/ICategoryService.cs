﻿using HisabPro.Constants;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;

namespace HisabPro.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<SaveCategoryReq> GetByIdAsync(int id);
        Task<ResponseDTO<List<CategoryRes>>> GetAll();
        Task<PageDataRes<CategoryRes>> PageData(LoadDataRequest request);
        Task<PageDataRes<CategoryRes>> ExportData(ExportReq request);
        Task<List<IdNameAndRefId>> GetAllParentCategoryByType(int type);

        Task<ResponseDTO<CategoryRes>> SaveAsync(SaveCategoryReq req);
        Task<ResponseDTO<bool>> DeleteAsync(int id);

        Task<List<IdNameRes>> GetCategoriesAsync(EnumCategoryType? categoryType);
        Task<List<SubCategoryRes>> GetSubCategoriesAsync(EnumCategoryType? categoryType);
    }
}
