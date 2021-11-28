using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Attributes;
using SocialNetwork.Common.Responses;
using SocialNetwork.Data.Dtos.User;
using SocialNetwork.Data.Responses.Friend;
using SocialNetwork.Data.Responses.User;
using SocialNetwork.Domain.Queries.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class UserController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Contructor
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Get information of an user by user id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpGet("get-user")]
        [CustomAuthorize]
        public async Task<Result<GetUserResponse>> GetUser([FromQuery] Guid userID)
        {
            var query = new GetUserQuery { UserID = userID };
            var data = await _mediator.Send(query);

            return Result<GetUserResponse>.Success(data);
        }

        /// <summary>
        /// Get list friends of an user by user id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpGet("get-friends-of-user")]
        [CustomAuthorize]
        public async Task<Result<IEnumerable<GetFriendOfUserResponse>>> GetFriendsOfUser([FromQuery] Guid userID)
        {
            var query = new GetFriendsOfUserQuery { UserID = userID };
            var data = await _mediator.Send(query);

            return Result<IEnumerable<GetFriendOfUserResponse>>.Success(data);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-users")]
        [CustomAuthorize]
        public async Task<Result<IEnumerable<GetUserDto>>> GetAllUsers()
        {
            var query = new GetAllUserQuery();
            var data = await _mediator.Send(query);

            return Result<IEnumerable<GetUserDto>>.Success(data);
        }
        #endregion
    }
}
