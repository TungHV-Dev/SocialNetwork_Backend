using MediatR;
using SocialNetwork.Data.Responses.User;
using SocialNetwork.Domain.Queries.User;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.User
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        #endregion

        #region Contructor
        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Public Functions
        public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = await _userRepository.GetUserById(request.UserID);
            return response;
        }
        #endregion
    }
}
