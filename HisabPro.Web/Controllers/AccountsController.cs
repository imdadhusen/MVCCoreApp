using HisabPro.DTO.Request;
using HisabPro.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> Index()
        {
            return View(await _accountService.GetAll());
        }

        public async Task<IActionResult> Save(int? id)
        {
            if (id != null)
            {
                var model = await _accountService.GetByIdAsync(id.Value);
                return View(model);

            }
            return View(new SaveAccount { IsActive = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("Id,Name,FullName,Mobile,IsActive")] SaveAccount req)
        {
            var response = await _accountService.Save(req);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteReq req)
        {
            var response = await _accountService.DeleteAsync(req.Id);
            return StatusCode((int)response.StatusCode, response); ;
        }
    }
}
