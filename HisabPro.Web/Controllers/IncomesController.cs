using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Services.Implements;
using HisabPro.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HisabPro.Web.Controllers
{
    [Authorize]
    public class IncomesController : Controller
    {
        private readonly IIncomeService _incomeService;
        public IncomesController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _incomeService.GetAll());
        }

        public async Task<IActionResult> Save(int? id)
        {
            var accounts = await _incomeService.GetAccountListAsync();
            accounts.Insert(0, new IdNameRes { Id = 0, Name = "" });
            ViewData["AccountId"] = new SelectList(accounts, "Id", "Name");
            if (id != null)
            {
                var model = await _incomeService.GetByIdAsync(id.Value);
                return View(model);
               
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("Id,Title,IncomeOn,Amount,Note,AccountId,IsActive")] SaveIncome req)
        {
            var response = await _incomeService.Save(req);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteReq req)
        {
            var response = await _incomeService.DeleteAsync(req.Id);
            return StatusCode((int)response.StatusCode, response); ;
        }
    }
}
