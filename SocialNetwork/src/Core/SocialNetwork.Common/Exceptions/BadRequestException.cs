using SocialNetwork.Common.Responses;
using System.Collections.Generic;
using System.Net;

namespace SocialNetwork.Common.Exceptions
{
    public class BadRequestException : CustomException
    {
        public BadRequestException(string message) : base(message)
        {

        }

        public override CustomResponseException ThrowException()
        {
            var errors = new List<Error> { new Error(HttpStatusCode.BadRequest.GetHashCode(), Message) };
            return new CustomResponseException(HttpStatusCode.BadRequest, errors);
        }
    }
}
