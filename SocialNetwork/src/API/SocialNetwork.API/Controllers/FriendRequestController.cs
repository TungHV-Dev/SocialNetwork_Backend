using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class FriendRequestController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Contructor
        public FriendRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Public Functions

        #endregion
    }
}
