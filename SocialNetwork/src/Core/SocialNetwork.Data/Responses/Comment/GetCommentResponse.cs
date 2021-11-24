using SocialNetwork.Common.Responses;
using System;

namespace SocialNetwork.Data.Responses.Comment
{
    public class GetCommentResponse
    {
        public Guid CommentID { get; set; }
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime LastModified { get; set; }
    }

    public class GetAllCommentResponse : PagingResponse<GetCommentResponse>
    {

    }
}
