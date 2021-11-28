using MediatR;
using SocialNetwork.Common.Requests;
using SocialNetwork.Data.Responses.Post;
using System;

namespace SocialNetwork.Domain.Queries.Post
{
    public class GetAllPostsOfUserQuery : IRequest<GetAllPostsOfUserResponse>
    {
        public Guid UserID { get; set; }
        public BasePagingRequest PagingRequest { get; set; }
    }
}
