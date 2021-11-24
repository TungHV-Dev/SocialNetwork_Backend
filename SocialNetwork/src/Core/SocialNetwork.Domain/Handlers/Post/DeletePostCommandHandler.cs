using MediatR;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Data.Dtos.Post;
using SocialNetwork.Domain.Commands.Post;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Post
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, bool>
    {
        #region Fields
        private readonly IPostRepository _postRepository;
        private readonly ISecurityDataProvider _securityDataProvider;
        #endregion

        #region Contructor
        public DeletePostCommandHandler(IPostRepository postRepository, ISecurityDataProvider securityDataProvider)
        {
            _postRepository = postRepository;
            _securityDataProvider = securityDataProvider;
        }
        #endregion

        #region Public
        public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var requestDto = new DeletePostRequestDto
            {
                PostID = request.PostID,
                UserID = _securityDataProvider.GetUserData().UserID
            };
            var response = await _postRepository.DeletePost(requestDto);
            return response;
        }
        #endregion
    }
}
