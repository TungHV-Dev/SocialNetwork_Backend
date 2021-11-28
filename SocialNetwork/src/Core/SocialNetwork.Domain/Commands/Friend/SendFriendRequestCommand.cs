using MediatR;
using SocialNetwork.Data.Responses.Friend;
using System;

namespace SocialNetwork.Domain.Commands.Friend
{
    public class SendFriendRequestCommand : IRequest<SendFriendRequestResponse>
    {
        public Guid ReceiverID { get; set; }
    }
}
