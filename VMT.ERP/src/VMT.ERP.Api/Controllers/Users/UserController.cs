using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using VMT.ERP.Application.Interfaces.User;
using VMT.ERP.Domain.Entities;
using VMT.ERP.Utils.Exception;
using VMT.ERP.Utils.GetResponse;
using VMT.ERP.Utils.Helpers.Api;

namespace VMT.ERP.Api.Controllers.Users
{
    [Route("api/v1/user")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Usuario>>>> GetAllUsers(
            [FromServices] IGetAllUserBll bll)
        {
            var listOfUsers = await bll.Execute();

            return GetResult.Response(listOfUsers, this);
        }
    }
}