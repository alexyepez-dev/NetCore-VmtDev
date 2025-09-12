using Microsoft.AspNetCore.Mvc;
using VMT.ERP.Utils.Helpers.Api;
using VMT.ERP.Utils.Helpers.Message;

namespace VMT.ERP.Utils.GetResponse
{
    public static class GetResult
    {
        public static ActionResult Response<T>(ApiResponse<T> response, ControllerBase controller)
        {
            if (response.Success)
            {
                return controller.Ok(response);
            }

            return response.Code switch
            {
                ResponseStatusCode.NotFound => controller.NotFound(response),
                ResponseStatusCode.InternalError => controller.StatusCode(500, response),
                _ => controller.BadRequest(response),
            };
        }
    }
}