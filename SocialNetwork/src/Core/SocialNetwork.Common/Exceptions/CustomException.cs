using SocialNetwork.Common.Responses;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Common.Exceptions
{
    public abstract class CustomException : Exception
    {
        public IEnumerable<Error> Errors { get; set; }

        protected CustomException(string message) : base(message)
        {

        }

        public abstract CustomResponseException ThrowException();
    }
}
