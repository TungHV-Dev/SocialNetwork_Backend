using AutoMapper;
using MediatR;
using SocialNetwork.Data.Requests.Authentication;
using SocialNetwork.Data.Responses.Authentication;
using SocialNetwork.Domain.Queries.Authentication;
using SocialNetwork.Service.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Authentication
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
    {
        #region Fields
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public LoginQueryHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }
        #endregion

        public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var authenticationRequest = _mapper.Map<AuthenticationRequest>(request);
            var authenticationResponse = await _authenticationService.AuthenticateAsync(authenticationRequest);
            var loginResponse = _mapper.Map<LoginResponse>(authenticationResponse);

            return loginResponse;
        }
    }
}
