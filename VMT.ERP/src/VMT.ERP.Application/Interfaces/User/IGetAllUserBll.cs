using VMT.ERP.Domain.Entities;
using VMT.ERP.Utils.Helpers.Api;

namespace VMT.ERP.Application.Interfaces.User
{
    public interface IGetAllUserBll
    {
        public Task<ApiResponse<List<Usuario>>> Execute();
    }
}