using AutoMapper;
using MediatR;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Data.Dtos.Emotion;
using SocialNetwork.Domain.Commands.Emotion;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Emotion
{
    public class ExpressEmotionCommandHandler : IRequestHandler<ExpressEmotionCommand, bool>
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;
        private readonly IEmotionRepository _emotionRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public ExpressEmotionCommandHandler(ISecurityDataProvider securityDataProvider, IEmotionRepository emotionRepository, IMapper mapper)
        {
            _securityDataProvider = securityDataProvider;
            _emotionRepository = emotionRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Functions
        public async Task<bool> Handle(ExpressEmotionCommand request, CancellationToken cancellationToken)
        {
            var requestDto = _mapper.Map<ExpressEmotionRequestDto>(request);
            requestDto.UserID = _securityDataProvider.GetUserData().UserID;

            var response = await _emotionRepository.ExpressEmotionToPost(requestDto);
            return response;
        }
        #endregion
    }
}
