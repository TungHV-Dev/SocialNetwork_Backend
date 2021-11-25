using System;

namespace SocialNetwork.Data.Dtos.Comment
{
    public class CreateCommentRequestDto
    {
        public Guid PostID { get; set; }
        public Guid UserID { get; set; }
        public string Content { get; set; }
    }
}
