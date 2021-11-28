using System;
using System.Collections.Generic;

namespace SocialNetwork.Data.Responses.Friend
{
    public class GetPendingFriendRequestResponse
    {
        public Guid RequestID { get; set; }
        public Guid SenderID { get; set; }
        public string SenderName { get; set; }
        public DateTime SentDate { get; set; }
    }

    public class GetAllPendingFriendRequestResponse
    {
        public int TotalRequests { get; set; }
        public IEnumerable<GetPendingFriendRequestResponse> RequestsDetail { get; set; }
    }
}
