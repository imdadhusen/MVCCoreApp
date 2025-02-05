using HisabPro.Common;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace HisabPro.Web.Helper
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            // Log the exception (optional)
            var exception = context.Exception;
            if (exception is CustomValidationException ex)
            {
                _logger.LogError("CustomValidationException: {Message}", ex.Message);
                context.Result = new JsonResult(new ResponseDTO<bool>(HttpStatusCode.BadRequest, ex.Message, false))
                {
                    StatusCode = ex.StatusCode
                };
                context.ExceptionHandled = true;
            }
            else
            {
                string errorMessage = SharedResource.LabelApiInternalError;
                if (exception.InnerException != null && exception.InnerException.Message.ToUpper().Contains("DELETE"))
                {
                    errorMessage = SharedResource.LabelApiReferenceDeleteError;
                }

                // Create a generic response
                var response = new ResponseDTO<bool>(HttpStatusCode.InternalServerError, errorMessage, false);
                // Set the response status code and content type
                context.HttpContext.Response.StatusCode = (int)response.StatusCode;
                context.HttpContext.Response.ContentType = "application/json";
                // Return the serialized response as JSON
                context.Result = new JsonResult(response);
            }
        }
    }

}
