using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialNetwork.Common.Exceptions;
using SocialNetwork.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SocialNetwork.API.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public CustomExceptionFilter()
        {

        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception == null)
            {
                return;
            }

            CustomResponseException exceptionToHandle;
            if (exception is CustomResponseException customResponseException)
            {
                exceptionToHandle = customResponseException;
            }
            else if (exception is CustomException customException)
            {
                exceptionToHandle = customException.ThrowException();
            }
            else
            {
                var errors = new List<Error> { new Error(HttpStatusCode.InternalServerError.GetHashCode(), exception.Message) };
                exceptionToHandle = new CustomResponseException(HttpStatusCode.InternalServerError, errors);
            }

            var response = new Result<bool>()
            {
                Data = false,
                IsSuccess = false,
                Error = exceptionToHandle.Errors
            };

            context.Result = new JsonResult(response)
            {
                StatusCode = exceptionToHandle.Code.GetHashCode()
            };
            context.ExceptionHandled = true;
        }
    }
}
