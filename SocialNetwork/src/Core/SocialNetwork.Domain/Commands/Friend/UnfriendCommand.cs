using MediatR;
using System;

namespace SocialNetwork.Domain.Commands.Friend
{
    public class UnfriendCommand : IRequest<bool>
    {
        public Guid FriendID { get; set; }
    }
}
