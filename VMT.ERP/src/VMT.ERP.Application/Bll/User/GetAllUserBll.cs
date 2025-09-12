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
                if (context is null)
                {
                    return new ApiResponse<List<Usuario>>
                        (
                        false,
                        ResponseStatusCode.BadRequest,
                        ResponseStatusCode.BadRequestMessage,
                        ResponseMessage.ErrorBadRequest,
                        null!
                        );
                }

                var listOfUsers = await context.Usuarios.ToListAsync();

                if (listOfUsers is null || listOfUsers.Count == 0)
                {
                    return new ApiResponse<List<Usuario>>
                        (
                        false,
                        ResponseStatusCode.NotFound,
                        ResponseStatusCode.NotFoundMessage,
                        ResponseMessage.listOfUsersFailed,
                        null!
                        );
                }

                return new ApiResponse<List<Usuario>>
                    (
                    true,
                    ResponseStatusCode.Ok,
                    ResponseStatusCode.OkMessage,
                    ResponseMessage.listOfUsersSuccess,
                    listOfUsers
                    );
            }
            catch (Exception error)
            {
                return new ApiResponse<List<Usuario>>
                    (
                    false,
                    ResponseStatusCode.InternalError,
                    ResponseStatusCode.InternalErrorMessage,
                    $"Error: {error} | Unexpected error: {ResponseMessage.ErrorInternalServer}",
                    null!
                    );
            }
        }
    }
}