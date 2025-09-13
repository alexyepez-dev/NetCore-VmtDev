using Microsoft.EntityFrameworkCore;
using VMT.ERP.Application.Interfaces.User;
using VMT.ERP.Common.Helpers.Message;
using VMT.ERP.Domain.Entities;
using VMT.ERP.Persistence.Database;
using VMT.ERP.Utils.Helpers.Api;
using VMT.ERP.Utils.Helpers.Message;

namespace VMT.ERP.Application.Bll.User
{
    public class GetAllUserBll(BaseErpContext _context) : IGetAllUserBll
    {
        private readonly BaseErpContext context = _context;

        public async Task<ApiResponse<List<Usuario>>> Execute()
        {
            try
            {
                var statusCodeBadRequest = ResponseStatusCode.BadRequest;
                var statusCodeBadRequestMessage = ResponseStatusCode.BadRequestMessage;
                var contextMessageBadRequest = ResponseMessage.ErrorBadRequest;

                var statusCodeNotFound = ResponseStatusCode.NotFound;
                var statusCodeNotFoundMessage = ResponseStatusCode.NotFoundMessage;
                var contextMessageNotFound = ResponseMessage.listOfUsersFailed;

                var statusCodeOk = ResponseStatusCode.Ok;
                var statusCodeMessage = ResponseStatusCode.OkMessage;
                var contextMessageOk = ResponseMessage.listOfUsersSuccess;

                var expressionToValidateContextNull = context is null;

                if (expressionToValidateContextNull)
                {
                    return new ApiResponse<List<Usuario>>
                        (
                        false,
                        statusCodeBadRequest,
                        statusCodeBadRequestMessage,
                        contextMessageBadRequest,
                        null!
                        );
                }

                var listOfUsers = await context!.Usuarios.ToListAsync();
                var expressionToValidateNotFound = listOfUsers is null || listOfUsers.Count == 0;

                if (expressionToValidateNotFound)
                {
                    return new ApiResponse<List<Usuario>>
                        (
                        false,
                        statusCodeNotFound,
                        statusCodeNotFoundMessage,
                        contextMessageNotFound,
                        null!
                        );
                }

                return new ApiResponse<List<Usuario>>
                    (
                    true,
                    statusCodeOk,
                    statusCodeMessage,
                    contextMessageOk,
                    listOfUsers!
                    );
            }
            catch (Exception error)
            {
                var statusCodeInternalError = ResponseStatusCode.InternalError;
                var statusCodeInternalErrorMessage = ResponseStatusCode.NotFoundMessage;
                var contextMessageInternalError = ResponseMessage.listOfUsersFailed;

                return new ApiResponse<List<Usuario>>
                    (
                    false,
                    statusCodeInternalError,
                    statusCodeInternalErrorMessage,
                    $"Error: {error} | Unexpected error: {contextMessageInternalError}",
                    null!
                    );
            }
        }
    }
}