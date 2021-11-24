using SocialNetwork.Common.Enums;
using System;

namespace SocialNetwork.Data.Dtos.Emotion
{
    public class ExpressEmotionRequestDto
    {
        public Guid UserID { get; set; }
        public Guid PostID { get; set; }
        public EmotionStatus Status { get; set; }
    }
}
