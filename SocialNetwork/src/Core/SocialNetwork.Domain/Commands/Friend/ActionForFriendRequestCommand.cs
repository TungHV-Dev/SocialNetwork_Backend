using MediatR;
using SocialNetwork.Common.Enums;
using System;

namespace SocialNetwork.Domain.Commands.Friend
{
    public class ActionForFriendRequestCommand : IRequest<bool>
    {
        public Guid RequestID { get; set; }
        public ActionForFriendRequest Action { get; set; }
    }
}
