using HisabPro.DTO.Request;
using HisabPro.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HisabPro.Web.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            return View(await _accountService.GetAll());
        }

        // GET: Accounts/Save
        public async Task<IActionResult> Save(int? id)
        {
            if (id == null)
            {
                // Create
                return View();
            }
            else
            {
                // Edit
                var model = await _accountService.GetByIdAsync(id.Value);
                return View(model);
            }
        }

        // POST: Accounts/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("Id,Name,FullName,Mobile,IsActive")] SaveAccount req)
        {
            var response = await _accountService.Save(req);
            return StatusCode((int)HttpStatusCode.OK, response);
        }
    }
}
