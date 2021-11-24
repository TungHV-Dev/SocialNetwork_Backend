using MediatR;
using System;

namespace SocialNetwork.Domain.Commands.Comment
{
    public class EditCommentCommand : IRequest<bool>
    {
        public Guid CommentID { get; set; }
        public string Content { get; set; }
    }
}
