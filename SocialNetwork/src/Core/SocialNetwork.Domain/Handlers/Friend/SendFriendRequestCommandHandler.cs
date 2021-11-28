using MediatR;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Data.Dtos.Friend;
using SocialNetwork.Data.Responses.Friend;
using SocialNetwork.Domain.Commands.Friend;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Friend
{
    public class SendFriendRequestCommandHandler : IRequestHandler<SendFriendRequestCommand, SendFriendRequestResponse>
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;
        private readonly IFriendRepository _friendRepository;
        #endregion

        #region Contructor
        public SendFriendRequestCommandHandler(ISecurityDataProvider securityDataProvider, IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
            _securityDataProvider = securityDataProvider;
        }
        #endregion

        #region Public Functions
        public async Task<SendFriendRequestResponse> Handle(SendFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var requestDto = new SendFriendRequestDto
            {
                SenderID = _securityDataProvider.GetUserData().UserID,
                ReceiverID = request.ReceiverID
            };
            var response = await _friendRepository.SendFriendRequest(requestDto);
            return response;
        }
        #endregion
    }
}
