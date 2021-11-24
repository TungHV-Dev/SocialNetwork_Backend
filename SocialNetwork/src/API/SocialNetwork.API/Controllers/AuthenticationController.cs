using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Attributes;
using SocialNetwork.Common.Responses;
using SocialNetwork.Data.Responses.Authentication;
using SocialNetwork.Domain.Commands.Authentication;
using System.Threading.Tasks;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
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
        /// Register account for new user
        /// </summary>
        /// <returns></returns>
        [HttpPost("register")]
        [AllowAnonymous]
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
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<Result<LoginResponse>> Login([FromBody] LoginCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<LoginResponse>.Success(data);
        }

        /// <summary>
        /// Change password of user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("change-password")]
        [CustomAuthorize]
        public async Task<Result<bool>> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<bool>.Success(data);
        }
        #endregion
    }
}
