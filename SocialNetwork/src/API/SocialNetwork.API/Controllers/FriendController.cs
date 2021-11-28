using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Attributes;
using SocialNetwork.Common.Responses;
using SocialNetwork.Data.Responses.Friend;
using SocialNetwork.Domain.Commands.Friend;
using SocialNetwork.Domain.Queries.Friend;
using System.Threading.Tasks;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class FriendController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Contructor
        public FriendController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// User sends a friend request to anothor user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("send-friend-request")]
        [CustomAuthorize]
        public async Task<Result<SendFriendRequestResponse>> SendFriendRequest([FromBody] SendFriendRequestCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<SendFriendRequestResponse>.Success(data);
        }

        /// <summary>
        /// User cancels a friend request with anothor user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("cancel-friend-request")]
        [CustomAuthorize]
        public async Task<Result<bool>> CancelFriendRequest([FromBody] CancelFriendRequestCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<bool>.Success(data);
        }

        /// <summary>
        /// User accepts or rejects a friend request
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("action-for-friend-request")]
        [CustomAuthorize]
        public async Task<Result<bool>> ActionForFriendRequest([FromBody] ActionForFriendRequestCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<bool>.Success(data);
        }

        /// <summary>
        /// User unfriends with another user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("unfriend")]
        [CustomAuthorize]
        public async Task<Result<bool>> Unfriend([FromBody] UnfriendCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<bool>.Success(data);
        }

        /// <summary>
        /// Get all pending friend request of user
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-pending-friend-request")]
        [CustomAuthorize]
        public async Task<Result<GetAllPendingFriendRequestResponse>> GetAllPendingFriendRequest()
        {
            var query = new GetAllPendingFriendRequestQuery();
            var data = await _mediator.Send(query);

            return Result<GetAllPendingFriendRequestResponse>.Success(data);
        }
        #endregion
    }
}
