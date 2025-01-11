﻿using AutoMapper;
using Hisab.CryptoService;
using HisabPro.Constants;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.IEntities;
using HisabPro.Repository.Interfaces;
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
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public UserController(IUserRepository userRpository, IAuthService authService, IUserService userService, IMapper mapper, IUserContext userContext)
        {
            _userRpository = userRpository;
            _authService = authService;
            _userService = userService;
            _mapper = mapper;
            _userContext = userContext;
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var response = await _userRpository.Authenticate(login.Email, login.Password);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var user = response.Response;
                if (user != null)
                {
                    await _authService.SignInUser(user);
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
                }
            }
            return StatusCode((int)response.StatusCode, response);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await logoutUser();
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
        public async Task<IActionResult> Save([Bind("Id,Name,Email,UserRole,Gender,Mobile")] SaveUserReq req)
        {
            var activationLink = Url.Action("ActivateUser", "User", new { Email = req.Email, Token = "000" }, Request.Scheme);
            var response = await _userService.SaveAsync(req, activationLink);
            return StatusCode((int)response.StatusCode, response);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ActivateUser(string email, string token)
        {
            var response = await _userService.ActivateUser(email, token);

            //var users = await _userService.GetAll();
            //response.Response = users.Response.FirstOrDefault();

            if (response.Response?.Id >= 1)
            {
                return View("ActivationSuccess", response.Response);
            }
            else
            {
                return View("ActivationFailed");
            }
        }

        /// <summary>
        /// Newly registered user setting password view
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult ChangePassword(int userId)
        {
            return PartialView(new SetPasswordReq() { UserId = userId });
        }

        /// <summary>
        /// Newly registered user setting password via password reset link
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(SetPasswordReq model)
        {
            var response = await _userService.ChangePassword(model);
            //if (response.Response)
            //{
            //    // After succesful password set user must nevigate to login
            //    logoutUser();
            //}
            return StatusCode((int)response.StatusCode, response);
        }

        /// <summary>
        /// Logged in user change password view
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Authorize]
        public IActionResult UpdatePassword()
        {
            return View(new ResetPasswordReq());
        }
        /// <summary>
        /// Logged in user can change password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> UpdatePassword(ResetPasswordReq model)
        {
            model.UserId = _userContext.GetCurrentUserId();
            var response = await _userService.ChangePassword(model);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody] DeleteReq req)
        {
            var response = await _userService.DeleteAsync(req.Id);
            return StatusCode((int)response.StatusCode, response); ;
        }

        [HttpGet]
        [Authorize]
        public IActionResult ForcePasswordChange()
        {
            ViewData["IsForcePasswordChange"] = true;
            var id = _userContext.GetCurrentUserId();
            return View("UpdatePassword", new ResetPasswordReq() { UserId = id });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ForcePasswordChange(ResetPasswordReq model)
        {
            var response = new ResponseDTO<bool>();
            var user = await _userService.GetByIdAsync(model.UserId);
            if (user != null)
            {
                response = await _userService.ChangePassword(model);
            }
            return StatusCode((int)response.StatusCode, response);
        }

        [AllowAnonymous]
        [HttpGet]
        [Authorize]
        public IActionResult Register()
        {
            // User can register with User role only and Admin/Super admin can assign appropriate role 
            var roles = EnumHelper.ToIdNameList<UserRoleEnum>().Where(r => r.Id == ((int)UserRoleEnum.User).ToString()).ToList();
            roles.Insert(0, new IdNameRes { Id = string.Empty, Name = string.Empty });
            ViewData["UserRole"] = new SelectList(roles, "Id", "Name");

            var genders = EnumHelper.ToIdNameList<UserGenederEnum>();
            genders.Insert(0, new IdNameRes { Id = string.Empty, Name = string.Empty });
            ViewData["UserGender"] = new SelectList(genders, "Id", "Name");

            return View(new SaveUserReq { UserRole = 2 });
        }

        [AllowAnonymous]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register([Bind("Name,Email,UserRole,Gender,Mobile")] SaveUserReq req)
        {
            // If user trying to set other role by injectting script then this will overwrite
            req.UserRole = (int)UserRoleEnum.User;

            var activationLink = Url.Action("ActivateUser", "User", new { Email = req.Email, Token = "000" }, Request.Scheme);
            var response = await _userService.SaveAsync(req, activationLink, true);
            return StatusCode((int)response.StatusCode, response);
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

        private async Task logoutUser()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Clear the "Remember Me" cookie
            Response.Cookies.Delete(AppConst.Cookies.RememberMe);
        }
    }
}