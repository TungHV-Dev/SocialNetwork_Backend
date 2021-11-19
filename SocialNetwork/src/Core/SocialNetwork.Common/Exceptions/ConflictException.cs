using SocialNetwork.Common.Responses;
using System.Collections.Generic;
using System.Net;

namespace SocialNetwork.Common.Exceptions
{
    public class ConflictException : CustomException
    {
        public ConflictException(string message) : base(message)
        {

        }

        public override CustomResponseException ThrowException()
        {
            var errors = new List<Error> { new Error(HttpStatusCode.Conflict.GetHashCode(), Message) };
            return new CustomResponseException(HttpStatusCode.Conflict, errors);
        }
    }
}
