using Microsoft.EntityFrameworkCore;
using VMT.ERP.Application.Interfaces.User;
using VMT.ERP.Common.Helpers.Message;
using VMT.ERP.Domain.Entities;
using VMT.ERP.Persistence.Database;
using VMT.ERP.Utils.GetResponse;
using VMT.ERP.Utils.Helpers.Api;

namespace VMT.ERP.Application.Bll.User
{
    public class GetAllUserBll(BaseErpContext _context) : IGetAllUserBll
    {
        private readonly BaseErpContext context = _context;

        public async Task<ApiResponse<List<Usuario>>> Execute()
        {
            try
            {
                var listOfUsersBadRequest = ResponseMessage.ErrorBadRequest;
                var listOfUsersMessageNotFound = ResponseMessage.listOfUsersFailed;
                var listOfUsersMessageOk = ResponseMessage.listOfUsersSuccess;

                var listOfUsers = await context!.Usuarios.ToListAsync();


                if (context is null)
                {
                    return ApiResult.BadRequest<List<Usuario>>(listOfUsersBadRequest);
                }

                if (listOfUsers is null || listOfUsers.Count == 0)
                {
                    return ApiResult.NotFound<List<Usuario>>(listOfUsersMessageNotFound);
                }

                return ApiResult.Ok(listOfUsers, listOfUsersMessageOk);
            }
            catch (Exception error)
            {
                var listOfUsersMessageInternalError = ResponseMessage.listOfUsersFailed;

                return ApiResult.InternalError<List<Usuario>>(listOfUsersMessageInternalError, error);
            }
        }
    }
}