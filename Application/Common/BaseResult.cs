namespace Application.Common
{
    public class BaseResult<T> where T : class
    {
        public BaseResult(int statusCode, string? message, bool success = false)
        {
            Message = message;
            StatusCode = statusCode;
            Success = success;
        }

        public BaseResult(int statusCode, T data, bool success = true)
        {
            Data = data;
            StatusCode = statusCode;
            Success = success;
        }

        public T? Data { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; private set; }
    }
}