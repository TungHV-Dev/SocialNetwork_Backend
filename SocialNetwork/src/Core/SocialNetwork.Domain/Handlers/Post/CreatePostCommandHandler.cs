using AutoMapper;
using MediatR;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Data.Dtos.Post;
using SocialNetwork.Domain.Commands.Post;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Post
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, bool>
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public CreatePostCommandHandler(ISecurityDataProvider securityDataProvider, IPostRepository postRepository, IMapper mapper)
        {
            _securityDataProvider = securityDataProvider;
            _postRepository = postRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public
        public async Task<bool> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var requestDto = _mapper.Map<CreatePostRequestDto>(request);
            requestDto.UserID = _securityDataProvider.GetUserData().UserID;

            var response = await _postRepository.CreatePost(requestDto);
            return response;
        }
        #endregion
    }
}
