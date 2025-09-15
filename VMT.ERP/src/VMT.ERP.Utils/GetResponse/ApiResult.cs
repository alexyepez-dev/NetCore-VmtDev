using VMT.ERP.Utils.Helpers.Api;
using VMT.ERP.Utils.Helpers.Message;

namespace VMT.ERP.Utils.GetResponse
{
    public static class ApiResult
    {
        public static ApiResponse<T> Ok<T>(T data, string message)
        {
            var statusCodeOk = ResponseStatusCode.Ok;
            var statusCodeMessage = ResponseStatusCode.OkMessage;

            return new ApiResponse<T>
                (
                true,
                statusCodeOk,
                statusCodeMessage,
                message,
                data
                );
        }

        public static ApiResponse<T> NotFound<T>(string message)
        {
            var statusCodeNotFound = ResponseStatusCode.NotFound;
            var statusCodeNotFoundMessage = ResponseStatusCode.NotFoundMessage;

            return new ApiResponse<T>
                (
                true,
                statusCodeNotFound,
                statusCodeNotFoundMessage,
                message,
                default!
                );
        }

        public static ApiResponse<T> BadRequest<T>(string message)
        {
            var statusCodeBadRequest = ResponseStatusCode.BadRequest;
            var statusCodeBadRequestMessage = ResponseStatusCode.BadRequestMessage;

            return new ApiResponse<T>
                (
                true,
                statusCodeBadRequest,
                statusCodeBadRequestMessage,
                message,
                default!
                );
        }

        public static ApiResponse<T> InternalError<T>(string message, Exception error)
        {
            var statusCodeInternalError = ResponseStatusCode.InternalError;
            var statusCodeInternalErrorMessage = ResponseStatusCode.NotFoundMessage;

            return new ApiResponse<T>
                (
                true,
                statusCodeInternalError,
                statusCodeInternalErrorMessage,
                $"Error: {message} | Exception: {error.Message}",
                default!
                );
        }
    }
}