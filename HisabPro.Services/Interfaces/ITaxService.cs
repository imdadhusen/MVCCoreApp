using HisabPro.DTO.Model;

namespace HisabPro.Services.Interfaces
{
    public interface ITaxService
    {
        decimal CalculateNewRegimeTax(decimal taxableIncome, TaxResultModel model);
    }
}
