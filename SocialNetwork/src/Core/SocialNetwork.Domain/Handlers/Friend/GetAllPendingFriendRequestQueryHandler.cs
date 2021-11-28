using MediatR;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Data.Responses.Friend;
using SocialNetwork.Domain.Queries.Friend;
using SocialNetwork.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Friend
{
    public class GetAllPendingFriendRequestQueryHandler : IRequestHandler<GetAllPendingFriendRequestQuery, GetAllPendingFriendRequestResponse>
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;
        private readonly IFriendRepository _friendRepository;
        #endregion

        #region Contructor
        public GetAllPendingFriendRequestQueryHandler(ISecurityDataProvider securityDataProvider, IFriendRepository friendRepository)
        {
            _securityDataProvider = securityDataProvider;
            _friendRepository = friendRepository;
        }
        #endregion

        #region Public Functions
        public async Task<GetAllPendingFriendRequestResponse> Handle(GetAllPendingFriendRequestQuery request, CancellationToken cancellationToken)
        {
            var userID = _securityDataProvider.GetUserData().UserID;
            var response = await _friendRepository.GetAllPendingFriendRequest(userID);

            return response;
        }
        #endregion
    }
}
