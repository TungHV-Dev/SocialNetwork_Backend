using SocialNetwork.Common.Enums;
using System;

namespace SocialNetwork.Data.Dtos.Post
{
    public class EditPostRequestDto
    {
        public Guid UserID { get; set; }
        public Guid PostID { get; set; }
        public string Content { get; set; }
        public FeelingStatus FeelingStatus { get; set; }
        public PrivacyStatus PrivacyStatus { get; set; }
    }
}
