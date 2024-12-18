using HisabPro.DTO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace HisabPro.Web.Helper
{
    public class ValidateModelStateFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var (message, errors) = ValidationHelper.GetValidationErrors(context.ModelState);
                var response = new ResponseDTO<List<string>>(HttpStatusCode.BadRequest, message, errors);
                context.Result = new BadRequestObjectResult(response);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do nothing after the action executes
        }
    }
}
