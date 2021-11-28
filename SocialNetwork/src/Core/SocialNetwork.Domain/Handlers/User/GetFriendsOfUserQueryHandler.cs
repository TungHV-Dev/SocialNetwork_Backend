using MediatR;
using SocialNetwork.Data.Responses.Friend;
using SocialNetwork.Domain.Queries.User;
using SocialNetwork.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.User
{
    public class GetFriendsOfUserQueryHandler : IRequestHandler<GetFriendsOfUserQuery, IEnumerable<GetFriendOfUserResponse>>
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        #endregion

        #region Contructor
        public GetFriendsOfUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Public Functions
        public async Task<IEnumerable<GetFriendOfUserResponse>> Handle(GetFriendsOfUserQuery request, CancellationToken cancellationToken)
        {
            var data = await _userRepository.GetFriendsOfUser(request.UserID);
            return data;
        }
        #endregion
    }
}
