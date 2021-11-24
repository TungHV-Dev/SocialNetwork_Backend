using SocialNetwork.Common.Requests;
using System;

namespace SocialNetwork.Data.Dtos.Post
{
    public class GetAllPostsRequestDto
    {
        public Guid UserID { get; set; }
        public BasePagingRequest Request { get; set; }
    }
}
