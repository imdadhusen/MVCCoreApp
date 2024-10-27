using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.Services.Interfaces;
using HisabPro.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HisabPro.Web.Controllers
{
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
            //var applicationDbContext = _context.Accounts.Include(a => a.Creator).Include(a => a.Modifier);
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
            //TODO: Validation needs to be handle in custom pipeline
            var (message, errors) = ValidationHelper.GetValidationErrors(ModelState);
            if (message != "")
            {
                var response = new ResponseDTO<List<string>>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = message,
                    Response = errors
                };
                return BadRequest(response);
            }
            else
            {
                var response = await _accountService.Save(req);
                return StatusCode((int)HttpStatusCode.OK, response);
            }
        }
    }
}
