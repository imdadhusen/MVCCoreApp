using HisabPro.Common;
using HisabPro.DTO.Model;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
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
            if (context.Exception is CustomValidationException ex)
            {
                _logger.LogError("CustomValidationException: {Message}", ex.Message);
                context.Result = new JsonResult(new ResponseDTO<bool>(HttpStatusCode.BadRequest, ex.Message, false))
                {
                    StatusCode = ex.StatusCode
                };
                context.ExceptionHandled = true;
            }
        }
    }

}
