using MediatR;
using SocialNetwork.Common.Requests;
using SocialNetwork.Data.Responses.Post;

namespace SocialNetwork.Domain.Queries.Post
{
    public class GetAllPostsInTimelineQuery : IRequest<GetAllPostsInTimelineResponse>
    {
        public BasePagingRequest Request { get; set; }
    }
}
