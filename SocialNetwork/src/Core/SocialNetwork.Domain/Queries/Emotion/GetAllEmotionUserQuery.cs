using MediatR;
using SocialNetwork.Data.Responses.Emotion;
using System;

namespace SocialNetwork.Domain.Queries.Emotion
{
    public class GetAllEmotionUserQuery : IRequest<GetAllEmotionResponse>
    {
        public Guid PostID { get; set; }
    }
}
