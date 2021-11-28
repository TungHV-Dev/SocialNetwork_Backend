using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Attributes;
using SocialNetwork.Common.Responses;
using SocialNetwork.Data.Responses.Post;
using SocialNetwork.Domain.Commands.Post;
using SocialNetwork.Domain.Queries.Post;
using System.Threading.Tasks;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class PostController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Contructor
        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Public
        /// <summary>
        /// Create a post of user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create-post")]
        [CustomAuthorize]
        public async Task<Result<CreatePostResponse>> CreatePost([FromBody] CreatePostCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<CreatePostResponse>.Success(data);
        }

        /// <summary>
        /// Delete a post of user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete-post")]
        [CustomAuthorize]
        public async Task<Result<bool>> DeletePost([FromBody] DeletePostCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<bool>.Success(data);
        }

        /// <summary>
        /// Edit an existing post of user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("edit-post")]
        [CustomAuthorize]
        public async Task<Result<bool>> EditPost([FromBody] EditPostCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<bool>.Success(data);
        }

        /// <summary>
        /// Get all post in timeline of user (all posts of friends of user)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("get-all-posts-in-timeline")]
        [CustomAuthorize]
        public async Task<Result<GetAllPostsInTimelineResponse>> GetAllPostsInTimeline([FromQuery] GetAllPostsInTimelineQuery query)
        {
            var data = await _mediator.Send(query);
            return Result<GetAllPostsInTimelineResponse>.Success(data);
        }

        /// <summary>
        /// get all posts of user
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get-all-posts-of-user")]
        [CustomAuthorize]
        public async Task<Result<GetAllPostsOfUserResponse>> GetAllPostsOfUser([FromQuery] GetAllPostsOfUserQuery query)
        {
            var data = await _mediator.Send(query);
            return Result<GetAllPostsOfUserResponse>.Success(data);
        }

        #endregion
    }
}
