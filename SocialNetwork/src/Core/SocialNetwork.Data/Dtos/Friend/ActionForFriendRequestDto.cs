using SocialNetwork.Common.Enums;
using System;

namespace SocialNetwork.Data.Dtos.Friend
{
    public class ActionForFriendRequestDto
    {
        public Guid RequestID { get; set; }
        public ActionForFriendRequest Action { get; set; }
    }
}
