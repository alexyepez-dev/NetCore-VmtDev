namespace VMT.ERP.Utils.Helpers.Api
{
    public class ApiResponse<T>(bool success, int code, string statusCode, string message, T data)
    {
        public bool Success { get; set; } = success;
        public int Code { get; set; } = code;
        public string StatusCode { get; set; } = statusCode;
        public string Message { get; set; } = message;
        public T Data { get; set; } = data;
    }
}