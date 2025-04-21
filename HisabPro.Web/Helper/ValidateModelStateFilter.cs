using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace HisabPro.Web.Helper
{
    public class ValidateModelStateFilter : IActionFilter
    {
        private readonly ISharedViewLocalizer _localizer;

        public ValidateModelStateFilter(ISharedViewLocalizer localizer)
        {
            _localizer = localizer;
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var message = _localizer[ResourceKey.LabelApiValidationFailed];
                var errors = ValidationHelper.GetValidationErrors(context.ModelState);
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
