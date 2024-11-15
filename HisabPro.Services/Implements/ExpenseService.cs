﻿using AutoMapper;
using HisabPro.Constants;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;

namespace HisabPro.Services.Implements
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepository<Expense> _expenseRepo;
        private readonly IMapper _mapper;

        public ExpenseService(IRepository<Expense> expenseRepo, IMapper mapper)
        {
            _expenseRepo = expenseRepo;
            _mapper = mapper;
        }

        public async Task<SaveExpense> GetByIdAsync(int id)
        {
            var account = await _expenseRepo.GetByIdAsync(id);
            var map = _mapper.Map<SaveExpense>(account);
            return map;
        }

        public async Task<ResponseDTO<List<ExpenseResponse>>> GetAll()
        {
            var expense = await _expenseRepo.GetAllWithChildrenAsync("Account", "ParentCategory", "ChildCategory"); //"Creator", "Modifier"
            var map = _mapper.Map<List<ExpenseResponse>>(expense);
            return new ResponseDTO<List<ExpenseResponse>>() { Message = AppConst.ApiMessage.DataRetrived, Response = map, StatusCode = System.Net.HttpStatusCode.OK };
        }

        public async Task<ResponseDTO<ExpenseResponse>> Save(SaveExpense req)
        {
            var map = _mapper.Map<Expense>(req);
            var result = await _expenseRepo.SaveAsync(map);
            var response = _mapper.Map<ExpenseResponse>(result);
            return new ResponseDTO<ExpenseResponse>() { Message = AppConst.ApiMessage.Save, Response = response, StatusCode = System.Net.HttpStatusCode.OK };
        }

        public async Task<ResponseDTO<bool>> DeleteAsync(int id)
        {
            var result = await _expenseRepo.DeleteAsync(id);
            return new ResponseDTO<bool>() { Message = AppConst.ApiMessage.Delete, Response = result, StatusCode = System.Net.HttpStatusCode.OK };
        }
    }
}
