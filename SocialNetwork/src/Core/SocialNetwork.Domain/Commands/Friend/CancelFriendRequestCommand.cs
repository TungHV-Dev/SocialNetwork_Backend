using MediatR;
using System;

namespace SocialNetwork.Domain.Commands.Friend
{
    public class CancelFriendRequestCommand : IRequest<bool>
    {
        public Guid RequestID { get; set; }
    }
}
