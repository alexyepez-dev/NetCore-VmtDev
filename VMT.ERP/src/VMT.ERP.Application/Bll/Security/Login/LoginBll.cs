using VMT.ERP.Persistence.UnitOfWork.Interface;

namespace VMT.ERP.Application.Bll.Security.Login
{
    public class LoginBll(IUnitOfWork _unitOfWork)
    {
        private readonly IUnitOfWork unitOfWork = _unitOfWork;
    }
}