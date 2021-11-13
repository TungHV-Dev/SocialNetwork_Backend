using AutoMapper;
using MediatR;
using SocialNetwork.Common.Domain.MediatorExtension;
using SocialNetwork.Common.Domain.Request;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Common.Domain.Handler
{
    public abstract class CommandHandler<T> : IRequestHandler<T> where T : Command
    {
        protected readonly IMediatorExtend _mediator;
        protected readonly IMapper _mapper;

        protected CommandHandler(IMediatorExtend mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public abstract Task<Unit> Handle(T request, CancellationToken cancellationToken);
    }

    public abstract class CommandHandler<T, TResponse> : IRequestHandler<T, TResponse> where T : Command<TResponse>
    {
        protected readonly IMediatorExtend _mediator;
        protected readonly IMapper _mapper;

        protected CommandHandler(IMediatorExtend mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public abstract Task<TResponse> Handle(T request, CancellationToken cancellationToken);
    }
}
