using MediatR;
using SocialNetwork.Common.Enums;
using SocialNetwork.Data.Responses.Post;

namespace SocialNetwork.Domain.Commands.Post
{
    public class CreatePostCommand : IRequest<CreatePostResponse>
    {
        public string Content { get; set; }
        public FeelingStatus? FeelingStatus { get; set; }
        public PrivacyStatus PrivacyStatus { get; set; }
    }
}
