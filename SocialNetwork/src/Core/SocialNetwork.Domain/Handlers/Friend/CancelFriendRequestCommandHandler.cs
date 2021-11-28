using MediatR;
using SocialNetwork.Domain.Commands.Friend;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Friend
{
    public class CancelFriendRequestCommandHandler : IRequestHandler<CancelFriendRequestCommand, bool>
    {
        #region Fields
        private readonly IFriendRepository _friendRepository;
        #endregion

        #region Contructor
        public CancelFriendRequestCommandHandler(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }
        #endregion

        #region Public Functions
        public async Task<bool> Handle(CancelFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var response = await _friendRepository.CancelFriendRequest(request.RequestID);
            return response;
        }
        #endregion
    }
}
