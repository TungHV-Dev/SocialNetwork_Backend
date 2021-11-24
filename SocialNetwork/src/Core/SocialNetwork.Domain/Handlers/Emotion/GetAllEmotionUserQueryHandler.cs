using MediatR;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Data.Responses.Emotion;
using SocialNetwork.Domain.Queries.Emotion;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Emotion
{
    public class GetAllEmotionUserQueryHandler : IRequestHandler<GetAllEmotionUserQuery, GetAllEmotionResponse>
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;
        private readonly IEmotionRepository _emotionRepository;
        #endregion

        #region Contructor
        public GetAllEmotionUserQueryHandler(ISecurityDataProvider securityDataProvider, IEmotionRepository emotionRepository)
        {
            _securityDataProvider = securityDataProvider;
            _emotionRepository = emotionRepository;
        }
        #endregion

        #region Public Functions
        public async Task<GetAllEmotionResponse> Handle(GetAllEmotionUserQuery request, CancellationToken cancellationToken)
        {
            var response = await _emotionRepository.GetAllEmotionOfPost(request.PostID);
            return response;
        }
        #endregion
    }
}
