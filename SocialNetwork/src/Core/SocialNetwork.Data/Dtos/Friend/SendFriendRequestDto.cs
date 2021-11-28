using SocialNetwork.Common.Enums;
using System;

namespace SocialNetwork.Data.Dtos.Friend
{
    public class SendFriendRequestDto
    {
        public Guid SenderID { get; set; }
        public Guid ReceiverID { get; set; }
        public FriendRequestStatus RequestStatus => FriendRequestStatus.Pending;
    }
}
