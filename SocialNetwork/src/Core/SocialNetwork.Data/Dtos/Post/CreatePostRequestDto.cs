using SocialNetwork.Common.Enums;
using System;

namespace SocialNetwork.Data.Dtos.Post
{
    public class CreatePostRequestDto
    {
        public string Content { get; set; }
        public FeelingStatus FeelingStatus { get; set; }
        public PrivacyStatus PrivacyStatus { get; set; }
        public Guid UserID { get; set; }
    }
}
