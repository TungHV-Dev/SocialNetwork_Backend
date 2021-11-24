using MediatR;
using SocialNetwork.Domain.Commands.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Comment
{
    public class EditCommentCommandHandler : IRequestHandler<EditCommentCommand, bool>
    {
        #region Fields

        #endregion

        #region Contructor
        public EditCommentCommandHandler()
        {

        }
        #endregion

        #region
        public Task<bool> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
