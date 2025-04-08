using HisabPro.Constants;
using HisabPro.Constants.Resources;
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
        private readonly ISharedViewLocalizer _localizer;

        public TaxController(ITaxService taxService, ISharedViewLocalizer sharedViewLocalizer) { 
            _taxService = taxService;
            _localizer = sharedViewLocalizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new TaxInputModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult IncomeTax(TaxInputModel input)
        {
            var result = new TaxResultModel
            {
                AnnualIncome = input.AnnualIncome
            };

            result.TaxAmount = _taxService.CalculateNewRegimeTax(result.TaxableIncome, result);

            if (result.TaxAmount == 0)
            {
                result.ResultMessage = $"🎉 {_localizer.Get(ResourceKey.NoTaxApplicable)}";
            }
            else
            {
                result.ResultMessage = string.Format(_localizer.Get(ResourceKey.TaxApplicable), result.TaxAmount);
            }

            return View("IncomeTaxResult", result);
        }

        [HttpGet]
        public IActionResult Zakat()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Khums()
        {
            return View();
        }
    }
}
