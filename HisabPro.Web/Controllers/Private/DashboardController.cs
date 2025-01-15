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
        public async Task<IActionResult> IncomeVsExpense([FromQuery] int accountId)
        {
            var response = await _dashboardService.IncomeVsExpense(accountId);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("InvestmentGrowth")]
        public async Task<IActionResult> InvestmentGrowth(int accountId)
        {
            var response = await _dashboardService.InvestmentGrowth(accountId);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("IncomeDistribution")]
        public async Task<IActionResult> IncomeDistribution(int accountId)
        {
            var response = await _dashboardService.IncomeDistribution(accountId);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("ExpenseDistribution")]
        public async Task<IActionResult> ExpenseDistribution(int accountId)
        {
            var response = await _dashboardService.ExpenseDistribution(accountId);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
