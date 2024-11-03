using AutoMapper;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Interfaces;
using HisabPro.Constants;

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

        public async Task<SaveIncome> GetByIdAsync(int id)
        {
            var account = await _incomeRepo.GetByIdAsync(id);
            var map = _mapper.Map<SaveIncome>(account);
            return map;
        }

        public async Task<ResponseDTO<List<IncomeResponse>>> GetAll()
        {
            var accounts = await _incomeRepo.GetAllWithChildrenAsync("Account"); //"Creator", "Modifier"
            var map = _mapper.Map<List<IncomeResponse>>(accounts);
            return new ResponseDTO<List<IncomeResponse>>() { Message = AppConst.ApiMessage.DataRetrived, Response = map, StatusCode = System.Net.HttpStatusCode.OK };
        }

        public async Task<ResponseDTO<IncomeResponse>> Save(SaveIncome req)
        {
            var map = _mapper.Map<Income>(req);
            var result = await _incomeRepo.SaveAsync(map);
            var response = _mapper.Map<IncomeResponse>(result);
            return new ResponseDTO<IncomeResponse>() { Message = AppConst.ApiMessage.Save, Response = response, StatusCode = System.Net.HttpStatusCode.OK };
        }

        public async Task<ResponseDTO<bool>> DeleteAsync(int id)
        {
            var result = await _incomeRepo.DeleteAsync(id);
            return new ResponseDTO<bool>() { Message = AppConst.ApiMessage.Delete, Response = result, StatusCode = System.Net.HttpStatusCode.OK };
        }
    }
}
