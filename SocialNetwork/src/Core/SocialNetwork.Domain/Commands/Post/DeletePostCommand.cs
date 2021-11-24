using MediatR;
using System;

namespace SocialNetwork.Domain.Commands.Post
{
    public class DeletePostCommand : IRequest<bool>
    {
        public Guid PostID { get; set; }
    }
}
