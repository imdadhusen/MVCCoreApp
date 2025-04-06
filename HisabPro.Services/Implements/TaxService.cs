using HisabPro.DTO.Model;
using HisabPro.Services.Interfaces;

namespace HisabPro.Services.Implements
{
    public class TaxService : ITaxService
    {
        public decimal CalculateNewRegimeTax(decimal taxableIncome, TaxResultModel model)
        {
            decimal tax = 0;
            var slabs = new List<(decimal Limit, decimal Rate)>
            {
                (300000, 0.00m),
                (600000, 0.05m),
                (900000, 0.10m),
                (1200000, 0.15m),
                (1500000, 0.20m),
                (decimal.MaxValue, 0.30m)
            };

            decimal prevLimit = 0;
            foreach (var (limit, rate) in slabs)
            {
                if (taxableIncome > prevLimit)
                {
                    var taxable = Math.Min(taxableIncome, limit) - prevLimit;
                    var slabTax = taxable * rate;

                    model.SlabBreakdown.Add(new TaxSlabDetail
                    {
                        SlabRange = $"₹{prevLimit + 1:N0} – ₹{limit:N0}",
                        Rate = rate * 100,
                        TaxableAmount = taxable,
                        TaxForSlab = slabTax
                    });

                    tax += slabTax;
                }

                if (taxableIncome <= limit)
                    break;

                prevLimit = limit;
            }

            // Apply 87A Rebate if taxable income ≤ ₹7L
            if (taxableIncome <= 700000)
            {
                tax = 0;
                model.SlabBreakdown.Clear();
                model.SlabBreakdown.Add(new TaxSlabDetail
                {
                    SlabRange = $"After standard deduction, net income = ₹{taxableIncome:N0}",
                    Rate = 0,
                    TaxableAmount = taxableIncome,
                    TaxForSlab = 0
                });
            }

            return tax;
        }
    }
}
