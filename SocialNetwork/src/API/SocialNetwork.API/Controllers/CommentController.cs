using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Attributes;
using SocialNetwork.Common.Responses;
using SocialNetwork.Data.Responses.Comment;
using SocialNetwork.Domain.Commands.Comment;
using SocialNetwork.Domain.Queries.Comment;
using System.Threading.Tasks;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class CommentController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Contructor
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// User create a comment in a post
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create-comment")]
        [CustomAuthorize]
        public async Task<Result<CreateCommentResponse>> CreateComment([FromBody] CreateCommentCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<CreateCommentResponse>.Success(data);
        }

        /// <summary>
        /// User edit their existed comment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("edit-comment")]
        [CustomAuthorize]
        public async Task<Result<bool>> EditComment([FromBody] EditCommentCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<bool>.Success(data);
        }

        /// <summary>
        /// User delete their existed comment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete-comment")]
        [CustomAuthorize]
        public async Task<Result<bool>> DeleteComment([FromBody] DeleteCommentCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<bool>.Success(data);
        }

        /// <summary>
        /// Get all comment in a post
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get-all-comment")]
        [CustomAuthorize]
        public async Task<Result<GetAllCommentResponse>> GetAllComment([FromQuery] GetAllCommentQuery query)
        {
            var data = await _mediator.Send(query);
            return Result<GetAllCommentResponse>.Success(data);
        }
        #endregion
    }
}
