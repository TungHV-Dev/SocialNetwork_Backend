using MediatR;
using SocialNetwork.Data.Responses.Comment;
using SocialNetwork.Domain.Commands.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Comment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreateCommentResponse>
    {
        #region Fields

        #endregion

        #region Contructor
        public CreateCommentCommandHandler()
        {

        }
        #endregion

        #region
        public Task<CreateCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
