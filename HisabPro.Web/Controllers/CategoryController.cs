using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using HisabPro.Web.Helper;
using HisabPro.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HisabPro.Web.Controllers
{
    [Authorize]
    public class CategoryController(ICategoryRepository categoryRepository) : Controller
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        [HttpGet("category/Index")]
        public async Task<IActionResult> Index()
        {
            CategoryModel categoryDetail = new CategoryModel
            {
                AllCategoryList = await _categoryRepository.GetCategories(),
                ParentCategoryList = await _categoryRepository.GetParentCategories(),
                ChildCategoryList = await _categoryRepository.GetChildCategories()
            };
            //return Ok(categories);
            return View(categoryDetail);
        }


        // POST: /Category/Save
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveRequestDTO model)
        {
            try
            {
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
                    var data = await _categoryRepository.SaveCategory(model);
                    var response = new ResponseDTO<ChildCategoryRes>
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Data saved successfully",
                        Response = data
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                //TODO: in prod don't expose actual error use "Internal Server Error"
                var response = new ResponseDTO<string>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "Internal server error",
                    Response = ex.Message
                };
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
