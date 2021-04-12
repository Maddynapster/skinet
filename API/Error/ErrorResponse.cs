using System;

namespace API.Error
{
    public class ErrorResponse
    {
        public ErrorResponse(int statusCode, string message= null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessage( statusCode);

        }

        protected string GetDefaultMessage(int statusCode)
        {
           return statusCode switch{
               400=> "Bad Request",
               401=> "Not auth",
               403=> "Moved",
               404=> "Page not found",
               500=> "Server error",
               _ => "tata"
           };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}