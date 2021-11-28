using MediatR;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Data.Dtos.Friend;
using SocialNetwork.Domain.Commands.Friend;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Friend
{
    public class UnfriendCommandHandler : IRequestHandler<UnfriendCommand, bool>
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;
        private readonly IFriendRepository _friendRepository;
        #endregion

        #region Contructor
        public UnfriendCommandHandler(ISecurityDataProvider securityDataProvider, IFriendRepository friendRepository)
        {
            _securityDataProvider = securityDataProvider;
            _friendRepository = friendRepository;
        }
        #endregion

        #region Public Functions
        public async Task<bool> Handle(UnfriendCommand request, CancellationToken cancellationToken)
        {
            var userID = _securityDataProvider.GetUserData().UserID;
            var requestDto = new UnfriendRequestDto
            {
                UserID = userID,
                FriendID = request.FriendID
            };
            var response = await _friendRepository.Unfriend(requestDto);
            return response;
        }
        #endregion
    }
}
