using AutoMapper;
using MediatR;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Data.Dtos.Emotion;
using SocialNetwork.Data.Responses.Emotion;
using SocialNetwork.Domain.Queries.Emotion;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Emotion
{
    public class GetEmotionUserQueryHandler : IRequestHandler<GetEmotionUserQuery, GetAllUserResponse>
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;
        private readonly IEmotionRepository _emotionRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public GetEmotionUserQueryHandler(ISecurityDataProvider securityDataProvider, IEmotionRepository emotionRepository, IMapper mapper)
        {
            _securityDataProvider = securityDataProvider;
            _emotionRepository = emotionRepository;
            _mapper = mapper;
        }
        #endregion

        public async Task<GetAllUserResponse> Handle(GetEmotionUserQuery request, CancellationToken cancellationToken)
        {
            var requestDto = _mapper.Map<GetEmotionUserRequestDto>(request);
            requestDto.UserID = _securityDataProvider.GetUserData().UserID;

            var response = await _emotionRepository.GetEmotionUserOfPost(requestDto);
            return response;
        }
    }
}
