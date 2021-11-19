using SocialNetwork.Common.Responses;
using System.Collections.Generic;
using System.Net;

namespace SocialNetwork.Common.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException(string message) : base(message)
        {

        }

        public override CustomResponseException ThrowException()
        {
            var errors = new List<Error> { new Error(HttpStatusCode.NotFound.GetHashCode(), Message) };
            return new CustomResponseException(HttpStatusCode.NotFound, errors);
        }
    }
}
