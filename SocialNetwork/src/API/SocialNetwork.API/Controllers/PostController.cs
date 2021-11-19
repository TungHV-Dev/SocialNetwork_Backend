using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Attributes;
using SocialNetwork.Common.Responses;
using SocialNetwork.Domain.Commands.Post;
using System.Threading.Tasks;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpPost("create-post")]
        [CustomAuthorize]
        public async Task<Result<bool>> CreatePost([FromBody] CreatePostCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<bool>.Success(data);
        }

        #endregion
    }
}
