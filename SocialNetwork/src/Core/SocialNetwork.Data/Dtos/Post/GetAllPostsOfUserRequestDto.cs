using SocialNetwork.Common.Requests;
using System;

namespace SocialNetwork.Data.Dtos.Post
{
    public class GetAllPostsOfUserRequestDto
    {
        public Guid UserID { get; set; }
        public BasePagingRequest PagingRequest { get; set; }
    }
}
