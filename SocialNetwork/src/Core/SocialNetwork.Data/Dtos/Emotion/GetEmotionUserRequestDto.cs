using SocialNetwork.Common.Enums;
using System;

namespace SocialNetwork.Data.Dtos.Emotion
{
    public class GetEmotionUserRequestDto
    {
        public Guid PostID { get; set; }
        public EmotionStatus Status { get; set; }
    }
}
