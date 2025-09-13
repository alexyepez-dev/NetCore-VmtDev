using Microsoft.AspNetCore.Mvc;
using VMT.ERP.Utils.Exceptions;

namespace VMT.ERP.Api.Controllers.TestException
{
    [Route("api/v1/excep")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ExceptionController : ControllerBase
    {
        [HttpGet("test-exception")]
        public ActionResult TestException()
        {
            throw new Exception("¡Este es un error de prueba!");
        }
    }
}