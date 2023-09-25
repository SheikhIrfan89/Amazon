namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; } 
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message=null) 
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);

        }

        public string GetDefaultMessageForStatusCode(int statusCode)
        {
            
            return statusCode switch
            {
                400 => "You have made a Bad Request",
                401 => "You are not Authorized",
                404 => "This resource was not found",
                500 => "Something went wrong on the Server",
                _ => null
            };
        }

    }
}
