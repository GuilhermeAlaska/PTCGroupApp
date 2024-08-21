namespace Application.Common
{
    public class BaseResult<T> where T : class
    {
        public BaseResult(int statusCode, string? message)
        {
            Message = message;
            StatusCode = statusCode;
            Success = false;
        }

        public BaseResult(int statusCode, T data)
        {
            Data = data;
            StatusCode = statusCode;
            Success = true;
        }

        public T? Data { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; private set; }
    }
}