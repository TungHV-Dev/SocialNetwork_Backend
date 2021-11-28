using System;

namespace SocialNetwork.Data.Responses.Friend
{
    public class GetFriendOfUserResponse
    {
        public Guid FriendID { get; set; }
        public string FriendName { get; set; }
        public DateTime StartDate { get; set; }
    }
}
