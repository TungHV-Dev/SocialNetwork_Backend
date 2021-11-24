using MediatR;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Domain.Commands.Emotion;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Emotion
{
    public class ExpressEmotionCommandHandler : IRequestHandler<ExpressEmotionCommand, bool>
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;

        #endregion

        #region Contructor
        public ExpressEmotionCommandHandler(ISecurityDataProvider securityDataProvider)
        {
            _securityDataProvider = securityDataProvider;
        }
        #endregion

        #region Public Functions
        public Task<bool> Handle(ExpressEmotionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
