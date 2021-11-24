using AutoMapper;
using MediatR;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Data.Requests.Authentication;
using SocialNetwork.Domain.Commands.Authentication;
using SocialNetwork.Service.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Authentication
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public ChangePasswordCommandHandler(ISecurityDataProvider securityDataProvider, IAuthenticationService authenticationService, IMapper mapper)
        {
            _securityDataProvider = securityDataProvider;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }
        #endregion

        #region Public Functions
        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var changePasswordRequest = _mapper.Map<ChangePasswordRequest>(request);
            changePasswordRequest.UserName = _securityDataProvider.GetUserData().UserName;

            var response = await _authenticationService.ChangePasswordAsync(changePasswordRequest);
            return response;
        }
        #endregion
    }
}
