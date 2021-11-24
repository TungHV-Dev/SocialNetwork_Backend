using SocialNetwork.Common.Enums;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Data.Responses.Emotion
{
    public class UserResponse
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
    }

    public class GetAllUserResponse
    {
        public int TotalItems { get; set; }
        public IEnumerable<UserResponse> Data { get; set; }
    }

    public class GetEmotionResponse : UserResponse
    {
        public EmotionStatus Status { get; set; }
    }

    public class GetAllEmotionResponse
    {
        public int TotalItems { get; set; }
        public IEnumerable<GetEmotionResponse> Data { get; set; }
    }
}
