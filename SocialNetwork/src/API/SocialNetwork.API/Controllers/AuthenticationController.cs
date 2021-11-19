using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Attributes;
using SocialNetwork.Common.Responses;
using SocialNetwork.Data.Responses.Authentication;
using SocialNetwork.Domain.Commands.Authentication;
using SocialNetwork.Domain.Queries.Authentication;
using System.Threading.Tasks;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Contructor
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Public
        /// <summary>
        /// Register feature
        /// </summary>
        /// <returns></returns>
        [HttpPost("register")]
        [CustomAuthorize]
        public async Task<Result<bool>> Register([FromBody] RegisterCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<bool>.Success(data);
        }

        /// <summary>
        /// Login feature
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("login")]
        [CustomAuthorize]
        public async Task<Result<LoginResponse>> Login([FromQuery] LoginQuery query)
        {
            var data = await _mediator.Send(query);
            return Result<LoginResponse>.Success(data);
        }
        #endregion
    }
}
