using SocialNetwork.Common.Enums;
using System;

namespace SocialNetwork.Data.Dtos.Post
{
    public class CreatePostRequestDto
    {
        public string Content { get; set; }
        public PostStatus Status { get; set; }
        public Guid UserID { get; set; }
    }
}
