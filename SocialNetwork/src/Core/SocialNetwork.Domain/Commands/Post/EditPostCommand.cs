using MediatR;
using SocialNetwork.Common.Enums;
using System;

namespace SocialNetwork.Domain.Commands.Post
{
    public class EditPostCommand : IRequest<bool>
    {
        public Guid PostID { get; set; }
        public string Content { get; set; }
        public FeelingStatus? FeelingStatus { get; set; }
        public PrivacyStatus PrivacyStatus { get; set; }
    }
}
