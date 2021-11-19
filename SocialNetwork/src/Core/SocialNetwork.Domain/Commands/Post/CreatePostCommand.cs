using MediatR;
using SocialNetwork.Common.Enums;

namespace SocialNetwork.Domain.Commands.Post
{
    public class CreatePostCommand : IRequest<bool>
    {
        public string Content { get; set; }
        public PostStatus Status { get; set; }
    }
}
