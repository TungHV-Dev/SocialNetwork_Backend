using System;

namespace SocialNetwork.Data.Dtos.Comment
{
    public class GetAllCommentRequestDto
    {
        public Guid PostID { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
