namespace UsersAPI.Models
{
    public class ResponseModel<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ResponseModel() { }

        public ResponseModel(int statusCode, string message, T data = default)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public static ResponseModel<T> SuccessResponse(T data, string message = "Success", int statusCode = 200)
        {
            return new ResponseModel<T>
            {
                Message = message,
                StatusCode = statusCode,
                Data = data
            };
        }

        public static ResponseModel<T> ErrorResponse(string message, int statusCode = 400)
        {
            return new ResponseModel<T>
            {
                Message = message,
                StatusCode = statusCode,
            };
        }

        public static ResponseModel<List<T>> SuccessResponseList(List<T> data, string message = "Success", int statusCode = 200)
        {
            return new ResponseModel<List<T>>
            {
                Message = message,
                StatusCode = statusCode,
                Data = data
            };
        }

        public static ResponseModel<List<T>> ErrorResponseList(string message, int statusCode = 400)
        {
            return new ResponseModel<List<T>>
            {
                Message = message,
                StatusCode = statusCode,
            };
        }
    }
}