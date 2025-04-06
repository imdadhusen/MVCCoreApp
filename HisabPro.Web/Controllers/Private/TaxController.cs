using HisabPro.DTO.Model;
using HisabPro.Services.Interfaces;
using HisabPro.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HisabPro.Web.Controllers.Private
{
    [Authorize]
    public class TaxController : Controller
    {
        private readonly ITaxService _taxService;
        public TaxController(ITaxService taxService) { 
            _taxService = taxService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new TaxInputModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(TaxInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input); // Still show the form if input is invalid
            }

            var result = new TaxResultModel
            {
                AnnualIncome = input.AnnualIncome
            };

            result.TaxAmount = _taxService.CalculateNewRegimeTax(result.TaxableIncome, result);

            if (result.TaxAmount == 0)
            {
                result.ResultMessage = "🎉 No tax applicable under the new regime (Section 87A rebate applied).";
            }
            else
            {
                result.ResultMessage = $"Tax payable under the new regime is ₹{result.TaxAmount:N0}.";
            }

            return View("IndianTaxResult", result); // Separate Result view
        }

    }
}
