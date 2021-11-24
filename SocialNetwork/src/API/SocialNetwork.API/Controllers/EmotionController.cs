using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Attributes;
using SocialNetwork.Common.Responses;
using SocialNetwork.Data.Responses.Emotion;
using SocialNetwork.Domain.Commands.Emotion;
using SocialNetwork.Domain.Queries.Emotion;
using System.Threading.Tasks;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class EmotionController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Contructor
        public EmotionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Express an emotion to a post
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("express-emotion")]
        [CustomAuthorize]
        public async Task<Result<bool>> ExpressEmotion([FromBody] ExpressEmotionCommand command)
        {
            var data = await _mediator.Send(command);
            return Result<bool>.Success(data);
        }

        /// <summary>
        /// Get all user with their emotion in a post
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get-all-emotions")]
        [CustomAuthorize]
        public async Task<Result<GetAllEmotionResponse>> GetAllEmotion([FromQuery] GetAllEmotionQuery query)
        {
            var data = await _mediator.Send(query);
            return Result<GetAllEmotionResponse>.Success(data);
        }
        #endregion
    }
}
