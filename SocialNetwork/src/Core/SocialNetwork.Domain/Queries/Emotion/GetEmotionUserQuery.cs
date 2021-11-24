using MediatR;
using SocialNetwork.Common.Enums;
using SocialNetwork.Data.Responses.Emotion;
using System;

namespace SocialNetwork.Domain.Queries.Emotion
{
    public class GetEmotionUserQuery : IRequest<GetAllUserResponse>
    {
        public Guid PostID { get; set; }
        public EmotionStatus Status { get; set; }
    }
}
