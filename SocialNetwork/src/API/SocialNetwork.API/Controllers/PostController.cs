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
        /// Get all post of user with paging
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("get-all-posts")]
        [CustomAuthorize]
        public async Task<Result<GetAllPostsResponse>> GetAllPosts([FromBody] GetAllPostsQuery query)
        {
            var data = await _mediator.Send(query);
            return Result<GetAllPostsResponse>.Success(data);
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

        #endregion
    }
}
