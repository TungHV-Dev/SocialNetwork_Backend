using SocialNetwork.Common.Enums;
using SocialNetwork.Common.Responses;
using System;

namespace SocialNetwork.Data.Responses.Post
{
    public class GetPostsOfUserResponse
    {
        public Guid PostID { get; set; }
        public string Content { get; set; }
        public FeelingStatus FeelingStatus { get; set; }
        public PrivacyStatus PrivacyStatus { get; set; }
        public int TotalEmotions { get; set; }
        public int TotalComments { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class GetAllPostsOfUserResponse : PagingResponse<GetPostsOfUserResponse>
    {

    }
}
