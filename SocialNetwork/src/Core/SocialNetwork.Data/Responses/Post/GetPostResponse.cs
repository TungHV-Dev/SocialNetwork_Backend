using SocialNetwork.Common.Enums;
using SocialNetwork.Common.Responses;
using System;

namespace SocialNetwork.Data.Responses.Post
{
    public class GetPostResponse
    {
        public Guid PostID { get; set; }
        public string Content { get; set; }
        public PostStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class GetAllPostsResponse : PagingResponse<GetPostResponse>
    {

    }
}
