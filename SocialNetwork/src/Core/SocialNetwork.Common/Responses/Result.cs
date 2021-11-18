using System.Net;

namespace SocialNetwork.Common.Responses
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public Error Error { get; set; }

        public static Result<TData> Success<TData>(TData data)
        {
            return new Result<TData>
            {
                Data = data,
                IsSuccess = true,
                Error = null
            };
        }

        public static Result<TData> BadRequest<TData>(string message)
        {
            return new Result<TData>
            {
                Data = default,
                IsSuccess = false,
                Error = new Error { Code = HttpStatusCode.BadRequest.GetHashCode(), Message = message }
            };
        }

        public static Result<TData> Conflict<TData>(string message)
        {
            return new Result<TData>
            {
                Data = default,
                IsSuccess = false,
                Error = new Error { Code = HttpStatusCode.Conflict.GetHashCode(), Message = message }
            };
        }

        public static Result<TData> NotFound<TData>(string message)
        {
            return new Result<TData>
            {
                Data = default,
                IsSuccess = false,
                Error = new Error { Code = HttpStatusCode.NotFound.GetHashCode(), Message = message }
            };
        }
    }
}
