using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using VMT.ERP.Utils.Helpers.Api;
using VMT.ERP.Utils.Helpers.Message;

namespace VMT.ERP.Utils.Exceptions
{
    public class ExceptionManager : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Protegemos al filtro evitando que algun otro intervenga:
            context.ExceptionHandled = true;

            // Creamos la instancia de respuesta:
            var error = new ApiResponse<string>
                (
                false,
                ResponseStatusCode.InternalError,
                ResponseStatusCode.InternalErrorMessage,
                $"Unexpected error: {context.Exception.Message}",
                null!
                );

            // Inyectamos la instancia:
            context.Result = new ObjectResult(error)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}