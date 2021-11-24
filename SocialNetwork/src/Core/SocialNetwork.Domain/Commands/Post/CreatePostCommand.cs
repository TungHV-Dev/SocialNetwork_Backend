using MediatR;
using SocialNetwork.Common.Enums;
using SocialNetwork.Data.Responses.Post;

namespace SocialNetwork.Domain.Commands.Post
{
    public class CreatePostCommand : IRequest<CreatePostResponse>
    {
        public string Content { get; set; }
        public PostStatus Status { get; set; }
    }
}
