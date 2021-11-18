using MediatR;
using SocialNetwork.Common.Domain.Request;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Common.Domain.MediatorExtension
{
    public class MediatorExtend : IMediatorExtend
    {
        private readonly IMediator _mediator;

        public MediatorExtend(IMediator mediator)
        {
            _mediator = mediator;
        }
        public Task<T> SendCommand<T>(Command<T> command, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(command, cancellationToken);
        }

        public Task SendCommand(Command command, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(command, cancellationToken);
        }

        public Task<T> SendQuery<T>(Query<T> query, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(query, cancellationToken);
        }

        public Task SendQuery(Query query, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(query, cancellationToken);
        }
    }
}
