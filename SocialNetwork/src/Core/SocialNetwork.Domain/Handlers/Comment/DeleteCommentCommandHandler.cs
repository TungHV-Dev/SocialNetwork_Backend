using MediatR;
using SocialNetwork.Domain.Commands.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Comment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
    {
        #region Fields

        #endregion

        #region Contructor
        public DeleteCommentCommandHandler()
        {

        }
        #endregion

        #region
        public Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
