using MediatR;
using SocialNetwork.Data.Responses.Comment;
using System;

namespace SocialNetwork.Domain.Commands.Comment
{
    public class CreateCommentCommand : IRequest<CreateCommentResponse>
    {
        public Guid PostID { get; set; }
        public string Content { get; set; }
    }
}
