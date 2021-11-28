using System;

namespace SocialNetwork.Data.Dtos.Friend
{
    public class UnfriendRequestDto
    {
        public Guid UserID { get; set; }
        public Guid FriendID { get; set; }
    }
}
