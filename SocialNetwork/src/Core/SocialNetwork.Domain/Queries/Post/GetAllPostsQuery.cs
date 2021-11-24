using MediatR;
using SocialNetwork.Common.Requests;
using SocialNetwork.Data.Responses.Post;

namespace SocialNetwork.Domain.Queries.Post
{
    public class GetAllPostsQuery : IRequest<GetAllPostsResponse>
    {
        public BasePagingRequest Request { get; set; }
    }
}
