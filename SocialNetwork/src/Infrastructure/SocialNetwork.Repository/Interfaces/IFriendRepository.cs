using SocialNetwork.Data.Dtos.Friend;
using SocialNetwork.Data.Responses.Friend;
using System;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Interfaces
{
    public interface IFriendRepository
    {
        Task<SendFriendRequestResponse> SendFriendRequest(SendFriendRequestDto request);
        Task<bool> CancelFriendRequest(Guid requestID);
        Task<bool> ActionForFriendRequest(ActionForFriendRequestDto request);
        Task<bool> Unfriend(UnfriendRequestDto request);
        Task<GetAllPendingFriendRequestResponse> GetAllPendingFriendRequest(Guid userID);
    }
}
