using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using HisabPro.DTO.Response;
using HisabPro.Services.Interfaces;
using HisabPro.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HisabPro.Web.Controllers.Private
{
    [Authorize]
    public class TaxController : Controller
    {
        private readonly ITaxService _taxService;
        private readonly ISharedViewLocalizer _localizer;
        private readonly ICategoryService _categoryService;

        public TaxController(ITaxService taxService, ISharedViewLocalizer sharedViewLocalizer, ICategoryService categoryService)
        {
            _taxService = taxService;
            _localizer = sharedViewLocalizer;
            _categoryService = categoryService;
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
            return View(new List<ZakatIncomeItem>());
        }
        public async Task<IActionResult> IncomesForZakat()
        {
            var categories = await _categoryService.GetCategoriesAsync(EnumCategoryType.Income);
            categories.Insert(0, new IdNameRes { Id = string.Empty, Name = string.Empty });
            categories.Insert(categories.Count(), new IdNameRes { Id = ZakatIncomeItem.IncomeTypeForOtherId.ToString(), Name = ZakatIncomeItem.IncomeTypeForOtherName });
            ViewData["Categories"] = new SelectList(categories, "Id", "Name");

            var errorMessage = string.Format(_localizer[ResourceKey.ValidationRequired], _localizer[ResourceKey.Description]);
            ViewData["errorMsgDescription"] = errorMessage;
            return PartialView("_IncomesForZakat", new ZakatIncomeItem());
        }

        [HttpPost]
        public IActionResult SaveZakat([FromBody] List<ZakatIncomeItem> Items)
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
