using MediatR;
using SocialNetwork.Data.Responses.Friend;

namespace SocialNetwork.Domain.Queries.Friend
{
    public class GetAllPendingFriendRequestQuery : IRequest<GetAllPendingFriendRequestResponse>
    {

    }
}
