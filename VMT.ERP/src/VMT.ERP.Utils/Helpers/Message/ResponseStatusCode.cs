namespace VMT.ERP.Utils.Helpers.Message
{
    public static class ResponseStatusCode
    {
        public const int Ok = 200;
        public const string OkMessage = "Ok";

        public const int BadRequest = 400;
        public const string BadRequestMessage = "BadRequest";

        public const int NotFound = 404;
        public const string NotFoundMessage = "Not Found";

        public const int InternalError = 500;
        public const string InternalErrorMessage = "Internal Error";

        public const int TooManyRequests = 429;
        public const string TooManyRequestsMessage = "TooManyRequests";
    }
}