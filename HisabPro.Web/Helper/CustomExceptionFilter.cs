using HisabPro.Common;
using HisabPro.Constants;
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
        private readonly ISharedViewLocalizer _localizer;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger, ISharedViewLocalizer localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            if (exception is CustomValidationException or FeatureNotAvailableException)
            {
                var statusCode = exception switch
                {
                    CustomValidationException e => e.StatusCode,
                    FeatureNotAvailableException e => e.StatusCode,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                _logger.LogError("{ExceptionType}: {Message}", exception.GetType().Name, exception.Message);

                context.Result = new JsonResult(new ResponseDTO<bool>((HttpStatusCode)statusCode, exception.Message, false))
                {
                    StatusCode = statusCode
                };
                context.ExceptionHandled = true;
            }
            else
            {
                string errorMessage = _localizer.Get(ResourceKey.LabelApiInternalError);
                if (exception.InnerException != null && exception.InnerException.Message.ToUpper().Contains("DELETE"))
                {
                    errorMessage = _localizer.Get(ResourceKey.LabelApiReferenceDeleteError);
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
