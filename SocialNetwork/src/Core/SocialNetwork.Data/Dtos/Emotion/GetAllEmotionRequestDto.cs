using System;

namespace SocialNetwork.Data.Dtos.Emotion
{
    public class GetAllEmotionRequestDto
    {
        public Guid PostID { get; set; }
        public Guid UserID { get; set; }
    }
}
