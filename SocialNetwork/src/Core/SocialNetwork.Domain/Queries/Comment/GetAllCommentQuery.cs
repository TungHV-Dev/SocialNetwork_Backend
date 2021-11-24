using MediatR;
using SocialNetwork.Common.Requests;
using SocialNetwork.Data.Responses.Comment;
using System;

namespace SocialNetwork.Domain.Queries.Comment
{
    public class GetAllCommentQuery : IRequest<GetAllCommentResponse>
    {
        public Guid PostID { get; set; }
        public BasePagingRequest PagingRequest { get; set; }
    }
}
