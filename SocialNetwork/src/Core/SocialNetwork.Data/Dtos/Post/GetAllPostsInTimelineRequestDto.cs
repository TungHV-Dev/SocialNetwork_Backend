using SocialNetwork.Common.Requests;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Data.Dtos.Post
{
    public class GetAllPostsInTimelineRequestDto
    {
        public IEnumerable<Guid> FriendIds { get; set; }
        public BasePagingRequest Request { get; set; }
    }
}
