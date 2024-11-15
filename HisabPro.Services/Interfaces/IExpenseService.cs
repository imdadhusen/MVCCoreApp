﻿using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;

namespace HisabPro.Services.Implements
{
    public interface IExpenseService
    {
        Task<SaveExpense> GetByIdAsync(int id);
        Task<ResponseDTO<List<ExpenseResponse>>> GetAll();
        Task<ResponseDTO<ExpenseResponse>> Save(SaveExpense req);
        Task<ResponseDTO<bool>> DeleteAsync(int id);
    }
}
