using HisabPro.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HisabPro.Web.Controllers.Private
{
    [Authorize]
    [Route("dashboard")]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly IAccountService _accountService;
        public DashboardController(IDashboardService dashboardService, IAccountService accountService)
        {
            _dashboardService = dashboardService;
            _accountService = accountService;   
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await _accountService.GetAccountsAsync();
            ViewData["AccountId"] = new SelectList(accounts, "Id", "Name");
            return View();
        }

        [HttpGet("IncomeVsExpense")]
        public async Task<IActionResult> IncomeVsExpense([FromQuery] int accountId, int year)
        {
            var response = await _dashboardService.IncomeVsExpense(accountId, year);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("InvestmentGrowth")]
        public async Task<IActionResult> InvestmentGrowth(int accountId, int year)
        {
            var response = await _dashboardService.InvestmentGrowth(accountId, year);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("IncomeDistribution")]
        public async Task<IActionResult> IncomeDistribution(int accountId, int year)
        {
            var response = await _dashboardService.IncomeDistribution(accountId, year);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("ExpenseDistribution")]
        public async Task<IActionResult> ExpenseDistribution(int accountId, int year)
        {
            var response = await _dashboardService.ExpenseDistribution(accountId, year);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
