using MediatR;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Data.Dtos.Post;
using SocialNetwork.Data.Responses.Post;
using SocialNetwork.Domain.Queries.Post;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Post
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, GetAllPostsResponse>
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;
        private readonly IPostRepository _postRepository;
        #endregion

        #region Contructor
        public GetAllPostsQueryHandler(ISecurityDataProvider securityDataProvider, IPostRepository postRepository)
        {
            _securityDataProvider = securityDataProvider;
            _postRepository = postRepository;
        }
        #endregion

        #region Public Functions
        public async Task<GetAllPostsResponse> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var requestDto = new GetAllPostsRequestDto
            {
                UserID = _securityDataProvider.GetUserData().UserID,
                Request = request.Request
            };

            var response = await _postRepository.GetAllPosts(requestDto);
            return response;
        }
        #endregion
    }
}
