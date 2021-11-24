using MediatR;
using SocialNetwork.Data.Responses.Comment;
using SocialNetwork.Domain.Queries.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Comment
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, GetAllCommentResponse>
    {
        #region Fields

        #endregion

        #region Contructor
        public GetAllCommentQueryHandler()
        {

        }
        #endregion

        #region
        public Task<GetAllCommentResponse> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
