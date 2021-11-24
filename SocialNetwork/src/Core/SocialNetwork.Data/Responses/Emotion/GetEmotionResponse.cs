using SocialNetwork.Common.Enums;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Data.Responses.Emotion
{
    public class GetEmotionResponse
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public EmotionStatus Status { get; set; }
    }

    public class GetAllEmotionResponse
    {
        public int TotalItems { get; set; }
        public IEnumerable<GetEmotionResponse> Data { get; set; }
    }
}
