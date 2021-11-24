using MediatR;
using System;

namespace SocialNetwork.Domain.Commands.Comment
{
    public class DeleteCommentCommand : IRequest<bool>
    {
        public Guid CommentID { get; set; }
    }
}
