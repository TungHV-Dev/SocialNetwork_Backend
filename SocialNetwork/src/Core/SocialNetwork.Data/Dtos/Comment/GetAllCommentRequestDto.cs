using SocialNetwork.Common.Requests;
using System;

namespace SocialNetwork.Data.Dtos.Comment
{
    public class GetAllCommentRequestDto
    {
        public Guid PostID { get; set; }
        public PagingRequest PagingRequest { get; set; }
    }
}
