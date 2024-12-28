using AutoMapper;
using Hisab.CryptoService;
using HisabPro.Constants;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Repository.Interfaces;
using HisabPro.Services;
using HisabPro.Services.Interfaces;
using HisabPro.Web.Helper;
using HisabPro.Web.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ColType = HisabPro.Web.ViewModel.Type;

namespace HisabPro.Web.Controllers.Private
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRpository;
        private readonly AuthService _authService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRpository, AuthService authService, IUserService userService, IMapper mapper)
        {
            _userRpository = userRpository;
            _authService = authService;
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("user/login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Redirect to the desired page if the user is already authenticated
                return RedirectToAction("Index", "Home");
            }
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRpository.Authenticate(login.Email, login.Password);
                if (user == null)
                {
                    return Unauthorized();
                }
                else
                {
                    var tokenString = await _authService.SignInUser(user);
                    if (login.RememberMe)
                    {
                        var encryptedUserId = EncryptionHelper.Encrypt(user.Id.ToString());
                        // Set a persistent cookie
                        Response.Cookies.Append(AppConst.Cookies.RememberMe, encryptedUserId,
                            new CookieOptions
                            {
                                Expires = DateTimeOffset.Now.AddDays(30),
                                HttpOnly = true,
                                Secure = true // Ensure the cookie is only sent over HTTPS
                            });
                    }
                    else
                    {
                        // Clear the cookie if not remembered
                        Response.Cookies.Delete(AppConst.Cookies.RememberMe);
                    }
                    return Ok(new { Token = tokenString });
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, MessageConst.Validations.ValidationFailed);
                return View(login);
            }
        }

        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Clear the "Remember Me" cookie
            Response.Cookies.Delete(AppConst.Cookies.RememberMe);
            return RedirectToAction("Index", "Home"); // Redirect to login page or another page after logout
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var roles = EnumHelper.ToIdNameList<UserRoleEnum>();
            var genders = EnumHelper.ToIdNameList<UserGenederEnum>();
            var filters = new List<BaseFilterModel>
            {
                new FilterModel<string> {
                    FieldName = "Name"
                },
                 new FilterModel<string> {
                    FieldName = "Email"
                },
                new FilterModel<int> {
                    FieldName = "UserRole",
                    FieldTitle="Role",
                    Items = _mapper.Map<List<IdNameAndRefId>>(roles),
                },
                new FilterModel<DateTime> {
                    FieldName = "CreatedOn",
                    FieldTitle="Created Date Range"
                },
                new FilterModel<bool> {
                    FieldName = "IsActive",
                    FieldTitle="Is Active"
                },
                new FilterModel<int> {
                    FieldName = "Gender",
                    FieldTitle="Gender",
                    Items = _mapper.Map<List<IdNameAndRefId>>(genders),
                }
            };
            var req = new LoadDataRequest() { Filters = filters };
            var model = await LoadGridData(req, true);
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Load([FromBody] LoadDataRequest req)
        {
            var model = await LoadGridData(req);
            return PartialView("~/Views/Shared/_GridViewBody.cshtml", model);
        }

        [Authorize]
        public async Task<IActionResult> Save(int? id)
        {
            var roles = EnumHelper.ToIdNameList<UserRoleEnum>();
            roles.Insert(0, new IdNameRes { Id = string.Empty, Name = string.Empty });
            ViewData["UserRole"] = new SelectList(roles, "Id", "Name");

            var genders = EnumHelper.ToIdNameList<UserGenederEnum>();
            genders.Insert(0, new IdNameRes { Id = string.Empty, Name = string.Empty });
            ViewData["UserGender"] = new SelectList(genders, "Id", "Name");

            if (id != null)
            {
                var model = await _userService.GetByIdAsync(id.Value);
                return View(model);
            }
            return View(new SaveUserReq { UserRole = 2 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Save([Bind("Id,Name,Email,UserRole")] SaveUserReq req)
        {
            var response = await _userService.SaveAsync(req);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody] DeleteReq req)
        {
            var response = await _userService.DeleteAsync(req.Id);
            return StatusCode((int)response.StatusCode, response); ;
        }

        /// <summary>
        /// This is used for generic gridview component which will perform sorting and pagination
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private async Task<GridViewModel<object>> LoadGridData(LoadDataRequest req, bool firstTimeLoad = false)
        {
            var columns = new List<Column> {
                    new Column() { Name = "Name", Width = "140px"  },
                    new Column() { Name = "Email", IsSortable = false},
                    new Column() { Name = "Mobile", Width="120px" },
                    new Column() { Name = "IsActive", Title = "Active", Width="90px", Type = ColType.Checkbox },
                    new Column() { Name = "GenderName", Title="Gender", Width="90px" },
                    new Column() { Name = "UserRoleName", Title = "Role", Width= "120px" },
                    new Column() { Name = "CreatedOn", Title ="Created On", Type = ColType.Date, Width = "130px" },
                    new Column() { Name = "Edit", Type = ColType.Edit},
                    new Column() { Name = "Delete", Type = ColType.Delete}
            };
            return await GridviewHelper.LoadGridData(req, firstTimeLoad, _userService.PageData, columns);
        }
    }
}
