using AutoMapper;
using MediatR;
using SocialNetwork.Data.Dtos.Post;
using SocialNetwork.Data.Responses.Post;
using SocialNetwork.Domain.Queries.Post;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Post
{
    public class GetAllPostsOfUserQueryHandler : IRequestHandler<GetAllPostsOfUserQuery, GetAllPostsOfUserResponse>
    {
        #region Fields
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public GetAllPostsOfUserQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Functions
        public async Task<GetAllPostsOfUserResponse> Handle(GetAllPostsOfUserQuery request, CancellationToken cancellationToken)
        {
            var requestDto = _mapper.Map<GetAllPostsOfUserRequestDto>(request);
            var data = await _postRepository.GetAllPostsOfUser(requestDto);
            return data;
        }
        #endregion
    }
}
