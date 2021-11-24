using MediatR;
using SocialNetwork.Common.Enums;
using System;

namespace SocialNetwork.Domain.Commands.Emotion
{
    public class ExpressEmotionCommand : IRequest<bool>
    {
        public Guid PostID { get; set; }
        public EmotionStatus Status { get; set; }
    }
}
