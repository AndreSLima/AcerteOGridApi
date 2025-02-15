using AcerteOGrid.Communication.Error;
using AcerteOGrid.Exception;
using AcerteOGrid.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AcerteOGrid.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is AcerteOGridException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnkowError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            var acerteOGridException = context.Exception as AcerteOGridException;
            var errorResponse = new ErrorResponse(acerteOGridException!.GetErrors());

            context.HttpContext.Response.StatusCode = acerteOGridException.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }

        private void ThrowUnkowError(ExceptionContext context)
        {
            var errorResponse = new ErrorResponse(ResourceErrorMessages.UNKNOWN_ERROR);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}