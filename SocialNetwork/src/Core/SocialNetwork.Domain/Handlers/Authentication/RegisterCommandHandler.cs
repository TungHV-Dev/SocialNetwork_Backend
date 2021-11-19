using AutoMapper;
using MediatR;
using SocialNetwork.Data.Requests.Authentication;
using SocialNetwork.Domain.Commands.Authentication;
using SocialNetwork.Service.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Authentication
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        #region
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public RegisterCommandHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }
        #endregion

        #region
        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerRequest = _mapper.Map<RegisterRequest>(request);
            var response = await _authenticationService.RegisterAsync(registerRequest);
            return response;
        }
        #endregion
    }
}
