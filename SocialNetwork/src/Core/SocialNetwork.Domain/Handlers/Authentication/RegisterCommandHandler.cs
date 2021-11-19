using AutoMapper;
using MediatR;
using SocialNetwork.Data.Requests.Authentication;
using SocialNetwork.Domain.Commands.Authentication;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Authentication
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        #region
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        #endregion

        #region
        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerRequest = _mapper.Map<RegisterRequest>(request);
            var response = await _userRepository.RegisterNewUser(registerRequest);
            return response;
        }
        #endregion
    }
}
