using System;

namespace SocialNetwork.Data.Dtos.Comment
{
    public class EditCommentRequestDto
    {
        public Guid CommentID { get; set; }
        public string Content { get; set; }
    }
}
