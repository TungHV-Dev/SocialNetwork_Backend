using System.Collections.Generic;

namespace SocialNetwork.Common.Responses
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<Error> Error { get; set; }

        public static Result<TData> Success<TData>(TData data)
        {
            return new Result<TData>
            {
                Data = data,
                IsSuccess = true,
                Error = null
            };
        }
    }
}
