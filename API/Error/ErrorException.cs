
namespace API.Error
{
    public class ErrorException : ErrorResponse
    {
      public ErrorException(int statusCode,  string message= null,  string details= null): base( statusCode,  message)
        {
            this.StatusCode = statusCode;
            this.Details=details;
            this.Message = message ?? GetDefaultMessage( statusCode);

        }

        public string Details{get ; set;}
    }
}