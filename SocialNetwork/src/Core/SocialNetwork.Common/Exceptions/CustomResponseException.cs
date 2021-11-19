using SocialNetwork.Common.Responses;
using System;
using System.Collections.Generic;
using System.Net;

namespace SocialNetwork.Common.Exceptions
{
    public class CustomResponseException : Exception
    {
        public HttpStatusCode Code { get; set; }
        public IEnumerable<Error> Errors { get; private set; }

        public CustomResponseException(HttpStatusCode code, IEnumerable<Error> errors)
        {
            Code = code;
            Errors = errors;
        }
    }
}
