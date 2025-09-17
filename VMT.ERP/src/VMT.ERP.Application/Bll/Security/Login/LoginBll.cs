using VMT.ERP.Application.Dto.Security.Login;
using VMT.ERP.Persistence.UnitOfWork.Interface;
using VMT.ERP.Utils.Helpers.Api;

namespace VMT.ERP.Application.Bll.Security.Login
{
    public class LoginBll(IUnitOfWork _unitOfWork) 
    {
        private readonly IUnitOfWork unitOfWork = _unitOfWork;

        public async Task<ApiResponse<LoginDto>> Execute(LoginDto loginDto)
        {
            try
            {
                var usuario;
            }
            catch (Exception error)
            {
            }
        }
    }
}